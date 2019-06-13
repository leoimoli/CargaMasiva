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
            this.btnCargarLista = new System.Windows.Forms.Button();
            this.btnListasInternas = new System.Windows.Forms.Button();
            this.btnCandidatos = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnVotos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCargarLista
            // 
            this.btnCargarLista.Location = new System.Drawing.Point(258, 138);
            this.btnCargarLista.Name = "btnCargarLista";
            this.btnCargarLista.Size = new System.Drawing.Size(154, 60);
            this.btnCargarLista.TabIndex = 0;
            this.btnCargarLista.Text = "Cargar Lista";
            this.btnCargarLista.UseVisualStyleBackColor = true;
            this.btnCargarLista.Click += new System.EventHandler(this.btnCargarLista_Click);
            // 
            // btnListasInternas
            // 
            this.btnListasInternas.Location = new System.Drawing.Point(471, 138);
            this.btnListasInternas.Name = "btnListasInternas";
            this.btnListasInternas.Size = new System.Drawing.Size(154, 60);
            this.btnListasInternas.TabIndex = 1;
            this.btnListasInternas.Text = "Cargar Listas Internas";
            this.btnListasInternas.UseVisualStyleBackColor = true;
            this.btnListasInternas.Click += new System.EventHandler(this.btnListasInternas_Click);
            // 
            // btnCandidatos
            // 
            this.btnCandidatos.Location = new System.Drawing.Point(672, 138);
            this.btnCandidatos.Name = "btnCandidatos";
            this.btnCandidatos.Size = new System.Drawing.Size(154, 60);
            this.btnCandidatos.TabIndex = 2;
            this.btnCandidatos.Text = "Cargar Candidatos";
            this.btnCandidatos.UseVisualStyleBackColor = true;
            this.btnCandidatos.Click += new System.EventHandler(this.btnCandidatos_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(672, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 60);
            this.button3.TabIndex = 5;
            this.button3.Text = "Cargar Candidatos";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(471, 257);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 60);
            this.button4.TabIndex = 4;
            this.button4.Text = "Cargar Listas Internas";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnVotos
            // 
            this.btnVotos.Location = new System.Drawing.Point(258, 257);
            this.btnVotos.Name = "btnVotos";
            this.btnVotos.Size = new System.Drawing.Size(154, 60);
            this.btnVotos.TabIndex = 3;
            this.btnVotos.Text = "Cargar Votos";
            this.btnVotos.UseVisualStyleBackColor = true;
            // 
            // InicioWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 654);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnVotos);
            this.Controls.Add(this.btnCandidatos);
            this.Controls.Add(this.btnListasInternas);
            this.Controls.Add(this.btnCargarLista);
            this.Name = "InicioWF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InicioWF";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCargarLista;
        private System.Windows.Forms.Button btnListasInternas;
        private System.Windows.Forms.Button btnCandidatos;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnVotos;
    }
}