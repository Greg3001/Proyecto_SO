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
using System.Security.Cryptography.X509Certificates;

namespace Proyecto_V1
{
    public partial class Interfaz : Form
    {
        Socket server;
        Thread atender;
        bool connected = false;
        bool log_in = false;
        bool sign_in = false;
        int contador = 0;
        string username;

        //VALORS PER RECORDAR-ME DE LES IP I PORTS
        //string IPaddloc = "192.168.56.102";
        //int puertoloc = 5055;
        //string IPaddshiv = "10.4.119.5";
        //int puertoshiv = 50085;
        //VALORS PER RECORDAR-ME DE LES IP I PORTS


        //DEFINIM UNA RUTA IP I PORT
        string IPadd = "10.4.119.5";
        int puerto = 50085;



        Image[] images = new Image[]
        {
            Image.FromFile("goku.png"),
            Image.FromFile("Frieza.png"),
            Image.FromFile("vegeta.png")
        };

        delegate void DelegadoParaPonerTexto(string texto);

        List<LogIn> formularios = new List<LogIn>();
        List<SignIn> formularios3 = new List<SignIn>();
        public Interfaz()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
                string[] verify;

                switch (codigo)
                {
                    case 1:  // SIGN IN

                        mensaje = trozos[1].Split('\0')[0];
                        verify = mensaje.Split(' ');
                        if (verify[0] == "Usuario")
                        {
                            username = verify[1];
                            log_in = true;
                        }
                        MessageBox.Show(mensaje);

                        break;

                    case 2:  //LOG IN

                        mensaje = trozos[1].Split('\0')[0];
                        verify = mensaje.Split(' ');
                        if (verify[0] == "Sesion")
                        {
                            username = verify[3].Split('.')[0];
                            sign_in = true;
                        }
                        MessageBox.Show(mensaje);
                        break;

                    case 3: //HISTORIAL
                        //FALTA PER FER, COM HO PASSEM A UN ALTRE FORM?
                        //HO FEM A LA MATEIXA INTERFAÇ COM LA LLISTA DE CONNECTATS??
                        break;

                    case 4:      // LLISTA DE CONNECTATS
                        CONNAMES.Visible = true;
                        int rowcount = Convert.ToInt32(trozos[1]);
                        CONNAMES.RowCount = rowcount;
                        CONNAMES.ColumnCount = 1;
                        int count = 0;
                        while( count < rowcount-1)
                        {
                            
                            CONNAMES.Rows[count].Cells[0].Value = trozos[count+2];
                            count++;
                        }
                        CONNAMES.Rows[count].Cells[0].Value = trozos[count+2].Split('\0')[0];
                        break;

                }
            }
        }
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
            CONNAMES.Visible = false;
            SELECT.Visible = false;
            NEXT.Visible = false;
            PREVIOUS.Visible = false;

            LabelIntro.Visible = false;
            pictureBox2.Visible = false;

            holi.Visible = true;
            holi.BackColor = Color.Red;

            connect.Location = new System.Drawing.Point(680, 500);
            connect.Location = new System.Drawing.Point(680, 500);
            disconnect.Visible = false;
            //historial.Visible = false;

            if (sign_in == true || log_in == true)
            {
                button2.Visible = false;
                button1.Visible = false;
                historial.Visible = true;
                CONNAMES.Visible = true;
                SELECT.Visible = true;
                NEXT.Visible = true;
                PREVIOUS.Visible = true;
                LabelIntro.Visible = true;
                pictureBox2.Visible = true;
                pictureBox1.Image = Image.FromFile("FONDO4.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = this.images[this.contador];
            }
            if (connected == true)
            {
                connect.Visible = false;
                disconnect.Visible = true;
                holi.BackColor = Color.Green;
            }

            if (connected == false)
            {
                disconnect.Visible = false;
                connect.Visible = true;
                holi.BackColor = Color.Red;
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
            disconnect.Visible = false;
            //connect.Visible = false;
            historial.Visible = false;
           
            holi.BackColor = Color.Green;
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
            MessageBox.Show("User disconnected successfully.");
            connected = false;
            if (connected == false)
            {
                disconnect.Visible = false;
                connect.Visible = true;
                holi.BackColor = Color.Red;
            }


        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            disconnect.Size = new Size((int)(button1.Width * 1.2f), (int)(button1.Height * 1.2f));
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            disconnect.Size = new Size((int)(button1.Width / 1.2f), (int)(button1.Height / 1.2f));
        }

        //CONECTAR CON EL SERVIDOR
        private void button4_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor ypuerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(IPadd);
            IPEndPoint ipep = new IPEndPoint(direc, puerto);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("User connected successfully.");
                //pongo en marcha el thread que atenderá los mensajes del servidor
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
                connected = true;
                if (connected == true)
                {
                    connect.Visible = false;
                    disconnect.Visible = true;
                    holi.BackColor = Color.Green;
                }

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
            LogIn f = new LogIn(cont, server);
            formularios.Add(f);
            f.ShowDialog();
        }
        private void PonerEnMarchaFormulario2()
        {
            int cont = formularios3.Count;
            SignIn f3 = new SignIn(cont, server);
            formularios3.Add(f3);
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form historial = new Historial(server, username);
            historial.Show();

        }
        private void PonerEnMarchaMinigame()
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void NEXT_Click(object sender, EventArgs e)
        {
            this.contador++;

            if (this.contador >= this.images.Length)
            {
                this.contador = 0;
            }

            this.pictureBox2.Image = this.images[this.contador];
        }

        private void PREVIOUS_Click(object sender, EventArgs e)
        {
            this.contador--;

            if (this.contador < 0)
            {
                this.contador = this.images.Length - 1;
            }

            this.pictureBox2.Image = this.images[this.contador];
        }

        private void disconnect_Enter(object sender, EventArgs e)
        {
            disconnect.Size = new Size((int)(disconnect.Width * 1.2f), (int)(disconnect.Height * 1.2f));
        }

        private void disconnect_Leave(object sender, EventArgs e)
        {
            disconnect.Size = new Size((int)(disconnect.Width / 1.2f), (int)(disconnect.Height / 1.2f));
        }
    }
}
