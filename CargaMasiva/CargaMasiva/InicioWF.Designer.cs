namespace CargaMasiva
{
    partial class InicioWF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioWF));
            this.btnCargarLista = new System.Windows.Forms.Button();
            this.btnListasInternas = new System.Windows.Forms.Button();
            this.btnCandidatos = new System.Windows.Forms.Button();
            this.btnVotos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCargarLista
            // 
            this.btnCargarLista.Location = new System.Drawing.Point(382, 165);
            this.btnCargarLista.Name = "btnCargarLista";
            this.btnCargarLista.Size = new System.Drawing.Size(154, 60);
            this.btnCargarLista.TabIndex = 0;
            this.btnCargarLista.Text = "Cargar Lista";
            this.btnCargarLista.UseVisualStyleBackColor = true;
            this.btnCargarLista.Click += new System.EventHandler(this.btnCargarLista_Click);
            // 
            // btnListasInternas
            // 
            this.btnListasInternas.Location = new System.Drawing.Point(595, 165);
            this.btnListasInternas.Name = "btnListasInternas";
            this.btnListasInternas.Size = new System.Drawing.Size(154, 60);
            this.btnListasInternas.TabIndex = 1;
            this.btnListasInternas.Text = "Cargar Listas Internas";
            this.btnListasInternas.UseVisualStyleBackColor = true;
            this.btnListasInternas.Click += new System.EventHandler(this.btnListasInternas_Click);
            // 
            // btnCandidatos
            // 
            this.btnCandidatos.Location = new System.Drawing.Point(382, 278);
            this.btnCandidatos.Name = "btnCandidatos";
            this.btnCandidatos.Size = new System.Drawing.Size(154, 60);
            this.btnCandidatos.TabIndex = 2;
            this.btnCandidatos.Text = "Cargar Candidatos";
            this.btnCandidatos.UseVisualStyleBackColor = true;
            this.btnCandidatos.Click += new System.EventHandler(this.btnCandidatos_Click);
            // 
            // btnVotos
            // 
            this.btnVotos.Location = new System.Drawing.Point(595, 278);
            this.btnVotos.Name = "btnVotos";
            this.btnVotos.Size = new System.Drawing.Size(154, 60);
            this.btnVotos.TabIndex = 3;
            this.btnVotos.Text = "Cargar Votos";
            this.btnVotos.UseVisualStyleBackColor = true;
            this.btnVotos.Click += new System.EventHandler(this.btnVotos_Click);
            // 
            // InicioWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 654);
            this.Controls.Add(this.btnVotos);
            this.Controls.Add(this.btnCandidatos);
            this.Controls.Add(this.btnListasInternas);
            this.Controls.Add(this.btnCargarLista);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InicioWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCargarLista;
        private System.Windows.Forms.Button btnListasInternas;
        private System.Windows.Forms.Button btnCandidatos;
        private System.Windows.Forms.Button btnVotos;
    }
}