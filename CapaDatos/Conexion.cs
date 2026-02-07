using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        private SqlConnection conexion = new SqlConnection("Server=.;Database=TiendaEconomica;Integrated Security=True");

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}