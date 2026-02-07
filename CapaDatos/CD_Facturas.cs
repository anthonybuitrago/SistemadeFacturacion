using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Facturas
    {
        private Conexion conexion = new Conexion();

        public void Insertar(string num, string cliente, decimal monto, decimal itbis, decimal total)
        {
            SqlCommand comando = new SqlCommand("sp_InsertarFactura", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NumFactura", num);
            comando.Parameters.AddWithValue("@Cliente", cliente);
            comando.Parameters.AddWithValue("@Monto", monto);
            comando.Parameters.AddWithValue("@ITBIS", itbis);
            comando.Parameters.AddWithValue("@Total", total);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        public DataTable Listar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand("sp_ListarFacturasHoy", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter leer = new SqlDataAdapter(comando);
            leer.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Anular(string num)
        {
            SqlCommand comando = new SqlCommand("sp_AnularFactura", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NumFactura", num);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}