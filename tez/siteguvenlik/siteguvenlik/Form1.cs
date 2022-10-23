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
namespace siteguvenlik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kullanıcılar.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        DataTable dataTable = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            doldur();
        }
        void doldur()
        {
            baglanti.Open();
            da = new OleDbDataAdapter("Select * from kullanıcılar ", baglanti);
            ds = new DataSet();
            da.Fill(ds, "kullanıcılar");
            dataGridView1.DataSource = ds.Tables["kullanıcılar"];
            
            da = new OleDbDataAdapter("Select * from kartbilgisi ", baglanti);
            ds = new DataSet();
            da.Fill(ds, "kartbilgisi");
            dataGridView2.DataSource = ds.Tables["kartbilgisi"];
            baglanti.Close();
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int satır = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            
            
            baglanti.Open();
            OleDbCommand oku = new OleDbCommand("select * from kullanıcılar where id=" + satır + "", baglanti);
            OleDbDataReader okuyucu = oku.ExecuteReader();
            while (okuyucu.Read())
            {
                textBox1.Text = okuyucu[0].ToString();
                textBox2.Text = okuyucu[1].ToString();
                textBox3.Text = okuyucu[2].ToString();
                textBox4.Text = okuyucu[3].ToString();
                richTextBox1.Text = okuyucu[4].ToString();
                comboBox1.Text = okuyucu[5].ToString();
                dateTimePicker1.Text = okuyucu[6].ToString();
                textBox5.Text = okuyucu[7].ToString();
            }
            
            da = new OleDbDataAdapter("Select * from kartbilgisi where müsterino=" + textBox1.Text, baglanti);
            ds = new DataSet();
            da.Fill(ds, "kartbilgisi");
            dataGridView2.DataSource = ds.Tables["kartbilgisi"];
            baglanti.Close();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "insert into kullanıcılar(ad,soyad,email,adres,şehir,doğumtarih,telno) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + dateTimePicker1.Value.ToString() + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "insert into kartbilgisi(müsterino,kartno,sonkullanma,CVV) values(" + textBox1.Text + "," + textBox6.Text + ",'" + textBox7.Text + "'," + textBox9.Text + ")";
            cmd.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "update kullanıcılar set ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',email='" + textBox4.Text + "',adres='" + richTextBox1.Text + "',şehir='" + comboBox1.Text + "',doğumtarih='" + dateTimePicker1.Value.ToString() + "',telno='" + textBox5.Text + "'where id=" + textBox1.Text;
            cmd.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "update kartbilgisi set müsterino='" + textBox1.Text + "',kartno='" + textBox6.Text + "',sonkullanma='" + textBox7.Text+ "',cvv='" + textBox9.Text + "'where id=" + textBox8.Text;
            cmd.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int satır = Convert.ToInt32(dataGridView2.CurrentRow.Cells["id"].Value);

            label8.Text = satır.ToString();
            baglanti.Open();
            OleDbCommand oku = new OleDbCommand("select * from kartbilgisi where id=" + satır + "", baglanti);
            OleDbDataReader okuyucu = oku.ExecuteReader();
            while (okuyucu.Read())
            {
               textBox8.Text  = okuyucu[0].ToString();
               textBox6.Text = okuyucu[2].ToString();
               textBox7.Text = okuyucu[3].ToString();
               textBox9.Text = okuyucu[4].ToString();
            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "delete from kartbilgisi where müsterino=" + textBox1.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from kullanıcılar where id=" + textBox1.Text;
            cmd.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "delete from kartbilgisi where id=" + textBox8.Text;
            cmd.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
