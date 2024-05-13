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

namespace kütüphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4PM5V54\SQLEXPRESS;Initial Catalog=KITAPLIK;Integrated Security=True;");

        private void btnlistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kıtaplık", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into kıtaplık (kitap_adi) values(@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtbxkitapara.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt eklendi.");
            baglanti.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("delete from kıtaplık where kitap_adi=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtbxkitapara.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Silme başarılı.");
            baglanti.Close();
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from kıtaplık where kitap_adi=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtbxkitapara.Text);
            SqlDataAdapter da= new SqlDataAdapter(komut2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }

    
}
