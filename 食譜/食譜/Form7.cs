using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace 食譜
{
    public partial class Form7 : Form
    {
        SqlConnection conn;
        SqlCommand comm, comm2;
        string search1, search2;

       


        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source = LAPTOP-UGLUQ41A\\SQLEXPRESS ;Initial Catalog =recipe;Integrated Security = True");
            conn.Open();
            if (textBox1.Text != "關鍵字" && comboBox1.Text != "分類")
            {
                search1 = textBox1.Text;
                search2 = comboBox1.Text;
                SqlDataAdapter myDa = new SqlDataAdapter("select 食譜名稱, 份量, 食譜描述 from 食譜分類 RC inner join 分類 C on RC.分類編號 = C.分類編號 inner join 食譜 R on RC.食譜編號 = R.食譜編號 where C.分類名稱 = ('" + search2 + "') AND R.食譜名稱 = ('" + search1 + "')", conn);
                DataSet DS = new DataSet();
                myDa.Fill(DS, "分類編號");
                dataGridView1.DataSource = DS.Tables["分類編號"];
                
            }
            else if (textBox1.Text != "關鍵字")
            {
                search1 = textBox1.Text;
                SqlDataAdapter myDa = new SqlDataAdapter("select 食譜名稱, R.份量, 食譜描述 from 食譜所用食材 RI inner join 食材 I on RI.食材編號 = I.食材編號 inner join 食譜 R on RI.食譜編號 = R.食譜編號 where R.食譜名稱 = ('" + search1 + "') or I.食材名稱 =('" + search1 + "') ", conn);
                DataSet DS = new DataSet();
                myDa.Fill(DS, "食譜名稱");
                dataGridView1.DataSource = DS.Tables["食譜名稱"];

                //comm = new SqlCommand("Select * from 食譜 where 食譜名稱 = @search2", conn);
                //reader = comm.ExecuteReader();
            }
            else if (comboBox1.Text != "分類" )
            {
                search2 = comboBox1.Text;
                //comm = new SqlCommand("Select * from 分類 where 分類名稱 = ('" + search2 + "')", conn);
                //reader = comm.ExecuteReader();

                //string typenumber = reader["分類編號"].ToString();
                //MessageBox.Show(typenumber);
                //var query = from product in dataEntities.Products where product.Color == "Red" orderby product.ListPrice select new { product.Name, product.Color, CategoryName = product.ProductCategory.Name, product.ListPrice };

                SqlDataAdapter myDa = new SqlDataAdapter("select 食譜名稱, 份量, 食譜描述 from 食譜分類 RC inner join 分類 C on RC.分類編號 = C.分類編號 inner join 食譜 R on RC.食譜編號 = R.食譜編號 where C.分類名稱 = ('" + search2 + "')", conn);
                //SqlDataAdapter maDa = new SqlDataAdapter("select * from view where 分類名稱 =  ('" + search2 + "')",conn);
                DataSet DS = new DataSet();
                myDa.Fill(DS, "分類");
                //dataGridView1.Rows.Remove;
                dataGridView1.DataSource = DS.Tables["分類"];
            }
            else
            {
                MessageBox.Show("請輸入資料再搜尋！");
                return;
            }

            

            
        }
    }
}
