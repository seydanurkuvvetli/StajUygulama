using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajEgitim
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection _sqlConnection = new SqlConnection("Data Source=.; Integrated security=true; Initial Catalog=StajEgitim");
        
        
        Urunler urun = new Urunler();
        UrunlerAl  _urunlerDal = new UrunlerAl();
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UrunlerAl urunlerDal = new UrunlerAl();


            gridListe.DataSource =urunlerDal.VeriAl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            urun.Ad = txtAd.Text;
            urun.Stok = Convert.ToInt32(txtStok.Text);
            urun.Fiyat = Convert.ToDecimal(txtFiyat.Text);
            urun.Kategoriler = comboBox1.Text;

            _urunlerDal.VeriEkle(urun);
            gridListe.DataSource = _urunlerDal.VeriAl();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Urunler eskiurun = new Urunler();
            eskiurun = (Urunler)gridListe.CurrentRow.DataBoundItem;
            Urunler yeniurun = new Urunler();
            yeniurun.Ad = txtAd.Text;
            yeniurun.Stok = Convert.ToInt32(txtStok.Text);
            yeniurun.Fiyat = Convert.ToDecimal(txtFiyat.Text);
            yeniurun.Kategoriler = comboBox1.Text;
           
            _urunlerDal.Guncelle(eskiurun, yeniurun);
            gridListe.DataSource = _urunlerDal.VeriAl();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Urunler silinecekurun = new Urunler();
            silinecekurun = (Urunler)gridListe.CurrentRow.DataBoundItem;
            _urunlerDal.Sil(silinecekurun);
            gridListe.DataSource = _urunlerDal.VeriAl();

        }
        
           
        
        private void button4_Click(object sender, EventArgs e)

        {
            SqlCommand sqlCommand = new SqlCommand("select * from Urunler1 where Ad like'%" + textBox1.Text + "%'",_sqlConnection);

            //hangi arama türünü kullancaksak onu seçeceğiz. Ben örnekte ortadan aramayı kullandım.
            SqlDataAdapter adaptor = new SqlDataAdapter(sqlCommand);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);
            gridListe.DataSource = tablo;
            _sqlConnection.Close();


        }
    }
}
