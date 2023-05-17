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
using System.Security.Cryptography;

namespace ProiectMDS
{
    public partial class Inserare2 : Form
    {
        public int i=0;
        bool p3vis = false;
        private bool isDragging = false;
        private Point lastMousePos;
        public string imagine = "gol.png";
        public string cale = "";
        SqlConnection c = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Database1.mdf;Integrated Security=True");
        public Inserare2()
        {
            InitializeComponent();
            
        }

       /* private void button1_Click(object sender, EventArgs e)
        {d
            this.Close();
        }*/

        private void inserareProiectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        void incarcaproiecte()
        {
            comboBox1.Items.Clear();
            c.Open();
            string Select = "select * from Proiecte";
            SqlCommand cmd = new SqlCommand(Select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Items.Add(r[0].ToString() + ". " + r[1].ToString());
            }
            c.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            incarcaproiecte();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            cale = openFileDialog1.FileName;
            string[] photoname = cale.Split('\\');
            imagine = photoname.Last();
            //File.Copy(cale, Directory.GetCurrentDirectory() + @"\Resurse\" + photoname.Last());
            pictureBox1.Image = Image.FromFile(cale);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            c.Open();
            string insert = @"insert into Proiecte(Nume_proiect,Venit,Descriere,Poza) values (@a,@b,@c,@d)";
            SqlCommand cmd = new SqlCommand(insert, c);
            cmd.Parameters.AddWithValue("a", textBox1.Text);
            cmd.Parameters.AddWithValue("b", textBox2.Text);
            cmd.Parameters.AddWithValue("c", richTextBox1.Text);
            cmd.Parameters.AddWithValue("d", textBox1.Text + ".jpg");
            string destPath = Directory.GetCurrentDirectory() + @"\Resurse\" + textBox1.Text + ".jpg";
            if (File.Exists(destPath))
            {
                MessageBox.Show("Imaginea exista deja in fisier! Alege alta imagine.");
                c.Close();
            }
            else
            {
                File.Copy(cale, destPath);
                cmd.ExecuteNonQuery();
                c.Close();
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                imagine = "gol.png";
                pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resurse\gol.png");
                MessageBox.Show("Adaugat cu succes!");
                incarcaproiecte();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // ignore the input
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            cale = openFileDialog1.FileName;
            string[] photoname = cale.Split('\\');
            imagine = photoname.Last();
            //
            pictureBox2.Image = Image.FromFile(cale);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // ignore the input
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b') // Allow backspace
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] elemente = comboBox1.SelectedItem.ToString().Split('.', ' ');
            int id_p = Convert.ToInt32(elemente[0]);
            c.Open();
            string insert = @"insert into angajati(Nume,Prenume,Numar_de_telefon,Id_Proiect,Poza) values (@a,@b,@c,@d,@e)";
            SqlCommand cmd = new SqlCommand(insert, c);
            cmd.Parameters.AddWithValue("a", textBox3.Text);
            cmd.Parameters.AddWithValue("b", textBox4.Text);
            cmd.Parameters.AddWithValue("c", textBox5.Text);
            cmd.Parameters.AddWithValue("d", id_p);
            cmd.Parameters.AddWithValue("e", textBox3.Text + "_" + textBox4.Text + ".jpg");
            string destPath = Directory.GetCurrentDirectory() + @"\Resurse\" + textBox3.Text + "_" + textBox4.Text + ".jpg";
            if (File.Exists(destPath))
            {
                MessageBox.Show("Imaginea exista deja in fisier! Alege alta imagine.");
                c.Close();
            }
            else
            {
                cmd.ExecuteNonQuery();
                c.Close();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                File.Copy(cale, destPath);
                imagine = "gol.png";
                pictureBox2.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resurse\gol.png");
                MessageBox.Show("Adaugat cu succes!");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b') // Allow backspace
            {
                e.Handled = true; // Ignore the key press
            }
        }
    }
}
