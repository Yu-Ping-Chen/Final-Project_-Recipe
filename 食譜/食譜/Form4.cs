using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace 食譜
{
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-UGLUQ41A\\SQLEXPRESS; Initial Catalog = recipe; Integrated security =true");
        SqlDataReader DBReader;
        SqlCommand DBCommand;
        string num;

        public Form4()
        {
            InitializeComponent();
            conn.Open();
            SqlDataAdapter myDa = new SqlDataAdapter("select 食譜名稱, 份量, 食譜描述 from 食譜 where 使用者編號 = ('" + Form8.number + "')  ", conn);
            DataSet DS = new DataSet();
            myDa.Fill(DS, "我的食譜");
            dataGridView1.DataSource = DS.Tables["我的食譜"];
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select count(*) from 食譜 where 使用者編號 = ('10011')";
            DBReader = cmd.ExecuteReader();
            DBReader.Read();
            num = DBReader[0].ToString();
            button1.Text = num + "份食譜";



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable m = new DataTable();
            m.Columns.Add("食譜名稱", typeof(string));
            m.Columns.Add("食譜", typeof(string));
            m.Columns.Add("成品圖片", typeof(Image));
            dataGridView1.DataSource = m;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source = LAPTOP-UGLUQ41A\\SQLEXPRESS; Initial Catalog = recipe; Integrated security =true");
            conn.Open();
            DBCommand = new SqlCommand("SELECT 食譜編號 from 收藏 where 使用者編號 in  ('" + Form8.number + "')", conn);

            SqlDataAdapter myDa = new SqlDataAdapter("select * from 收藏 C join 食譜 R on C.食譜編號 = R.食譜編號 where R.使用者編號 = ('" + Form8.number + "')  ", conn);
            DataSet DS = new DataSet();
            myDa.Fill(DS, "收藏食譜");
            dataGridView1.DataSource = DS.Tables["收藏食譜"];

        }
        /* SELECT COUNT(*) FROM(SELECT Id, Name FROM 收藏

    _
         DBReader = DBCommand.ExecuteReader();
         int[] array = new int[30];
         for (int i=0; i<)*/
   
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
