using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class kgiris : Form
    {
        public kgiris()
        {
            InitializeComponent();
        }

        private void kgiris_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dogruKullaniciAdi = "admin"; 
            string dogruParola = "12345";      

           
            string kullaniciAdi = txtKullaniciAdi.Text;
            string parola = txtParola.Text;

           
            if (kullaniciAdi == dogruKullaniciAdi && parola == dogruParola)
            {
                MessageBox.Show("Giriş başarılı! Hoş geldiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                Form1 anaSayfa = new Form1();
                anaSayfa.Show();
                this.Hide();  
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya parola hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtParola_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
