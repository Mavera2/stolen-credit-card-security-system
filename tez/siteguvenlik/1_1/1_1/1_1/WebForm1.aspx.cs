using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace _1_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\siteguvenlik\\siteguvenlik\\bin\\x64\\Debug\\kullanıcılar.accdb");
        OleDbCommand cmd = new OleDbCommand();
        protected void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new OleDbCommand("select * from kullanıcılar where telno='" + TextBox7.Text + "'", baglanti);
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (CheckBox1.Checked == true && TextBox1.Text!="" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "" && TextBox8.Text != "" && TextBox9.Text != "" && TextBox10.Text != "")
            {
                try
                {
                    if (dr[0].ToString() != null)
                    {
                        cmd = new OleDbCommand("insert into calintikartlar(müsterino,kartno,sonkullanma,CVV) values('" + dr[0].ToString() + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "')", baglanti);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("İşlem başarıyla gerçekleşti.");
                    }
                }
                catch (Exception a)
                {

                    MessageBox.Show("Hatalı giriş.", a.ToString());
                }
            }
            else
            {
                MessageBox.Show("Eksik veri girişi.");
            }
            baglanti.Close();
        }
            
       

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}