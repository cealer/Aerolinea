namespace aerolinea.Formularios
{
    partial class Persona
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdnNo = new System.Windows.Forms.RadioButton();
            this.rdnSi = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.mtbDNI = new System.Windows.Forms.MaskedTextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.mtbCelular = new System.Windows.Forms.MaskedTextBox();
            this.dtpNacimiento = new System.Windows.Forms.DateTimePicker();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxApe = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxNom1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tbxPersonaBuscar = new System.Windows.Forms.TextBox();
            this.cboPersonaBuscar = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(21, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 485);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.rdnNo);
            this.tabPage1.Controls.Add(this.rdnSi);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.mtbDNI);
            this.tabPage1.Controls.Add(this.cboTipo);
            this.tabPage1.Controls.Add(this.mtbCelular);
            this.tabPage1.Controls.Add(this.dtpNacimiento);
            this.tabPage1.Controls.Add(this.tbxEmail);
            this.tabPage1.Controls.Add(this.tbxApe);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnCancelar);
            this.tabPage1.Controls.Add(this.btnGuardar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbxNom1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::aerolinea.Properties.Resources.empleado_1186693;
            this.pictureBox1.Location = new System.Drawing.Point(378, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 438);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // rdnNo
            // 
            this.rdnNo.AutoSize = true;
            this.rdnNo.Location = new System.Drawing.Point(274, 305);
            this.rdnNo.Name = "rdnNo";
            this.rdnNo.Size = new System.Drawing.Size(39, 17);
            this.rdnNo.TabIndex = 36;
            this.rdnNo.TabStop = true;
            this.rdnNo.Text = "No";
            this.rdnNo.UseVisualStyleBackColor = true;
            this.rdnNo.CheckedChanged += new System.EventHandler(this.rdnNo_CheckedChanged);
            // 
            // rdnSi
            // 
            this.rdnSi.AutoSize = true;
            this.rdnSi.Location = new System.Drawing.Point(175, 305);
            this.rdnSi.Name = "rdnSi";
            this.rdnSi.Size = new System.Drawing.Size(34, 17);
            this.rdnSi.TabIndex = 35;
            this.rdnSi.TabStop = true;
            this.rdnSi.Text = "Si";
            this.rdnSi.UseVisualStyleBackColor = true;
            this.rdnSi.CheckedChanged += new System.EventHandler(this.rdnSi_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Privilegios";
            // 
            // mtbDNI
            // 
            this.mtbDNI.Location = new System.Drawing.Point(160, 93);
            this.mtbDNI.Mask = "99999999";
            this.mtbDNI.Name = "mtbDNI";
            this.mtbDNI.Size = new System.Drawing.Size(162, 20);
            this.mtbDNI.TabIndex = 2;
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(160, 245);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(162, 21);
            this.cboTipo.TabIndex = 6;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // mtbCelular
            // 
            this.mtbCelular.Location = new System.Drawing.Point(160, 170);
            this.mtbCelular.Mask = "999999999";
            this.mtbCelular.Name = "mtbCelular";
            this.mtbCelular.Size = new System.Drawing.Size(162, 20);
            this.mtbCelular.TabIndex = 4;
            // 
            // dtpNacimiento
            // 
            this.dtpNacimiento.CustomFormat = " ";
            this.dtpNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNacimiento.Location = new System.Drawing.Point(160, 134);
            this.dtpNacimiento.Name = "dtpNacimiento";
            this.dtpNacimiento.Size = new System.Drawing.Size(162, 20);
            this.dtpNacimiento.TabIndex = 3;
            this.dtpNacimiento.ValueChanged += new System.EventHandler(this.dtpNacimiento_ValueChanged);
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(160, 208);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(162, 20);
            this.tbxEmail.TabIndex = 5;
            // 
            // tbxApe
            // 
            this.tbxApe.Location = new System.Drawing.Point(161, 51);
            this.tbxApe.Name = "tbxApe";
            this.tbxApe.Size = new System.Drawing.Size(162, 20);
            this.tbxApe.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Tipo Persona";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Celular";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Fecha de nacimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "DNI";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(208, 367);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 56);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(66, 367);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 56);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Primer Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Apellidos";
            // 
            // tbxNom1
            // 
            this.tbxNom1.Location = new System.Drawing.Point(160, 15);
            this.tbxNom1.Name = "tbxNom1";
            this.tbxNom1.Size = new System.Drawing.Size(162, 20);
            this.tbxNom1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBuscar);
            this.tabPage2.Controls.Add(this.tbxPersonaBuscar);
            this.tabPage2.Controls.Add(this.cboPersonaBuscar);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.dgvLista);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(572, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tbxPersonaBuscar
            // 
            this.tbxPersonaBuscar.Location = new System.Drawing.Point(354, 40);
            this.tbxPersonaBuscar.Name = "tbxPersonaBuscar";
            this.tbxPersonaBuscar.Size = new System.Drawing.Size(157, 20);
            this.tbxPersonaBuscar.TabIndex = 7;
            // 
            // cboPersonaBuscar
            // 
            this.cboPersonaBuscar.FormattingEnabled = true;
            this.cboPersonaBuscar.Location = new System.Drawing.Point(193, 39);
            this.cboPersonaBuscar.Name = "cboPersonaBuscar";
            this.cboPersonaBuscar.Size = new System.Drawing.Size(121, 21);
            this.cboPersonaBuscar.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Campo a buscar: ";
            // 
            // dgvLista
            // 
            this.dgvLista.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLista.Location = new System.Drawing.Point(21, 91);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(767, 362);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.DoubleClick += new System.EventHandler(this.dgvLista_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 48);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(794, 459);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Salir";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Persona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(835, 531);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Persona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.Pasajero_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxNom1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.TextBox tbxApe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mtbCelular;
        private System.Windows.Forms.DateTimePicker dtpNacimiento;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.MaskedTextBox mtbDNI;
        private System.Windows.Forms.ComboBox cboPersonaBuscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox tbxPersonaBuscar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdnNo;
        private System.Windows.Forms.RadioButton rdnSi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
    }
}