using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StajEgitim
{
    class UrunlerAl
    {
        SqlConnection _sqlConnection = new SqlConnection("Data Source=.; Integrated security=true; Initial Catalog=StajEgitim");
        public List<Urunler> VeriAl()
        {
            ConnectionOpen();

            SqlCommand sqlCommand = new SqlCommand("select * from Urunler1", _sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Urunler> urunler = new List<Urunler>();
            while (sqlDataReader.Read())
            {
                Urunler urun = new Urunler
                {
                    ID = Convert.ToInt32(sqlDataReader["ID"]),
                    Ad = sqlDataReader["Ad"].ToString(),
                    Fiyat = Convert.ToDecimal(sqlDataReader["Fiyat"]),
                    Stok = Convert.ToInt32(sqlDataReader["Stok"]),
                    Kategoriler = sqlDataReader["Kategoriler"].ToString()

                };
                urunler.Add(urun);
            }
            sqlDataReader.Close();
            return urunler;

        }
        public void VeriEkle(Urunler urunler)
        {


            ConnectionOpen();

            SqlCommand sqlCommand = new SqlCommand("Insert Into Urunler1 Values (@Ad,@Stok,@Fiyat,@Kategoriler)", _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Ad", urunler.Ad);
            sqlCommand.Parameters.AddWithValue("@Stok", urunler.Stok);
            sqlCommand.Parameters.AddWithValue("@Fiyat", urunler.Fiyat);
            sqlCommand.Parameters.AddWithValue("@Kategoriler", urunler.Kategoriler);
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

        }

        public void Guncelle(Urunler eskiUrun, Urunler yeniUrun)
        {
            try
            {
                SqlCommand sqlCommand= new SqlCommand( "Update Urunler1 SET ad='" + yeniUrun.Ad + "', Stok ='" + yeniUrun.Stok + "',Fiyat='" + yeniUrun.Fiyat+"',Kategoriler='"+yeniUrun.Kategoriler+ "' Where Id=" + eskiUrun.ID +"",_sqlConnection);


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


        public void Sil(Urunler k)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Delete From Urunler1 Where Id=" + k.ID + "", _sqlConnection);

                


                ConnectionOpen();
               sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (_sqlConnection!= null)
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
