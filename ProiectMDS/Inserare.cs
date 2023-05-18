using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProiectMDS
{
    public partial class Inserare : Form
    {
        public int i = 0;
        bool p3vis = false;
        private bool isDragging = false;
        private Point lastMousePos;
        SqlConnection c = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Database1.mdf;Integrated Security=True");
        public Inserare()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void inserareProiectToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void angajatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (!(input.Length >= 8 && input.Length <= 20))
            {
                // Input meets the requirements
                MessageBox.Show("Numele introdus nu este valid, acesta trebuie sa fie intre 8 si 20 de caractere");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Inserare_Load(object sender, EventArgs e)
        {

        }

        private void Inserare_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
    }
}
