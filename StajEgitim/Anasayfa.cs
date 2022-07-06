using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajEgitim
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        SqlConnection _sqlConnection = new SqlConnection("Data Source=.; Integrated security=true; Initial Catalog=StajEgitim");
        Müsteriler müsteri = new Müsteriler();
        Müsteriler1 müsteri2 = new Müsteriler1();

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            müsteri2.AdSoyad = textBox1.Text;
            müsteri2.Telefon = textBox2.Text;
            müsteri2.Email = textBox3.Text;
            müsteri2.Cinsiyet = comboBox1.Text;
            müsteri2.Adres = textBox4.Text;

            müsteri.VeriEkle(müsteri2);
            if (textBox1.Text == "")
            {
                MessageBox.Show(" Ad Soyad boş geçilemez");
            }
            else
            {

                MessageBox.Show("Müşteri Kaydı başarılı");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Listele liste = new Listele();
            liste.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
        }
    }
}
