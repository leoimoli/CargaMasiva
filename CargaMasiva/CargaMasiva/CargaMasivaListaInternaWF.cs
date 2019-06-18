using CargaMasiva.Dao;
using CargaMasiva.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaMasiva
{
    public partial class CargaMasivaListaInternaWF : Form
    {
        public CargaMasivaListaInternaWF()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            ProgressBar();
            btnCargar.Enabled = false;
            Datos();
            LimpiarCampos();
        }
        private void Datos()
        {
            //Obtenemos el archivo desde la ubicación actual
            var executableFolderPath = "C:\\Users\\limoli\\Desktop\\Leo\\Carga Masiva";

            //Hoja desde donde obtendremos los datos
            string hoja = "Hoja2";
            //Cadena de conexión
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + executableFolderPath +
                            "\\Carga Masiva Listas.xlsx" +
                            ";Extended Properties='Excel 12.0;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(conexion);
            //Consulta contra la hoja de Excel
            OleDbCommand cmd = new OleDbCommand("Select * From [" + hoja + "$]", con);
            List<TablaListaInterna> listaVotos = new List<TablaListaInterna>();
            try
            {
                //Conectarse al archivo de Excel
                con.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                DataTable data = new DataTable();
                //Cargar los datos
                sda.Fill(data);
                //Cargar la grilla
                if (data.Rows.Count > 0)
                {
                    foreach (DataRow item in data.Rows)
                    {
                        TablaListaInterna list = new TablaListaInterna();
                        list.numero = item[0].ToString();
                        list.descripcion = item[1].ToString();
                        list.lista_id = Convert.ToInt32(item[2].ToString());
                        listaVotos.Add(list);
                    }
                }
                Lista = listaVotos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la lectura del archivo");
            }
            finally
            {
                //Funcione o no, cerramos la cadena de conexión
                con.Close();

            }

        }
        public static List<TablaListaInterna> listaGuardar;
        public List<TablaListaInterna> Lista
        {
            set
            {
                if (value.Count > 0)
                {
                    dataGridView1.DataSource = value;
                    label1.Visible = true;
                    label2.Visible = true;
                    label2.Text = Convert.ToString(value.Count);
                    btnCargar.Visible = false;
                    btnGuardar.Visible = true;
                    listaGuardar = value;

                    dataGridView1.Columns[0].HeaderText = "Numero";
                    dataGridView1.Columns[0].Width = 130;
                    dataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[0].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[0].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[1].HeaderText = "Descripcion";
                    dataGridView1.Columns[1].Width = 100;
                    dataGridView1.Columns[1].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[1].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[1].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[2].HeaderText = "Lista Id";
                    dataGridView1.Columns[2].Width = 80;
                    dataGridView1.Columns[2].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[2].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[2].HeaderCell.Style.ForeColor = Color.White;
                }
                else { }
            }
        }
        private void LimpiarCampos()
        {
            progressBar1.Value = Convert.ToInt32(null);
            progressBar1.Visible = false;
        }
        private void ProgressBar()
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 100000;
            progressBar1.Step = 1;

            for (int j = 0; j < 100000; j++)
            {
                Caluculate(j);
                progressBar1.PerformStep();
            }
        }
        private void Caluculate(int i)
        {
            double pow = Math.Pow(i, i);
        }
        private TimeSpan Cronometrar()
        {
            //Guarda la hora justo antes del proceso a cronometrar
            DateTime tiempo1 = DateTime.Now;
            //Guarda la hora al finalizar
            DateTime tiempo2 = DateTime.Now;
            //Crea un "intervalo temporal"
            TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            return total;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ProgressBar();
            TimeSpan tiempo = Cronometrar();
            bool exito = ListasInternas.GuardarListasInternas(listaGuardar);
            stopWatch.Stop();
            if (exito == true)
            { MessageBox.Show("Se registraron las listas internas exitosamente en un tiempo de = '" + stopWatch.Elapsed.ToString() + "'"); }
            else { MessageBox.Show("Fallo fijate que onda"); }
            LimpiarCampos();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InicioWF _inicio = new InicioWF();
            _inicio.Show();
            Hide();
        }
    }
}
