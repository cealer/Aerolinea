namespace aerolinea.Formularios
{
    partial class Vuelo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarDestino = new System.Windows.Forms.Button();
            this.btnBuscarAvion = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOperacion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvVuelo = new System.Windows.Forms.DataGridView();
            this.lblAvion = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(535, 299);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblDestino);
            this.tabPage1.Controls.Add(this.lblAvion);
            this.tabPage1.Controls.Add(this.dtpSalida);
            this.tabPage1.Controls.Add(this.btnBuscarDestino);
            this.tabPage1.Controls.Add(this.btnBuscarAvion);
            this.tabPage1.Controls.Add(this.btnCancelar);
            this.tabPage1.Controls.Add(this.btnOperacion);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(527, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos vuelo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtpSalida
            // 
            this.dtpSalida.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSalida.Location = new System.Drawing.Point(136, 85);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(139, 20);
            this.dtpSalida.TabIndex = 10;
            // 
            // btnBuscarDestino
            // 
            this.btnBuscarDestino.Location = new System.Drawing.Point(317, 122);
            this.btnBuscarDestino.Name = "btnBuscarDestino";
            this.btnBuscarDestino.Size = new System.Drawing.Size(27, 23);
            this.btnBuscarDestino.TabIndex = 9;
            this.btnBuscarDestino.Text = "...";
            this.btnBuscarDestino.UseVisualStyleBackColor = true;
            this.btnBuscarDestino.Click += new System.EventHandler(this.btnBuscarDestino_Click);
            // 
            // btnBuscarAvion
            // 
            this.btnBuscarAvion.Location = new System.Drawing.Point(317, 46);
            this.btnBuscarAvion.Name = "btnBuscarAvion";
            this.btnBuscarAvion.Size = new System.Drawing.Size(27, 23);
            this.btnBuscarAvion.TabIndex = 8;
            this.btnBuscarAvion.Text = "...";
            this.btnBuscarAvion.UseVisualStyleBackColor = true;
            this.btnBuscarAvion.Click += new System.EventHandler(this.btnBuscarAvion_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(236, 201);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOperacion
            // 
            this.btnOperacion.Location = new System.Drawing.Point(134, 201);
            this.btnOperacion.Name = "btnOperacion";
            this.btnOperacion.Size = new System.Drawing.Size(76, 23);
            this.btnOperacion.TabIndex = 6;
            this.btnOperacion.Text = "Guardar";
            this.btnOperacion.UseVisualStyleBackColor = true;
            this.btnOperacion.Click += new System.EventHandler(this.btnOperacion_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Salida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Avion";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvVuelo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(527, 273);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista Vuelos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvVuelo
            // 
            this.dgvVuelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuelo.Location = new System.Drawing.Point(24, 26);
            this.dgvVuelo.Name = "dgvVuelo";
            this.dgvVuelo.RowHeadersVisible = false;
            this.dgvVuelo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVuelo.Size = new System.Drawing.Size(474, 225);
            this.dgvVuelo.TabIndex = 0;
            this.dgvVuelo.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVuelo_RowHeaderMouseDoubleClick);
            // 
            // lblAvion
            // 
            this.lblAvion.AutoSize = true;
            this.lblAvion.Location = new System.Drawing.Point(184, 46);
            this.lblAvion.Name = "lblAvion";
            this.lblAvion.Size = new System.Drawing.Size(42, 13);
            this.lblAvion.TabIndex = 11;
            this.lblAvion.Text = "Modelo";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(184, 132);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(43, 13);
            this.lblDestino.TabIndex = 12;
            this.lblDestino.Text = "Destino";
            // 
            // Vuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 323);
            this.Controls.Add(this.tabControl1);
            this.Name = "Vuelo";
            this.Text = "Vuelo";
            this.Load += new System.EventHandler(this.Vuelo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.Button btnBuscarDestino;
        private System.Windows.Forms.Button btnBuscarAvion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOperacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvVuelo;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblAvion;
    }
}