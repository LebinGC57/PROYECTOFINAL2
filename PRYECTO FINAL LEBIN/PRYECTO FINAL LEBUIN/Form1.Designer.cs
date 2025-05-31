namespace AsistenteAgricolaClima
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.TextBox txtCultivo;
        private System.Windows.Forms.Button btnConsultarClima;
        private System.Windows.Forms.Button btnConsultarCultivo;
        private System.Windows.Forms.ListBox listBoxClima;
        private System.Windows.Forms.ListBox listBoxCultivo;

        private void InitializeComponent()
        {
            txtCiudad = new TextBox();
            txtCultivo = new TextBox();
            btnConsultarClima = new Button();
            btnConsultarCultivo = new Button();
            listBoxClima = new ListBox();
            listBoxCultivo = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(30, 72);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(575, 27);
            txtCiudad.TabIndex = 0;
            // 
            // txtCultivo
            // 
            txtCultivo.Location = new Point(21, 148);
            txtCultivo.Name = "txtCultivo";
            txtCultivo.Size = new Size(575, 27);
            txtCultivo.TabIndex = 1;
            // 
            // btnConsultarClima
            // 
            btnConsultarClima.Location = new Point(30, 105);
            btnConsultarClima.Name = "btnConsultarClima";
            btnConsultarClima.Size = new Size(271, 25);
            btnConsultarClima.TabIndex = 2;
            btnConsultarClima.Text = "Consultar Pronostico del clima";
            btnConsultarClima.Click += btnConsultarClima_Click;
            // 
            // btnConsultarCultivo
            // 
            btnConsultarCultivo.Location = new Point(30, 181);
            btnConsultarCultivo.Name = "btnConsultarCultivo";
            btnConsultarCultivo.Size = new Size(271, 25);
            btnConsultarCultivo.TabIndex = 3;
            btnConsultarCultivo.Text = "Consultar Pronostico para el Cultivo";
            btnConsultarCultivo.Click += btnConsultarCultivo_Click;
            // 
            // listBoxClima
            // 
            listBoxClima.Location = new Point(30, 246);
            listBoxClima.Name = "listBoxClima";
            listBoxClima.Size = new Size(639, 204);
            listBoxClima.TabIndex = 4;
            // 
            // listBoxCultivo
            // 
            listBoxCultivo.Location = new Point(30, 473);
            listBoxCultivo.Name = "listBoxCultivo";
            listBoxCultivo.Size = new Size(639, 244);
            listBoxCultivo.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 33);
            label1.Name = "label1";
            label1.Size = new Size(600, 20);
            label1.TabIndex = 6;
            label1.Text = "Hola amigo agricultor, ¿en qué te puedo ayudar hoy respecto a tus dudas sobre el clima?";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(681, 720);
            Controls.Add(label1);
            Controls.Add(txtCiudad);
            Controls.Add(txtCultivo);
            Controls.Add(btnConsultarClima);
            Controls.Add(btnConsultarCultivo);
            Controls.Add(listBoxClima);
            Controls.Add(listBoxCultivo);
            Name = "Form1";
            Text = "Asistente Agrícola Inteligente";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
    }
}
