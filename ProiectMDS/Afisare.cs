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
    public partial class Afisare : Form
    {
        
        public int i=0;
        public static int id = 1;
        bool p3vis = false;
        private bool isDragging = false;
        private Point lastMousePos;
        SqlConnection c = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+ Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Database1.mdf;Integrated Security=True");
        public Afisare()
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

        public void afisare()
        {
            
            try
            {
                c.Open();
                string Select = "select * from Proiecte where id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(Select, c);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    label6.Text = "Numar Proiect: " + r[0].ToString();
                    label1.Text = "Nume Proiect: " + r[1].ToString();
                    label5.Text = "Lei: " + r[2].ToString();
                    label7.Text = "Euro: " + (Convert.ToDouble(r[2].ToString()) / 4.93).ToString("0.00"); ;
                    label8.Text = "Dolari: " + (Convert.ToDouble(r[2].ToString()) / 4.48).ToString("0.00"); ;
                    richTextBox1.Text = r[3].ToString();

                    try
                    {
                        using (FileStream fileStream = File.Open(Directory.GetCurrentDirectory() + "/Resurse/" + r[4].ToString(), FileMode.Open))
                        {
                            Bitmap bitmap = new Bitmap(fileStream);
                            Image currentPicture = (Image)bitmap;
                            pictureBox1.Image = currentPicture;
                        }
                    }catch
                    {
                        pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resurse\" + "nophoto.jpg");
                    }

                    
                   
                }
                c.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Elementul cu id-ul: " + id + " nu exista in baza de date!");
                c.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3_Click_1(sender, e);
            //afisare(); 
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
                textBox1.Text = "Cauta proiectul dupa id sau nume";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            c.Open();
            string select = @"select top 1 * from Proiecte where Id > @a ORDER BY Id ASC";
            SqlCommand cmd = new SqlCommand(select, c);
            cmd.Parameters.AddWithValue("a", id.ToString());
            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                r.Read();
                id = r.GetInt32(0); // ID-ul următorului obiect
                c.Close();
                afisare();
            }
            else
            {
                MessageBox.Show("Acesta este ultimul proiect din lista!");
                c.Close();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.Open();
            string select = @"select top 1 * from Proiecte where Id < @a ORDER BY Id DESC";
            SqlCommand cmd = new SqlCommand(select, c);
            cmd.Parameters.AddWithValue("a", id.ToString());
            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                r.Read();
                id = r.GetInt32(0); // ID-ul următorului obiect
                c.Close();
                afisare();
            }
            else
            {
                MessageBox.Show("Acesta e primul proiect din lista!");
                c.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            c.Open();
            string select = @"select * from Proiecte where Id = @a";
            SqlCommand cmd = new SqlCommand(select, c);
            cmd.Parameters.AddWithValue("a", textBox1.Text);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                r.Read();
                id = r.GetInt32(0); // ID-ul următorului obiect
                c.Close();
                afisare();
            }
            else
            {
                c.Close();
                c.Open();

                string select1 = @"select * from Proiecte where Nume_proiect = @b";
                SqlCommand cmd1 = new SqlCommand(select1, c);
                cmd1.Parameters.AddWithValue("b", textBox1.Text);
                SqlDataReader r1 = cmd1.ExecuteReader();
                if (r1.HasRows)
                {
                    r1.Read();
                    id = r1.GetInt32(0); // ID-ul următorului obiect
                    c.Close();
                    afisare();
                }
                else
                { 
                MessageBox.Show("Acest proiect nu exista in baza de date.");
                c.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Angajati f = new Angajati();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //sterge pozele angajatilor
                c.Open();
                string select = "select Poza from angajati where Id_Proiect = @a";
                SqlCommand cmd1 = new SqlCommand(select, c);
                cmd1.Parameters.AddWithValue("a", id);
                SqlDataReader r = cmd1.ExecuteReader();
                while (r.Read())
                {
                    File.Delete(Directory.GetCurrentDirectory() + "/Resurse/" + r[0].ToString());
                }
             
                c.Close();
            //sterge angajatii
            c.Open();
            string delete1 = "delete from angajati where Id_Proiect = @a";
            SqlCommand cmd3 = new SqlCommand(delete1, c);
            cmd3.Parameters.AddWithValue("a", id);
            cmd3.ExecuteNonQuery();
            c.Close();

            //sterge poza proiectului
            c.Open();
            string select2 = "select Poza from Proiecte where Id = @a";
            SqlCommand cmd2 = new SqlCommand(select2, c);
            cmd2.Parameters.AddWithValue("a", id);
            SqlDataReader r2 = cmd2.ExecuteReader();
            if(r2.Read())
            {
                File.Delete(Directory.GetCurrentDirectory() + "/Resurse/" + r2[0].ToString());
            }
            c.Close();

            //sterge proiectul
            c.Open();
            string delete = "delete from Proiecte where Id = @a";
            SqlCommand cmd = new SqlCommand(delete, c);
            cmd.Parameters.AddWithValue("a", id);
            cmd.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("Proiectul a fost sters cu succes!");

            button3_Click_1(sender, e);

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cauta proiectul dupa id sau nume")
                textBox1.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string cale = saveFileDialog1.FileName;
                //MessageBox.Show(cale);

                //afisare continut

                using (StreamWriter w = new StreamWriter(cale, append: true))
                {

                    //date proiect
                    c.Open();
                    string select = "select * from Proiecte where Id = @a";
                    SqlCommand cmd = new SqlCommand(select, c);
                    cmd.Parameters.AddWithValue("a", id);
                    SqlDataReader r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        w.Write("Id: " + r[0].ToString() + "\n" +
                                    "Nume_Proiect: " + r[1].ToString() + "\n" +
                                    "Venit lei: " + r[2].ToString() + "\n" +
                                    "Descriere: " + r[3].ToString() + "\n");
                    }

                    c.Close();

                    int i = 1;
                    //date angajati
                    c.Open();
                    string select1 = "select * from angajati where Id_Proiect = @a";
                    SqlCommand cmd1 = new SqlCommand(select1, c);
                    cmd1.Parameters.AddWithValue("a", id);
                    SqlDataReader r1 = cmd1.ExecuteReader();
                    while (r1.Read())
                    {
                        w.Write("\n" + "Angajat " + i.ToString() + "\n" + "\n");
                        w.Write("Id: " + r1[0].ToString() + "\n" +
                                    "Nume " + r1[1].ToString() + "\n" +
                                    "Prenume: " + r1[2].ToString() + "\n" +
                                    "Numar_de_telefon: " + r1[3].ToString() + "\n");
                        i++;
                    }
                    c.Close();
                }

                MessageBox.Show("Datele au fost exportate cu succes!");
            }else
            {
               
            }
        }

      
    }
}
