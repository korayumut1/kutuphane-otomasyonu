using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace kutuphane
{
    public partial class odunc : Form
    {

        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public odunc()
        {
            InitializeComponent();
        }


         void griddoldur1() {

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kutuphane.accdb");
            da = new OleDbDataAdapter("SElect * from odunc", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "odunc");
            dataGridView1.DataSource = ds.Tables["odunc"];
            con.Close();
        
        
        }

         public string form1id{get;set;}  // getter setter property form dışından erişip text değişikliği yapmak için.
         public string form1ad { get; set; }

        private void odunc_Load(object sender, EventArgs e)
        {

       
            tbkitapoduncid.Text = form1id;
            tbodunckitapad.Text = form1ad;
           
            griddoldur1();
            dataGridView1.ClearSelection();


        }

        private void tbodunckitapad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into odunc (kitap_id,kitap_ad,tckimlik,ad,soyad,telefon,tarih) values ('" + tbkitapoduncid.Text + "','" + tbodunckitapad.Text + "','" + tbodunctc.Text + "','" + tbodunncad.Text + "','" + tboduncsoyad.Text + "','" + tbtel.Text + "','" + dtalmatarih.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur1();
        }

      

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            
          
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update odunc set kitap_id='" + tbkitapoduncid.Text +
                "',kitap_ad='" + tbodunckitapad.Text +
                "',tckimlik='" + tbodunctc.Text +
                "',ad='" + tbodunncad.Text +
                "',soyad='" + tboduncsoyad.Text +
                "',telefon='" + tbtel.Text +
                "',getirme_tarihi='" + dtgetirme.Text + "' where odunc_id=" + tboduncid.Text+ "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur1();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kutuphane.accdb");
            da = new OleDbDataAdapter("SElect *from odunc where ad like '" + textBox1.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "odunc");
            dataGridView1.DataSource = ds.Tables["odunc"];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from odunc where odunc_id=" + tboduncid.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            griddoldur1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tboduncid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbkitapoduncid.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbodunckitapad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbodunctc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbodunncad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tboduncsoyad.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbtel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
