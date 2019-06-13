using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargaMasiva.Entidades;
using MySql.Data.MySqlClient;
using System.Data;


namespace CargaMasiva.Dao
{
    public class Listas
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool GuardarListas(List<TablaLista> listaGuardar)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            //foreach (var item in listaGuardar)
            //{
            for (int i = 0; i < listaGuardar.Count; i++)
            {
                string proceso = "AltaListas";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("numero_in", listaGuardar[i].numero);
                cmd.Parameters.AddWithValue("descripcion_in", listaGuardar[i].descripcion);
                cmd.Parameters.AddWithValue("color_in", listaGuardar[i].color);
                cmd.Parameters.AddWithValue("image_name_in", listaGuardar[i].image_name);
                cmd.Parameters.AddWithValue("updateAt_in", listaGuardar[i].updateAt);
                cmd.Parameters.AddWithValue("orden_id_in", listaGuardar[i].orden);
                cmd.ExecuteNonQuery();
            }
            exito = true;

            connection.Close();
            return exito;
        }
    }
}

