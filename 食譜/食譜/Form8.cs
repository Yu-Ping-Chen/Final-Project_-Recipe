using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Threading;
using System.Data.Sql;

namespace 食譜
{
    public partial class Form8 : Form
    {
        SHA256 HASH256 = SHA256.Create();
        SqlConnection conn;
        SqlDataReader rreader;
        SqlCommand comm;
        SqlDataAdapter aadapter = new SqlDataAdapter();
        DataTable DBTable = new DataTable();
        
        static public string username = "哩賀，使用者", number, text, pic;
        static public object ppic;
        public Form8()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] source = Encoding.Default.GetBytes(textBox3.Text); //建一個一維陣列，將字串轉為byte[]
            byte[] crypto = HASH256.ComputeHash(source); //進行Hash256 HASH source(內容)
            string Hash = Convert.ToBase64String(crypto); //hash 後的資料

            string email = textBox2.Text;
            //string query = "select* from 會員資料 where (電子郵件) in ('" + email + "')and (hash) in ('" + hash + "')";
            conn = new SqlConnection("Data Source = LAPTOP-UGLUQ41A\\SQLEXPRESS; Initial Catalog = recipe; Integrated security =true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select* from 會員資料 where (電子郵件) in ('" + email + "') and (hash) in ('" + Hash + "')", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet da = new DataSet();
            adp.Fill(da, "info");
            DataTable table = da.Tables["info"];

            int num = Convert.ToInt32(cmd.ExecuteScalar());
            if (table.Rows.Count >= 1)
            {
                rreader = cmd.ExecuteReader(); //讀入成功找到的資料行
                rreader.Read(); //執行讀入
                number = rreader["使用者編號"].ToString(); //全域變數記錄使用者編號
                username = rreader["使用者名稱"].ToString(); //全域變數記錄使用者名稱
                text = rreader["個人簡介"].ToString(); //全域變數紀錄個人簡介
                pic = rreader["使用者頭貼"].ToString();  //全域變數紀錄使用者頭貼 ***不確定會不會出錯
                ppic = rreader["使用者頭貼"].GetType();
                
                rreader.Close();
                
                Thread thread = new Thread(new ThreadStart(delegate () //建立一個執行序
                {
                    MessageBox.Show("登入成功");
                    Form9 F9 = new Form9();
                    F9.ShowDialog();
                }));
                thread.Start();
                //this.Close();
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤");
            }

            
         

        }
    }
}
