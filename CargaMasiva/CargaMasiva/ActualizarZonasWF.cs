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
    public partial class ActualizarZonasWF : Form
    {
        public ActualizarZonasWF()
        {
            InitializeComponent();
        }
        private void ActualizarZonasWF_Load(object sender, EventArgs e)
        {
            CargarComboZonas();
        }

        private void CargarComboZonas()
        {
            List<string> Personas = new List<string>();
            Personas = Dao.Zonas.CargarComboZonas();
            cmbZona.Items.Clear();
            cmbZona.Text = "Seleccione";
            cmbZona.Items.Add("Seleccione");
            foreach (string item in Personas)
            {
                cmbZona.Text = "Seleccione";
                cmbZona.Items.Add(item);
            }
        }
        private void Datos(string Zona)
        {
            //Obtenemos el archivo desde la ubicación actual
            var executableFolderPath = "C:\\Users\\limoli\\Desktop\\Pasos";

            //Hoja desde donde obtendremos los datos
            string hoja = Zona;
            //string hoja = "Hoja1";
            //Cadena de conexión
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + executableFolderPath +
                            "\\Escuelas--Editado.xlsx" +
                            ";Extended Properties='Excel 12.0;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(conexion);
            //Consulta contra la hoja de Excel
            OleDbCommand cmd = new OleDbCommand("Select * From [" + hoja + "$]", con);
            List<Entidades.Zonas> listaZonas = new List<Entidades.Zonas>();
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
                        Entidades.Zonas list = new Entidades.Zonas();
                        //list.idZona = item[0].ToString();                        
                        list.NroCircuito = item[0].ToString();
                        list.Nombre = item[1].ToString();
                        listaZonas.Add(list);
                    }
                }
                Lista = listaZonas;
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
        public static List<Entidades.Zonas> listaGuardar;
        public List<Entidades.Zonas> Lista
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

                    dataGridView1.Columns[0].HeaderText = "id Zona";
                    dataGridView1.Columns[0].Width = 130;
                    dataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[0].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[0].HeaderCell.Style.ForeColor = Color.White;
                    dataGridView1.Columns[0].Visible = false;

                    dataGridView1.Columns[1].HeaderText = "Nro.Circuito";
                    dataGridView1.Columns[1].Width = 100;
                    dataGridView1.Columns[1].HeaderCell.Style.BackColor = Color.DarkBlue;
                    dataGridView1.Columns[1].HeaderCell.Style.Font = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                    dataGridView1.Columns[1].HeaderCell.Style.ForeColor = Color.White;

                    dataGridView1.Columns[2].HeaderText = "Nombre Zona";
                    dataGridView1.Columns[2].Width = 200;
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Zona = cmbZona.Text;
            string var = Zona;
            var split1 = var.Split(',')[0];
            var split2 = var.Split(',')[1];
            split1 = split1.Trim();
            int idZona = Convert.ToInt32(split1);

            split2 = split2.Trim();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ProgressBar();
            TimeSpan tiempo = Cronometrar();
            int ContadorExito = Dao.Zonas.ActualizarIdZonas(listaGuardar, idZona);
            stopWatch.Stop();
            if (ContadorExito > 0)
            { MessageBox.Show("Se actualizaron '" + ContadorExito + "' escuelas exitosamente en un tiempo de = '" + stopWatch.Elapsed.ToString() + "'"); }
            else { MessageBox.Show("Fallo fijate que onda"); }
            LimpiarCampos();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InicioWF _inicio = new InicioWF();
            _inicio.Show();
            Hide();
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
        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (cmbZona.Text == "Seleccione")
            {
                MessageBox.Show("Debe seleccionar una Zona.");
            }
            else
            {
                string Zona = cmbZona.Text;
                string var = Zona;
                var split1 = var.Split(',')[0];
                var split2 = var.Split(',')[1];
                split1 = split1.Trim();
                split2 = split2.Trim();
                ProgressBar();
                btnCargar.Enabled = false;
                Datos(split2);
                LimpiarCampos();
            }
        }
        private void cmbZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCargar.Visible = true;
            btnCargar.Enabled = true;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
            InicioWF _inicio = new InicioWF();
            _inicio.Show();
            Hide();
        }
    }
}
