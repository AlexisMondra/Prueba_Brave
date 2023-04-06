using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Data_Brive
{
    public class DBrive
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);


        public DataTable Obtener()
        {

            SqlCommand com = new SqlCommand("SpObtener", conexion);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }

        public DataRow ObtenerId(int id)
        {
            SqlCommand com = new SqlCommand("SpObtenerId", conexion);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Id", id);


            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            return tabla.Rows[0];
        }

        public int Agregar(string Nomb, int CodBarr ,int canti, float precio,string suc)
        {
            SqlCommand com = new SqlCommand("SpAgregar", conexion);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Nombre", Nomb);
            com.Parameters.AddWithValue("@Codigo_Barras", CodBarr);
            com.Parameters.AddWithValue("@Cantidad", canti);
            com.Parameters.AddWithValue("@Precio_Uni", precio);
            com.Parameters.AddWithValue("@Sucursal", suc);

            try
            {
                conexion.Open();
                int fa = com.ExecuteNonQuery();
                conexion.Close();

                return fa;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

       
        public int Editar(int id, string Nomb, int CodBarr, int canti, float precio, string suc)
        {
            SqlCommand com = new SqlCommand("SpEditar", conexion);
            com.CommandType = CommandType.StoredProcedure;


            com.Parameters.AddWithValue("@Id", id);
            com.Parameters.AddWithValue("@Nombre", Nomb);
            com.Parameters.AddWithValue("@Codigo_Barras", CodBarr);
            com.Parameters.AddWithValue("@Cantidad", canti);
            com.Parameters.AddWithValue("@Precio_Uni", precio);
            com.Parameters.AddWithValue("@Sucursal", suc);
            try
            {
                conexion.Open();
                int filaAfectada = com.ExecuteNonQuery(); 
                conexion.Close();

                return filaAfectada;
            }
            catch (Exception)
            {
                conexion.Close();   
                throw;
            }
        }

        public int Eliminar(int id)
        {
            SqlCommand com = new SqlCommand("SpEliminar", conexion);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Id", id);

            try
            {
                conexion.Open();
                int filaAfectada = com.ExecuteNonQuery(); //correcto si tiene 1
                conexion.Close();

                return filaAfectada;
            }
            catch (Exception)
            {
                conexion.Close();   //incorrecto 0
                throw;
            }
        }

        public DataTable Buscar(string valor)
        {
            SqlCommand com = new SqlCommand("SpBuscar", conexion);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("valor", valor);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



       
    }
}
