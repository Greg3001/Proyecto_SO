using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Proyecto_V1
{
    public partial class Form3 : Form
    {
        int nForm;
        Socket server;
        public Form3(int nForm, Socket server)
        {
            InitializeComponent();
            this.nForm = nForm;
            this.server = server;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Set the form's border style to FixedSingle.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.Size = new Size(1280, 720);
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = true;

            // Create an Image object.
            Image image = Image.FromFile("FONDO3.png");

            // Display the image.
            pictureBox1.Image = image;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void TomaRespuesta2(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + nForm + "/" + textBox1.Text + "/" + textBox2.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
