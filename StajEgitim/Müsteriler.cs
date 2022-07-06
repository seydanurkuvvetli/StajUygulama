using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StajEgitim
{
    class Müsteriler
    {
        SqlConnection _sqlConnection = new SqlConnection("Data Source=.; Integrated security=true; Initial Catalog=StajEgitim");
        public List<Müsteriler1> Listele()
        {
            ConnectionOpen();

            SqlCommand sqlCommand = new SqlCommand("select * from MüsteriKayit", _sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Müsteriler1> müsteriler = new List<Müsteriler1>();
            while (sqlDataReader.Read())
            {
                Müsteriler1 musteri = new Müsteriler1
                {
                    ID = Convert.ToInt32(sqlDataReader["ID"]),
                    AdSoyad = sqlDataReader["AdSoyad"].ToString(),
                    Telefon = sqlDataReader["Telefon"].ToString(),
                    Email   =sqlDataReader["Email"].ToString(),
                    Cinsiyet  =  sqlDataReader["Cinsiyet"].ToString(),
                    Adres = sqlDataReader["Adres"].ToString()
                    

                };
                müsteriler.Add(musteri);

            }
            sqlDataReader.Close();
            return müsteriler;

        }
        public void VeriEkle(Müsteriler1 müsteriler)
        {


            ConnectionOpen();

            SqlCommand sqlCommand = new SqlCommand("Insert Into MüsteriKayit Values (@AdSoyad,@Telefon,@Email,@Cinsiyet,@Adres)", _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@AdSoyad", müsteriler.AdSoyad);
            sqlCommand.Parameters.AddWithValue("@Telefon", müsteriler.Telefon);
            sqlCommand.Parameters.AddWithValue("@Email", müsteriler.Email);
            sqlCommand.Parameters.AddWithValue("@Cinsiyet", müsteriler.Cinsiyet);
            sqlCommand.Parameters.AddWithValue("@Adres", müsteriler.Adres);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

        }
        public void Sil(Müsteriler1 sil)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Delete From MüsteriKayit Where Id=" + sil.ID + "", _sqlConnection);

                ConnectionOpen();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (_sqlConnection != null)
                {
                    _sqlConnection.Close();
                }
            }
        }
        public void ConnectionOpen()
        {
            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }
        }
    }
}
