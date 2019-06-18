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
    public class Votos
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static bool GuardarVotos(List<TablaVotos> listaGuardar)
        {
            bool exito = false;
            connection.Close();
            connection.Open();
            //foreach (var item in listaGuardar)
            //{
            for (int i = 0; i < listaGuardar.Count; i++)
            {
                string proceso = "AltaVotos";
                MySqlCommand cmd = new MySqlCommand(proceso, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Votos_in", listaGuardar[i].Votos);
                cmd.Parameters.AddWithValue("Usuario_in", listaGuardar[i].Usuario);
                cmd.Parameters.AddWithValue("createAt_in", listaGuardar[i].createAt);
                cmd.Parameters.AddWithValue("updateAt_in", listaGuardar[i].updateAt);
                cmd.Parameters.AddWithValue("Visible_in", listaGuardar[i].Visible);
                cmd.Parameters.AddWithValue("Mesa_id_in", listaGuardar[i].Mesa_id);
                cmd.Parameters.AddWithValue("Candidato_id_in", listaGuardar[i].Candidato_id);
                cmd.ExecuteNonQuery();
            }
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
