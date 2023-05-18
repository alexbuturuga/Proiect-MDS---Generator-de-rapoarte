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
using System.Threading;

namespace ProiectMDS
{
    public partial class Angajati : Form
    {
        public int curent = 0;
        public int i = 0;
        bool p3vis = false;
        private bool isDragging = false;
        private Point lastMousePos;
        SqlConnection c = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Database1.mdf;Integrated Security=True");
        public Angajati()
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

        public void afisang()
        {
            if (curent == 0)
            {
                dataGridView1.DataBindings.Clear();
                dataGridView1.Rows.Clear();
                c.Open();
                string Select = "select a.Id,a.Nume,a.Prenume,a.Numar_de_telefon,b.Nume_Proiect,a.Poza from Angajati a, Proiecte b where b.Id = a.Id_Proiect";
                SqlCommand cmd = new SqlCommand(Select, c);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    try
                    {
                        using (FileStream fileStream = File.Open(Directory.GetCurrentDirectory() + "/Resurse/" + r[5].ToString(), FileMode.Open))
                        {
                            Bitmap bitmap = new Bitmap(fileStream);
                            Image currentPicture = (Image)bitmap;
                            dataGridView1.Rows.Add(r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString(), r[4].ToString(), currentPicture, "Sterge");
                            //MessageBox.Show(r[0].ToString() + " " + r[1].ToString());
                        }
                    }
                    catch
                    {
                        dataGridView1.Rows.Add(r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString(), r[4].ToString(), Image.FromFile(Directory.GetCurrentDirectory() + "/Resurse/nophoto.jpg"), "Sterge");
                    }

                }
                r.Close();
                c.Close();
            }else
            if(curent == 1)
            {
                dataGridView1.DataBindings.Clear();
                dataGridView1.Rows.Clear();
                c.Open();
                string Select = "select a.Id,a.Nume,a.Prenume,a.Numar_de_telefon,b.Nume_Proiect,a.Poza from Angajati a, Proiecte b where b.Id = a.Id_Proiect and a.Id_Proiect = @a";
                SqlCommand cmd = new SqlCommand(Select, c);
                cmd.Parameters.AddWithValue("a", Afisare.id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    try
                    {
                        using (FileStream fileStream = File.Open(Directory.GetCurrentDirectory() + "/Resurse/" + r[5].ToString(), FileMode.Open))
                        {
                            Bitmap bitmap = new Bitmap(fileStream);
                            Image currentPicture = (Image)bitmap;
                            dataGridView1.Rows.Add(r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString(), r[4].ToString(), currentPicture, "Sterge");
                            //MessageBox.Show(r[0].ToString() + " " + r[1].ToString());
                        }
                    }
                    catch
                    {
                        dataGridView1.Rows.Add(r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString(), r[4].ToString(), Image.FromFile(Directory.GetCurrentDirectory() + "/Resurse/nophoto.jpg"), "Sterge");
                    }

                }
                r.Close();
                c.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            afisang();


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
        string image;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                    if (e.ColumnIndex == 6)
                    {

                        c.Open();
                        string select = "select Poza from angajati where id = @a";
                        SqlCommand cmd1 = new SqlCommand(select, c);
                        cmd1.Parameters.AddWithValue("a", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        SqlDataReader r = cmd1.ExecuteReader();
                        if (r.Read())
                        {
                            image = Directory.GetCurrentDirectory() + "/Resurse/" + r[0].ToString();
                        }
                        r.Close();
                        c.Close();


                        c.Open();
                        string delete = "Delete from angajati where id = @a";
                        SqlCommand cmd = new SqlCommand(delete, c);
                        cmd.Parameters.AddWithValue("a", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();
                        c.Close();
                        MessageBox.Show("Utilizator sters cu succes!");
                        Thread.Sleep(100);
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        File.Delete(image);
                        afisang();
                    }
            }catch
            {
                c.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            curent = 1;
            afisang();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            curent = 0;
            afisang();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
