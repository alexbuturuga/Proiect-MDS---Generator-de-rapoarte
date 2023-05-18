using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ProiectMDS
{
    public partial class Form1 : Form
    {
        public int i=0;
        bool p3vis = false;
        private bool isDragging = false;
        private Point lastMousePos;
        SqlConnection c = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inserareProiectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /*
            c.Open();
            string Select = "select * from test";
            SqlCommand cmd = new SqlCommand(Select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while(r.Read())
            {
                MessageBox.Show(r[0].ToString() + " " + r[1].ToString());
            }
            c.Close();
           */
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.FromArgb(255, 215, 215);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.button1.BackColor = Color.FromArgb(255, 63, 63);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.FromArgb(160, 160, 160);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.FromArgb(210, 210, 210);
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            this.button2.BackColor = Color.FromArgb(250, 250, 250);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newMousePos = e.Location;
                int deltaX = newMousePos.X - lastMousePos.X;
                int deltaY = newMousePos.Y - lastMousePos.Y;
                Location = new Point(Location.X + deltaX, Location.Y + deltaY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastMousePos = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            if (p3vis == false)
            {
                panel3.Visible = true;
                p3vis = true;
            }
            else
            {
                panel3.Visible = false;
                p3vis = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void inserareProiectToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Inserare2 f = new Inserare2();
            f.Show();
        }

        private void angajatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void proiectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inserare f = new Inserare();
            f.Show();
        }

        private void afisareProiecteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Afisare f = new Afisare();
            f.Show();
        }

        private void graficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafice f = new Grafice();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
