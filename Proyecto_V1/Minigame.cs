using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_V1
{
    public partial class Minigame : Form
    {
        int nForm;
        Socket server;
        public Minigame( Socket server)
        {
            InitializeComponent();
            
            this.server = server;
        }
        public void TomaRespuesta1(string mensaje)
        {
            MessageBox.Show(mensaje);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "3/" +  textBox1.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = "4/" +  textBox1.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mensaje = "5/" + textBox1.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Pedir numero de servicios realizados
            string mensaje = "6/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            ControlLbl.Text = mensaje;
        }
    }
}
