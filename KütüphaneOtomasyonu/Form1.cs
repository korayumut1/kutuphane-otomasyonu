using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using KutuphaneOtomasyonu;

namespace KutuphaneOtomasyonu
{
    public partial class Form1 : Form
    {
        private OleDbConnection con;
        private OleDbDataAdapter da;
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
            VeritabaniBaglanti();
            KitaplariListele();
        }

        private void VeritabaniBaglanti()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kutuphane.accdb";
            con = new OleDbConnection(connectionString);
        }

        private void KitaplariListele()
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Kitaplar";
                da = new OleDbDataAdapter(query, con);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; // dataGridView1: Formdaki bir DataGridView kontrolü
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void KitapEkle(string kitapAdı, string yazar, string yayıncı, string durum)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Kitaplar (KitapAdı, Yazar, Yayıncı, Durum) VALUES (@KitapAdı, @Yazar, @Yayıncı, @Durum)";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@KitapAdı", kitapAdı);
                cmd.Parameters.AddWithValue("@Yazar", yazar);
                cmd.Parameters.AddWithValue("@Yayıncı", yayıncı);
                cmd.Parameters.AddWithValue("@Durum", durum);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kitap başarıyla eklendi!");
                KitaplariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void KitapSil(int kitapID)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM Kitaplar WHERE KitapID = @KitapID";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@KitapID", kitapID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kitap başarıyla silindi!");
                KitaplariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void KitapGuncelle(int kitapID, string kitapAdı, string yazar, string yayıncı, string durum)
        {
            try
            {
                con.Open();
                string query = "UPDATE Kitaplar SET KitapAdı = @KitapAdı, Yazar = @Yazar, Yayıncı = @Yayıncı, Durum = @Durum WHERE KitapID = @KitapID";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.Parameters.AddWithValue("@KitapAdı", kitapAdı);
                cmd.Parameters.AddWithValue("@Yazar", yazar);
                cmd.Parameters.AddWithValue("@Yayıncı", yayıncı);
                cmd.Parameters.AddWithValue("@Durum", durum);
                cmd.Parameters.AddWithValue("@KitapID", kitapID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kitap başarıyla güncellendi!");
                KitaplariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Örnek buton click event
        private void btnEkle_Click(object sender, EventArgs e)
        {
            KitapEkle("Test Kitap", "Yazar Adı", "Yayınevi", "Mevcut");
        }
    }
}
