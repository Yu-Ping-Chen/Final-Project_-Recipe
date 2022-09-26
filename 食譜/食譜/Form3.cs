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
    public partial class 編輯個人頁面 : Form
    {
        SqlConnection conn;
        SqlDataReader reader;
        SqlCommand comm;
        byte[] arr;
        byte[] MyData = new byte[0];

        public 編輯個人頁面()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "(*.jpg;*.bmp;*png)|*.jpeg;*.jpg;*.bmp;*.png|AllFiles(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(dialog.FileName);
            }
            pictureBox1.Image = Image.FromFile(dialog.FileName);
            Bitmap bmp = new Bitmap(dialog.FileName);
            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source = LAPTOP-UGLUQ41A\\SQLEXPRESS ;Initial Catalog =recipe;Integrated Security = True");
            conn.Open();
            string username = Form8.username;
            string text = Form8.text;
            //byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(Form8.pic);  //可能出錯 null時
            //comm = new SqlCommand("select *from 會員資料  ")
            
            if (textBox1.Text !="") 
                Form8.username = textBox1.Text;
            if (textBox2.Text != "")
                Form8.text = textBox2.Text;
            if (arr == null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from 會員資料 where 使用者編號 =10012"; //寫自己要查圖片的主鍵
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                object o = sdr["使用者頭貼"];
                MyData = (byte[])sdr["使用者頭貼"];//讀取第一個圖片的位流
                MemoryStream memoryStream = null;
                memoryStream = new MemoryStream(MyData);
                //pictureBox1.Image = Image.FromStream(memoryStream); //將圖片賦給pictureBox1控制元件
                sdr.Close();
            }
            else
                Form8.ppic = arr.GetType(); 

            string ProfileUpdate = "UPDATE 會員資料 SET [使用者名稱] = ('" + username + "'), [個人簡介] = ('" + text + "'), [使用者頭貼] = ('" + arr + "') WHERE [使用者編號] = '10012'"; // WHERE [使用者編號] = ('" + Form8.number + "') //登入後使用者的編號
            comm = new SqlCommand(ProfileUpdate, conn);
            reader = comm.ExecuteReader();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
