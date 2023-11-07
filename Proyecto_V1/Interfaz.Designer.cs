namespace Proyecto_V1
{
    partial class Interfaz
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.holi = new System.Windows.Forms.Label();
            this.historial = new System.Windows.Forms.Button();
            this.SELECT = new System.Windows.Forms.Button();
            this.NEXT = new System.Windows.Forms.Button();
            this.PREVIOUS = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LabelIntro = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CONNAMES = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CONNAMES)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.LightSalmon;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.Location = new System.Drawing.Point(1289, 597);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 80);
            this.button1.TabIndex = 1;
            this.button1.Text = "LOG IN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.AutoSizeChanged += new System.EventHandler(this.Form1_Load);
            this.button1.FontChanged += new System.EventHandler(this.Form1_Load);
            this.button1.LocationChanged += new System.EventHandler(this.Form1_Load);
            this.button1.TextChanged += new System.EventHandler(this.Form1_Load);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.Move += new System.EventHandler(this.Form1_Load);
            this.button1.Resize += new System.EventHandler(this.Form1_Load);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Coral;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button2.Location = new System.Drawing.Point(720, 597);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 80);
            this.button2.TabIndex = 2;
            this.button2.Text = "SIGN IN";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.FontChanged += new System.EventHandler(this.Form1_Load);
            this.button2.LocationChanged += new System.EventHandler(this.Form1_Load);
            this.button2.TextChanged += new System.EventHandler(this.Form1_Load);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // disconnect
            // 
            this.disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnect.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold);
            this.disconnect.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.disconnect.Location = new System.Drawing.Point(1570, 776);
            this.disconnect.Margin = new System.Windows.Forms.Padding(2);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(248, 54);
            this.disconnect.TabIndex = 3;
            this.disconnect.Text = "DESCONECTAR";
            this.disconnect.UseVisualStyleBackColor = false;
            this.disconnect.FontChanged += new System.EventHandler(this.Form1_Load);
            this.disconnect.LocationChanged += new System.EventHandler(this.Form1_Load);
            this.disconnect.TabStopChanged += new System.EventHandler(this.Form1_Load);
            this.disconnect.Click += new System.EventHandler(this.button3_Click);
            this.disconnect.Enter += new System.EventHandler(this.disconnect_Enter);
            this.disconnect.Leave += new System.EventHandler(this.disconnect_Leave);
            this.disconnect.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.disconnect.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // connect
            // 
            this.connect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.connect.AutoSize = true;
            this.connect.BackColor = System.Drawing.Color.Aquamarine;
            this.connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.connect.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.connect.Location = new System.Drawing.Point(1003, 814);
            this.connect.Margin = new System.Windows.Forms.Padding(2);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(236, 70);
            this.connect.TabIndex = 4;
            this.connect.Text = "CONECTAR";
            this.connect.UseVisualStyleBackColor = false;
            this.connect.Click += new System.EventHandler(this.button4_Click);
            // 
            // holi
            // 
            this.holi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.holi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.holi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holi.Location = new System.Drawing.Point(22, 17);
            this.holi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.holi.Name = "holi";
            this.holi.Size = new System.Drawing.Size(92, 79);
            this.holi.TabIndex = 14;
            // 
            // historial
            // 
            this.historial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.historial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historial.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historial.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.historial.Location = new System.Drawing.Point(1302, 507);
            this.historial.Name = "historial";
            this.historial.Size = new System.Drawing.Size(264, 69);
            this.historial.TabIndex = 15;
            this.historial.Text = "HISTORIAL";
            this.historial.UseVisualStyleBackColor = false;
            this.historial.Click += new System.EventHandler(this.button5_Click);
            // 
            // SELECT
            // 
            this.SELECT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SELECT.BackColor = System.Drawing.Color.Coral;
            this.SELECT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SELECT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SELECT.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.SELECT.ForeColor = System.Drawing.SystemColors.MenuText;
            this.SELECT.Location = new System.Drawing.Point(862, 706);
            this.SELECT.Margin = new System.Windows.Forms.Padding(2);
            this.SELECT.Name = "SELECT";
            this.SELECT.Size = new System.Drawing.Size(225, 80);
            this.SELECT.TabIndex = 17;
            this.SELECT.Text = "SELECT";
            this.SELECT.UseVisualStyleBackColor = false;
            // 
            // NEXT
            // 
            this.NEXT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NEXT.BackColor = System.Drawing.Color.Coral;
            this.NEXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NEXT.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.NEXT.ForeColor = System.Drawing.SystemColors.MenuText;
            this.NEXT.Location = new System.Drawing.Point(1177, 706);
            this.NEXT.Margin = new System.Windows.Forms.Padding(2);
            this.NEXT.Name = "NEXT";
            this.NEXT.Size = new System.Drawing.Size(225, 80);
            this.NEXT.TabIndex = 18;
            this.NEXT.Text = "NEXT";
            this.NEXT.UseVisualStyleBackColor = false;
            this.NEXT.Click += new System.EventHandler(this.NEXT_Click);
            // 
            // PREVIOUS
            // 
            this.PREVIOUS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PREVIOUS.BackColor = System.Drawing.Color.Coral;
            this.PREVIOUS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PREVIOUS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PREVIOUS.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.PREVIOUS.ForeColor = System.Drawing.SystemColors.MenuText;
            this.PREVIOUS.Location = new System.Drawing.Point(530, 730);
            this.PREVIOUS.Margin = new System.Windows.Forms.Padding(2);
            this.PREVIOUS.Name = "PREVIOUS";
            this.PREVIOUS.Size = new System.Drawing.Size(225, 80);
            this.PREVIOUS.TabIndex = 19;
            this.PREVIOUS.Text = "PREVIOUS";
            this.PREVIOUS.UseVisualStyleBackColor = false;
            this.PREVIOUS.Click += new System.EventHandler(this.PREVIOUS_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(602, 123);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(575, 330);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // LabelIntro
            // 
            this.LabelIntro.AutoSize = true;
            this.LabelIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelIntro.Location = new System.Drawing.Point(620, 67);
            this.LabelIntro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelIntro.Name = "LabelIntro";
            this.LabelIntro.Size = new System.Drawing.Size(467, 39);
            this.LabelIntro.TabIndex = 30;
            this.LabelIntro.Text = "ESCOGE A TU PERSONAJE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1924, 1052);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CONNAMES
            // 
            this.CONNAMES.ColumnHeadersHeight = 29;
            this.CONNAMES.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.CONNAMES.Location = new System.Drawing.Point(100, 225);
            this.CONNAMES.Name = "CONNAMES";
            this.CONNAMES.RowHeadersWidth = 51;
            this.CONNAMES.Size = new System.Drawing.Size(298, 318);
            this.CONNAMES.TabIndex = 34;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Interfaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1052);
            this.Controls.Add(this.CONNAMES);
            this.Controls.Add(this.LabelIntro);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.PREVIOUS);
            this.Controls.Add(this.NEXT);
            this.Controls.Add(this.SELECT);
            this.Controls.Add(this.historial);
            this.Controls.Add(this.holi);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Interfaz";
            this.Text = "Interfaz";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CONNAMES)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label holi;
        private System.Windows.Forms.Button historial;
        private System.Windows.Forms.Button SELECT;
        private System.Windows.Forms.Button NEXT;
        private System.Windows.Forms.Button PREVIOUS;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LabelIntro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView CONNAMES;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

