using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FrbaCommerce
{
    class Stored_procedures
    {
        /*clase que tiene metodos que hacen de interfaz con los stored procedures que estan en la BD sql server*/

        //atributo
        Connection connect = new Connection();
        string query;

        public void update_cant_intentos_fallidos(string username, int cant_intentos)
        {

            query = "EXECUTE J2LA.update_cant_intentos_fallidos " +
                    "'" + username + "'," +
                    cant_intentos.ToString();

            connect.execute_query_only(query);


        }

        public void insert_Rol(string nombre_rol)
        {
            query = "EXECUTE J2LA.insert_Rol '" + nombre_rol + "'";

            connect.execute_query_only(query);
        }

        public void insert_funcxrol(string nombre_rol, int func_id)
        {
            //hallamos Id_Rol
            query = "SELECT rol_id FROM J2LA.Roles WHERE rol_nombre = '" + nombre_rol + "'";
            DataTable table_rol = connect.execute_query(query);
            string rol_id = table_rol.Rows[0].ItemArray[0].ToString();

            query = "EXECUTE J2LA.insert_rolfun " + rol_id + ", " + func_id.ToString();
            connect.execute_query_only(query);

        }

        public void delete_funcxrol(int rol_id, string func_id)
        {
            query = "EXECUTE J2LA.delete_rolfun " + rol_id + ", " + func_id;
            connect.execute_query_only(query);
        }

        public void update_rol(int rol_id, string rol_nombre, int rol_estado)
        {
            query = "EXECUTE J2LA.update_rol " + rol_id + ", '" + rol_nombre + "', '" + rol_estado + "'";
            connect.execute_query_only(query);
        }

        public void baja_rol(string rol_id, string rol_nombre)
        {
            query = "EXECUTE J2LA.baja_rol " + rol_id + ", '" + rol_nombre;
            connect.execute_query_only(query);
        }

        public DataTable cargar_campos_cliente(string dni)
        {
            query = "EXECUTE J2LA.cargar_campos_cliente " + dni;
            return connect.execute_query(query);
        }

        public void update_Cliente(string cli_dni, string cli_nombre, string cli_apellido, string cli_dir, string cli_telefono, string cli_mail, string cli_fecha_nac, string cli_sexo, string cli_discapacitado, string condicion)
        {
            query = "EXECUTE J2LA.update_Cliente " + cli_dni + ",'" + cli_nombre + "','" + cli_apellido + "','" + cli_dir + "','" + cli_telefono + "','" + cli_mail + "','" + cli_fecha_nac + "','" + cli_sexo + "','" + cli_discapacitado + "','" + condicion + "'";
            connect.execute_query_only(query);
        }

        public void insert_Cliente(string cli_dni, string cli_nombre, string cli_apellido, string cli_dir, string cli_telefono, string cli_mail, string cli_fecha_nac, string cli_sexo, string cli_discapacitado, string condicion)
        {
            query = "EXECUTE J2LA.insert_Cliente " + cli_dni + ",'" + cli_nombre + "','" + cli_apellido + "','" + cli_dir + "','" + cli_telefono + "','" + cli_mail + "','" + cli_fecha_nac + "','" + cli_sexo + "','" + cli_discapacitado + "','" + condicion + "'";
            connect.execute_query_only(query);
        }

        public string insert_compra(string comprador_dni, string tipo_tarj_id, string cant_pasajes, string cant_total_kg, decimal costo_total, DateTime fecha_actual)
        {
            Connection connect = new Connection();
            SqlConnection conexion = connect.connector();
            string query = "EXECUTE J2LA.insert_compra @comprador_dni, @tipo_tarj_id, @cant_pasajes, @cant_total_kg, @costo_total, @fecha_actual";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@comprador_dni", comprador_dni);
            comando.Parameters.AddWithValue("@tipo_tarj_id", tipo_tarj_id);
            comando.Parameters.AddWithValue("@cant_pasajes", cant_pasajes);
            comando.Parameters.AddWithValue("@cant_total_kg", cant_total_kg);
            comando.Parameters.AddWithValue("@costo_total", costo_total);
            comando.Parameters.AddWithValue("@fecha_actual", fecha_actual);
            string cod_compra = comando.ExecuteScalar().ToString();
            Singleton.conexion.connector().Close();
            return cod_compra;
        }

    }
}
