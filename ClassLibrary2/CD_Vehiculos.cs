using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Vehiculos
    {

        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrarVehiculos()
        {
            string QryMostrarVehiculos = "usp_vehiculos_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarVehiculos, db_conexion.MtdAbrirConexion());
            DataTable dtMostrarVehiculos = new DataTable();
            adapter.Fill(dtMostrarVehiculos);
            db_conexion.MtdCerrarConexion();
            return dtMostrarVehiculos;
        }

        // Capa datos
        public void CP_mtdAgregarVehiculos(string Marca, string Modelo, int Año, decimal precio, string Estado)
        {

            string Usp_crear = "usp_vehiculos_crear";
            SqlCommand cmd_InsertarVehiculos= new SqlCommand(Usp_crear, db_conexion.MtdAbrirConexion());
            cmd_InsertarVehiculos.CommandType = CommandType.StoredProcedure;

            cmd_InsertarVehiculos.Parameters.AddWithValue("@Marca", Marca);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Modelo", Modelo);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Año", Año);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@precio", precio);
            cmd_InsertarVehiculos.Parameters.AddWithValue("@Estado", Estado);
            cmd_InsertarVehiculos.ExecuteNonQuery();
        }
        public int CP_mtdActualizarVehiculos(int VehiculoID, string Marca, string Modelo, int Año, decimal precio, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            string vUspActualizarVehiculos = "usp_vehiculos_editar";
            SqlCommand commActualizarVehiculos = new SqlCommand(vUspActualizarVehiculos, db_conexion.MtdAbrirConexion());
            commActualizarVehiculos.CommandType = CommandType.StoredProcedure;

            commActualizarVehiculos.Parameters.AddWithValue("@VehiculoID",VehiculoID);
            commActualizarVehiculos.Parameters.AddWithValue("@Marca", Marca);
            commActualizarVehiculos.Parameters.AddWithValue("@Modelo", Modelo);
            commActualizarVehiculos.Parameters.AddWithValue("@Año", Año);
            commActualizarVehiculos.Parameters.AddWithValue("@precio", precio);
            commActualizarVehiculos.Parameters.AddWithValue("@Estado", Estado);

            vContarRegistrosAfectados = commActualizarVehiculos.ExecuteNonQuery();
            return vContarRegistrosAfectados;
        }

        public int CP_mtdEliminarVehiculos(int VehiculoID)
        {
            int vCantidadRegistrosEliminados = 0;

            string vUspEliminarVehiculos= "usp_vehiculos_eliminar";
            SqlCommand commEliminarVehiculos = new SqlCommand(vUspEliminarVehiculos, db_conexion.MtdAbrirConexion());
            commEliminarVehiculos.CommandType = CommandType.StoredProcedure;

            commEliminarVehiculos.Parameters.AddWithValue("@VehiculoID", VehiculoID);

            vCantidadRegistrosEliminados = commEliminarVehiculos.ExecuteNonQuery();
            return vCantidadRegistrosEliminados;
        }
    }
}
