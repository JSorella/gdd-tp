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
        /// Funciones Genericas
        /// </summary>

        /*====================================================================================================*/
        /*====================================================================================================*/

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

        private SqlCommand cargarParametrosCommand(SqlCommand cmd, String[,] aParam)
        {
            cmd.Parameters.Clear();

            if (aParam != null)
            {
                for (int i = 0; i < aParam.GetLength(0); i++)
                {
                    cmd.Parameters.AddWithValue("@" + aParam[i, 0], aParam[i, 1]);
                }
            }

            return cmd;
        }

        /*====================================================================================================*/
        /*====================================================================================================*/

        //Ejecutar un Comando armado - Es algo temporal, deberiamos no utilizarlo.
        public void executeCommandConn(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            cmd.Connection = conn;

            try
            {
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se detecto un error en executeCommand con el Texto: " + cmd.CommandText + System.Environment.NewLine + "Mensaje de Error: " + ex.Message);
            }
        }

        //Query Obtener DataTable BD      
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
                    cmd = cargarParametrosCommand(cmd, aParam);

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

        //Query Funciones Escalares - Parametros Tabla (Estructura) / Parametros Matriz (Pocos)
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
                    cmd = cargarParametrosCommand(cmd, aParam);

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

        //Query SP Con Parametros Out
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

                executeCommandMasivo(ref cmd, spName, oDtParam, aParam, "");

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

        //Query Stored Procedure con Parametros Tabla (Estructura) / Parametros Matriz (Poco)
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

        //Ejecuta un SqlCommand que ya posee una SqlConnection (Y posible SqlTransaction)
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
                    cmd = cargarParametrosCommand(cmd, aParam);

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

        /*====================================================================================================*/
        /*====================================================================================================*/
    }
}
