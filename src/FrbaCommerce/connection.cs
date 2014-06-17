using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace FrbaCommerce
{
    public class Connection
    {
        /// <summary>
        /// Clase unica de Funciones Genericas para preparar y ejecutar Comandos con la Base de Datos.
        /// </summary>

        #region Preparacion de Comandos

        /// <summary>
        /// Dado un DataTable donde las Columnas son los Parametros del Comando recibido, 
        /// y una Fila con los valores de los Prametros se carga el Comando de forma generica.
        /// En caso de hay parametros OUTPUT en un SP, exite la posibilidad de configurarlo asi.
        /// </summary>

        private SqlCommand cargarParametrosCommand(SqlCommand cmd, DataTable oTable, DataRow oRow, String sListOutParam)
        {
            cmd.Parameters.Clear();

            if (oTable != null)
            {
                foreach (DataColumn oCol in oTable.Columns)
                {
                    if (sListOutParam.ToUpper().Contains(oCol.ColumnName.ToUpper()))
                        cmd.Parameters.AddWithValue("@" + oCol.ColumnName, oRow[oCol.ColumnName]).Direction = ParameterDirection.Output;
                    else
                        cmd.Parameters.AddWithValue("@" + oCol.ColumnName, oRow[oCol.ColumnName]);
                }
            }

            return cmd;
        }

        /// <summary>
        /// Esta Funcion es igual a la anterior, solo que utiliza una Matriz {NombreCampo, Valor} para cargar los Parametros.
        /// </summary>

        private SqlCommand cargarParametrosCommand(SqlCommand cmd, String[,] aParam, String sListOutParam)
        {
            cmd.Parameters.Clear();

            if (aParam != null)
            {
                for (int i = 0; i < aParam.GetLength(0); i++)
                {
                    if (sListOutParam.ToUpper().Contains(aParam[i, 0].ToUpper()))
                        cmd.Parameters.AddWithValue("@" + aParam[i, 0], aParam[i, 1]).Direction = ParameterDirection.Output;
                    else
                        cmd.Parameters.AddWithValue("@" + aParam[i, 0], aParam[i, 1]);
                }
            }

            return cmd;
        }

        #endregion

        #region Ejecucion de Comandos

        /// <summary>
        /// Genera un DataAdapter segun un query dado - Solo para grilla paginada.
        /// </summary>
        public SqlDataAdapter executeQueryAdapter(String query, ref DataSet oDs, ref DataTable oDt, 
                                String dataMember, int inicio, int tope)
        {
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlDataAdapter oAdapter = new SqlDataAdapter(query, conn);

            try
            {
                conn.Open();

                try
                {
                    oAdapter.Fill(oDs, inicio, tope, dataMember);
                    oAdapter.Fill(oDt);
                }
                finally
                {
                    conn.Close();
                }

                return oAdapter;
            }
            catch (Exception ex)
            {
                throw new Exception("Se detecto un error en executeQueryAdapter con el Query: " + query + System.Environment.NewLine + "Mensaje de Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Ejecuta un Query que devuelve un DataTable.
        /// Puede ser un Query completo (Ej. un Select From Tabla) o puede tener parametros, los cuales pueden venir en un 
        /// DataTable o en una Matriz (Ej. un Select From Funciion(@Parametros)).
        /// </summary>  
        public DataTable executeQueryTable(String query, DataTable oDtParam, String[,] aParam)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            try
            {
                if(oDtParam != null)
                    cmd = cargarParametrosCommand(cmd, oDtParam, oDtParam.Rows[0], "");

                if(aParam != null)
                    cmd = cargarParametrosCommand(cmd, aParam, "");

                conn.Open();

                dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                throw new Exception("Se detecto un error en executeQueryTable con la Query: " + query + System.Environment.NewLine + "Mensaje de Error: " + ex.Message);
            }

            return dt;
        }

        /// <summary>
        /// Ejecuta un Query para Funciones Escalares. Devuelve un Object que debe ser transformado por quien lo llamo.
        /// Puede ser un Query completo (Ej. un Funcion(1)) o puede tener parametros, los cuales pueden venir en un 
        /// DataTable o en una Matriz (Ej. un Funciion(@Parametros)).
        /// </summary>  
        public object executeQueryFuncEscalar(String funNameParam, DataTable oDtParam, String[,] aParam)
        {
            String query = "Select " + funNameParam;;
            object result;

            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            try
            {
                if (oDtParam != null)
                    cmd = cargarParametrosCommand(cmd, oDtParam, oDtParam.Rows[0], "");

                if (aParam != null)
                    cmd = cargarParametrosCommand(cmd, aParam, "");

                conn.Open();

                try
                {
                    result = cmd.ExecuteScalar();
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = null;
                throw new Exception("Se detecto un error en executeQueryFuncEscalar con la Funcion: " + funNameParam + System.Environment.NewLine + "Mensaje de Error: " + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Ejecuta un Stored Procedure que realiza Modificaciones en la Base (Inserts - Updates - Deletes)
        /// Puede o no tener parametros. En caso de que lo tenga, pueden venir en un DataTable o en una Matriz.
        /// Solo debe ser llamado si el SP cuenta con parametros OutPut, ya que retorna un String con los valores
        /// de las variables OutPut separadas por el caracter "|" para ser tratato por que hizo la llamda.
        /// </summary>  
        public String executeQuerySPOutPut(String spName, DataTable oDtParam, String[,] aParam, String sListOutParam)
        {
            String result = "";
            String[] aListOutParam = sListOutParam.Split('|');

            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                executeCommandMasivo(ref cmd, spName, oDtParam, aParam, sListOutParam);

                for (int i = 0; i < aListOutParam.Length; i++)
                    result = result + cmd.Parameters["@" + aListOutParam[i]].Value.ToString() + "|";

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                throw new Exception("Se detecto un error en executeQuerySPOutPut con el SP: " + spName + System.Environment.NewLine + "Mensaje de Error: " + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Ejecuta un Stored Procedure que realiza Modificaciones en la Base (Inserts - Updates - Deletes)
        /// Puede o no tener parametros. En caso de que lo tenga, pueden venir en un DataTable o en una Matriz.
        /// </summary>  
        public void executeQuerySP(String spName, DataTable oDtParam, String[,] aParam)
        {
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                executeCommandMasivo(ref cmd, spName, oDtParam, aParam, "");

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                throw new Exception("Se detecto un error en executeQuerySPMasivo con el SP: " + spName + System.Environment.NewLine + "Mensaje de Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Ejecuta un SqlCommand enviado por parametros, el cual es modificado dentro de la funcion.
        /// El SqlCommand recibio ya contiene dentro una Conexion Abierta a la Base, y tambien puede ser
        /// que tenga una Transaccion Activa (SqlTransaction generado por codigo), especial para
        /// Ejecutar de forma Masiva (Ej.: Encabezado + Detalle) en una misma Tr.
        /// </summary> 
        public void executeCommandMasivo(ref SqlCommand cmd, String cmdTxt, DataTable oDatos, String[,] aParam, String sListOutParam)
        {
            cmd.CommandText = cmdTxt;

            if (oDatos != null)
            {
                foreach (DataRow oRow in oDatos.Rows)
                {
                    if (oDatos != null)
                        cmd = cargarParametrosCommand(cmd, oDatos, oRow, sListOutParam);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                if (aParam != null)
                    cmd = cargarParametrosCommand(cmd, aParam, sListOutParam);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion
    }
}
