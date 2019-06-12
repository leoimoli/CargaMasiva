using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using CargaMasiva.Entidades;
using CargaMasiva.Dao;

namespace CargaMasiva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            btnCargar.Enabled = false;
            ProgressBar();
            Datos();
            LimpiarCampos();
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

        private void Datos()
        {
            //Obtenemos el archivo desde la ubicación actual
            var executableFolderPath = "C:\\Users\\limoli\\Desktop";

            //Hoja desde donde obtendremos los datos
            string hoja = "Hoja1";
            //Cadena de conexión
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + executableFolderPath +
                            "\\CargaMasiva.xlsx" +
                            ";Extended Properties='Excel 12.0;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(conexion);
            //Consulta contra la hoja de Excel
            OleDbCommand cmd = new OleDbCommand("Select * From [" + hoja + "$]", con);
            List<TablaVotos> listaVotos = new List<TablaVotos>();
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
                        TablaVotos list = new TablaVotos();
                        list.Votos = Convert.ToInt32(item[0].ToString());
                        list.Usuario = item[1].ToString();
                        list.createAt = Convert.ToDateTime(item[2].ToString());
                        list.updateAt = Convert.ToDateTime(item[3].ToString());
                        list.Visible = item[4].ToString();
                        list.Mesa_id = Convert.ToInt32(item[5].ToString());
                        list.Candidato_id = Convert.ToInt32(item[6].ToString());
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
        public static List<TablaVotos> listaGuardar;
        public List<TablaVotos> Lista
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

                    dataGridView1.Columns[0].HeaderText = "Votos";
                    dataGridView1.Columns[0].Width = 130;
                    dataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[0].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[0].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[1].HeaderText = "Usuario";
                    dataGridView1.Columns[1].Width = 100;
                    dataGridView1.Columns[1].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[1].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[1].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[2].HeaderText = "createAt";
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[2].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[2].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[2].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[3].HeaderText = "updateAt";
                    dataGridView1.Columns[3].Width = 150;
                    dataGridView1.Columns[3].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[3].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[3].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[4].HeaderText = "Visible";
                    dataGridView1.Columns[4].Width = 60;
                    dataGridView1.Columns[4].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[4].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[4].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[5].HeaderText = "Mesa Id";
                    dataGridView1.Columns[5].Width = 150;
                    dataGridView1.Columns[5].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[5].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[5].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[6].HeaderText = "Candidato Id";
                    dataGridView1.Columns[6].Width = 100;
                    dataGridView1.Columns[6].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[6].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[6].HeaderCell.Style.ForeColor = Color.White;
                }
                else { }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool exito = Votos.GuardarVotos(listaGuardar);
            ProgressBar();
            if (exito == true)
            { MessageBox.Show("Se registraron los votos exitosamente"); }
            else { MessageBox.Show("Fallo vijate que onda"); }
            LimpiarCampos();
        }
    }
}