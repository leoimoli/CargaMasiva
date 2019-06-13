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
    public class Candidatos
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool GuardarCandidatos(List<TablaCandidatos> listaGuardar)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            //foreach (var item in listaGuardar)
            //{
            for (int i = 0; i < listaGuardar.Count; i++)
            {
                string proceso = "AltaCandidatos";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nombre_in", listaGuardar[i].nombre);
                cmd.Parameters.AddWithValue("apellido_in", listaGuardar[i].apellido);
                cmd.Parameters.AddWithValue("image_name_in", listaGuardar[i].image_name);
                cmd.Parameters.AddWithValue("lista_id_in", listaGuardar[i].lista_id);
                cmd.Parameters.AddWithValue("cargo_id_in", listaGuardar[i].cargo_id);
                cmd.Parameters.AddWithValue("listainterna_id_in", listaGuardar[i].listainterna_id);
                cmd.Parameters.AddWithValue("updated_at_in", listaGuardar[i].updated_at);
                cmd.ExecuteNonQuery();
            }
            exito = true;

            connection.Close();
            return exito;
        }
    }
}
