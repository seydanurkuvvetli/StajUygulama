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
    public partial class Listele : Form
    {
        SqlConnection _sqlConnection = new SqlConnection("Data Source=.; Integrated security=true; Initial Catalog=StajEgitim");

        Müsteriler müsteri = new Müsteriler();
        public Listele()
        {
            InitializeComponent();
        }

        private void Listele_Load(object sender, EventArgs e)
        {
            Müsteriler musterilistele = new Müsteriler();


           dataGridView1.DataSource = musterilistele.Listele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Müsteriler1 silinecekmüsteri = new Müsteriler1();
            silinecekmüsteri = (Müsteriler1)dataGridView1.CurrentRow.DataBoundItem;
            müsteri.Sil(silinecekmüsteri);
           dataGridView1.DataSource = müsteri.Listele();
        }
    }
}
