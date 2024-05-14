namespace Practica_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbPuertos = new ComboBox();
            lblTitulo = new Label();
            lblPuerto = new Label();
            btnConexion = new Button();
            txtMensaje = new TextBox();
            btnEnviar = new Button();
            btnReiniciar = new Button();
            SuspendLayout();
            // 
            // cmbPuertos
            // 
            cmbPuertos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPuertos.FormattingEnabled = true;
            cmbPuertos.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13" });
            cmbPuertos.Location = new Point(230, 134);
            cmbPuertos.MaxLength = 10;
            cmbPuertos.Name = "cmbPuertos";
            cmbPuertos.Size = new Size(178, 28);
            cmbPuertos.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(98, 54);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(636, 54);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Demostración de conexión serial";
            // 
            // lblPuerto
            // 
            lblPuerto.AutoSize = true;
            lblPuerto.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPuerto.Location = new Point(98, 134);
            lblPuerto.Name = "lblPuerto";
            lblPuerto.Size = new Size(74, 28);
            lblPuerto.TabIndex = 2;
            lblPuerto.Text = "Puerto";
            // 
            // btnConexion
            // 
            btnConexion.Location = new Point(462, 134);
            btnConexion.Name = "btnConexion";
            btnConexion.Size = new Size(123, 29);
            btnConexion.TabIndex = 3;
            btnConexion.Text = "Conectarse";
            btnConexion.UseVisualStyleBackColor = true;
            btnConexion.Click += btnConexion_Click;
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(230, 229);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.PlaceholderText = "Ingresa tu mensaje a enviar";
            txtMensaje.Size = new Size(355, 27);
            txtMensaje.TabIndex = 4;
            txtMensaje.TextChanged += txtMensaje_TextChanged;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(230, 287);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(123, 29);
            btnEnviar.TabIndex = 5;
            btnEnviar.Text = "Enviar mensaje";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Location = new Point(462, 287);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(123, 29);
            btnReiniciar.TabIndex = 6;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReiniciar);
            Controls.Add(btnEnviar);
            Controls.Add(txtMensaje);
            Controls.Add(btnConexion);
            Controls.Add(lblPuerto);
            Controls.Add(lblTitulo);
            Controls.Add(cmbPuertos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPuertos;
        private Label lblTitulo;
        private Label lblPuerto;
        private Button btnConexion;
        private TextBox txtMensaje;
        private Button btnEnviar;
        private Button btnReiniciar;
    }
}