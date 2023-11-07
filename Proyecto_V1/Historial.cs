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
    public partial class Historial : Form
    {
        Socket server;
        string username;
        public Historial(Socket server, string username)
        {
            InitializeComponent();
            this.server = server;
            this.username = username;
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            string mensaje = "3/" + username + "/" + "holi :3";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            


        }
    }
}
