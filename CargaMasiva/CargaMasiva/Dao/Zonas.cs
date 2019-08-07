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
    public class Zonas
    {
        private static MySql.Data.MySqlClient.MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.db);
        public static List<string> CargarComboZonas()
        {
            List<string> _listaZonas = new List<string>();
            connection.Close();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            DataTable Tabla = new DataTable();
            MySqlParameter[] oParam = { new MySqlParameter() };
            string proceso = "CargarComboZonas";
            MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.SelectCommand.Parameters.AddRange(oParam);
            dt.Fill(Tabla);
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow item in Tabla.Rows)
                {
                    _listaZonas.Add(item["idZona"].ToString() + "," + item["NombreZona"].ToString());
                }
            }
            connection.Close();
            return _listaZonas;
        }

        public static int ActualizarIdZonas(List<Entidades.Zonas> listaGuardar, int idZona)
        {
            int contador = 0;
            connection.Close();
            connection.Open();
            foreach (var item in listaGuardar)
            {
                string Actualizar = "ActualizarIdZonas";
                MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idZona_in", idZona);
                cmd.Parameters.AddWithValue("NroCircuito_in", item.NroCircuito);
                cmd.Parameters.AddWithValue("NombreZona_in", item.Nombre);
                cmd.ExecuteNonQuery();
                contador = contador + 1;
            }
            connection.Close();
            return contador;
        }
    }
}
