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
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.Media;

namespace Proyecto_V1
{
    public partial class Interfaz : Form
    {
        Socket server;
        Thread atender;
        bool connected;
        bool log_in;
        bool sign_in;
        int contador = 0;

        Image[] images = new Image[]
        {
            Image.FromFile("goku.png"),
            Image.FromFile("Frieza.png"),
            Image.FromFile("vegeta.png")
        };

        string[] names = new string[] { "Goku", "Freezer", "Vegeta" };


        delegate void DelegadoParaPonerTexto(string texto);

        List<Form2> formularios = new List<Form2>();
        List<Form3> formularios3 = new List<Form3>();
        public Interfaz()
        {
            InitializeComponent();
        }
        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje;

                int nform;
                switch (codigo)
                {
                    case 1:  // SIGN IN

                        nform = Convert.ToInt32(trozos[1]);
                        mensaje = trozos[2].Split('\0')[0];
                        formularios[nform].TomaRespuesta1(mensaje);

                        break;
                    case 2:      // LOG IN

                        nform = Convert.ToInt32(trozos[1]);
                        mensaje = trozos[2].Split('\0')[0];
                        formularios3[nform].TomaRespuesta2(mensaje);

                        break;

                    case 3:      // LOG IN

                        mensaje = trozos[2].Split('\0')[0];
                        MessageBox.Show(mensaje);

                        break;
                    case 4:      // LOG IN

                        mensaje = trozos[2].Split('\0')[0];
                        MessageBox.Show(mensaje);

                        break;
                    case 5:      // LOG IN

                        mensaje = trozos[2].Split('\0')[0];
                        MessageBox.Show(mensaje);

                        break;
                    case 6:      // LOG IN

                        mensaje = trozos[2].Split('\0')[0];
                        MessageBox.Show(mensaje);

                        break;

                }
            }
        }

        //LOAD CON UNA IMAGEN DE FONDO (SE PODRIA HACER A PANTALLA COMPLETA)

        public void Form1_Load(object sender, EventArgs e)
        {

            // Set the form's border style to FixedSingle.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //this.Size = new Size(1280, 720);
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = true;
           
            // Create an Image object.
            Image image = Image.FromFile("FONDO.png");

            // Display the image.
            pictureBox1.Image = image;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            SELECT.Visible = false;
            NEXT.Visible = false;
            PREVIOUS.Visible = false;
            LabelIntro.Visible = false;
            pictureBox2.Visible = false;
            Nombre.Visible = false;

            if (sign_in == true || log_in ==true)
            {
                SELECT.Visible = true;
                NEXT.Visible = true;
                PREVIOUS.Visible = true;
                LabelIntro.Visible = true;
                pictureBox2.Visible = true;
                Nombre.Visible = true;
                Nombre.Text = this.names[this.contador];
                Nombre.BackColor = Color.Empty;
                pictureBox1.Image = Image.FromFile("FONDO4.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = this.images[this.contador];
            } 
        }

        //BOTON1
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate { PonerEnMarchaFormulario(); };
            Thread T = new Thread(ts);
            T.Start();

            //pictureBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            LabelCont.Visible = false;
            sign_in = true;
    }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Size = new Size((int)(button1.Width * 1.2f), (int)(button1.Height * 1.2f));
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new Size((int)(button1.Width / 1.2f), (int)(button1.Height / 1.2f));
        }


        //BOTON2
        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate { PonerEnMarchaFormulario2(); };
            Thread T = new Thread(ts);
            T.Start();
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Size = new Size((int)(button1.Width * 1.2f), (int)(button1.Height * 1.2f));
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Size = new Size((int)(button1.Width / 1.2f), (int)(button1.Height / 1.2f));
        }


        //DESCONECTAR
        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Size = new Size((int)(button1.Width * 1.2f), (int)(button1.Height * 1.2f));
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Size = new Size((int)(button1.Width / 1.2f), (int)(button1.Height / 1.2f));
        }

        //CONECTAR CON EL SERVIDOR
        private void button4_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor ypuerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9070);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
                connected = true;

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button2.Size = new Size((int)(button1.Width * 1.2f), (int)(button1.Height * 1.2f));
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button2.Size = new Size((int)(button1.Width / 1.2f), (int)(button1.Height / 1.2f));
        }

        private void PonerEnMarchaFormulario()
        {
            int cont = formularios.Count;
            Form2 f = new Form2(cont, server);
            formularios.Add(f);
            f.ShowDialog();
        }
        private void PonerEnMarchaFormulario2()
        {
            int cont = formularios3.Count;
            Form3 f3 = new Form3(cont, server);
            formularios3.Add(f3);
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form historial = new Historial();
            historial.Show();

        }
        private void PonerEnMarchaMinigame()
        {
            Form minigame = new Minigame(server);

            minigame.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate { PonerEnMarchaMinigame(); };
            Thread T = new Thread(ts);
            T.Start();
        }

        private void NEXT_Click(object sender, EventArgs e)
        {
            this.contador++;

            if (this.contador >= this.images.Length)
            {
                this.contador = 0;
            }

            Nombre.Text = this.names[this.contador];
            Nombre.BackColor = Color.Empty;
            this.pictureBox2.Image = this.images[this.contador];
            this.pictureBox2.BackColor = Color.Black;
            this.pictureBox2.Parent = this.pictureBox1;
        }

        private void PREVIOUS_Click(object sender, EventArgs e)
        {
            this.contador--;

            if (this.contador < 0)
            {
                this.contador = this.images.Length - 1;
            }
            Nombre.Text = this.names[this.contador];
            Nombre.BackColor = Color.Empty;
            this.pictureBox2.Image = this.images[this.contador];
            this.pictureBox2.BackColor = Color.Black;
            this.pictureBox2.Parent = this.pictureBox1;
        }
    }
}
