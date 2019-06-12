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
            string proceso = "AltaVotos";
            MySqlCommand cmd = new MySqlCommand(proceso, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (var item in listaGuardar)
            {
                cmd.Parameters.AddWithValue("Votos_in", item.Votos);
                cmd.Parameters.AddWithValue("Usuario_in", item.Usuario);
                cmd.Parameters.AddWithValue("createAt_in", item.createAt);
                cmd.Parameters.AddWithValue("updateAt_in", item.updateAt);
                cmd.Parameters.AddWithValue("Visible_in", item.Visible);
                cmd.Parameters.AddWithValue("Mesa_id_in", item.Mesa_id);
                cmd.Parameters.AddWithValue("Candidato_id_in", item.Candidato_id);
                cmd.ExecuteNonQuery();

            }
            exito = true;
            connection.Close();
            return exito;
        }
    }
}
