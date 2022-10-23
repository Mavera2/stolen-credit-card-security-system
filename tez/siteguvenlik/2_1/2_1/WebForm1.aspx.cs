using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace _2_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "https://i.pinimg.com/originals/ed/23/68/ed23685339ada1b6d88008cbe1a11e98.gif";
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\siteguvenlik\\siteguvenlik\\bin\\x64\\Debug\\kullanıcılar.accdb");
        OleDbCommand cmd;
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cmd = new OleDbCommand("select * from calintikartlar where kartno=" + TextBox1.Text + " and sonkullanma='" + TextBox3.Text + "' and cvv=" + TextBox4.Text + "", baglanti);
            OleDbDataReader dr=cmd.ExecuteReader();
            dr.Read();
            try
            {
                if (dr[0].ToString() != null)
                {
                    var webClient = new WebClient();

                    string dnsString = webClient.DownloadString("http://checkip.dyndns.org");
                    dnsString = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(dnsString).Value;
                    webClient.Dispose();
                    cmd = new OleDbCommand("insert into iptablosu(calintikartno,ip) values('" + TextBox1.Text + "','" + dnsString + "')", baglanti);
                    cmd.ExecuteNonQuery();
                    Image1.ImageUrl = "https://cdn.dribbble.com/users/251873/screenshots/9388228/error-img.gif";
                    dr.Close();
                }
            }
            catch (Exception)
            {
                cmd = new OleDbCommand("select * from kartbilgisi where kartno=" + TextBox1.Text + " and sonkullanma='" + TextBox3.Text + "' and cvv=" + TextBox4.Text + "", baglanti);
                OleDbDataReader datar = cmd.ExecuteReader();
                datar.Read();
                try
                {
                    if (datar[0].ToString() != null)
                    {
                        Image1.ImageUrl = "https://static.wixstatic.com/media/ac2dcc_3ca088e361434dd18e6218c661252462~mv2.gif";
                    }
                }
                catch (Exception)
                {
                    Image1.ImageUrl = "https://cdn.dribbble.com/users/251873/screenshots/9388228/error-img.gif";
                }
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}