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
    public partial class 新增食譜 : Form
    {
        SqlConnection conn;
        SqlDataReader DBReader;
        SqlCommand DBCommand;
        SqlDataAdapter DBAdapter;
        DataTable DBTable = new DataTable();
        byte[] arr;
        public 新增食譜()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
        }
        
        public void panel1_MouseWheel(object sender , MouseEventArgs e)
        {
          //  panel1.VerticalScroll.Value += 10;
          //  panel1.Refresh();
          //  panel1.Invalidate();
          //  panel1.Update();
        }

      /*  private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            this.panel1.Focus();
        }*/

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("食材名稱", typeof(string));
            dataTable.Columns.Add("食材分量", typeof(string));
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable step = new DataTable();
            step.Columns.Add("步驟名稱", typeof(string));
            step.Columns.Add("步驟圖片", typeof(Image));
            dataGridView1.DataSource = step;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source = LAPTOP-UGLUQ41A\\SQLEXPRESS; Initial Catalog = recipe; Integrated security =true");
            conn.Open();
            DBCommand = new SqlCommand("INSERT INTO 食譜 VALUES(@食譜名稱, @烹飪時長, @份量, @成品照片, @食譜描述)", conn); //inset至資料庫的資料表中
            DBCommand.Parameters.AddWithValue("@食譜名稱", textBox1.Text); 
            DBCommand.Parameters.AddWithValue("@烹飪時長", textBox2.Text); 
            DBCommand.Parameters.AddWithValue("@份量", textBox3.Text);
            DBCommand.Parameters.AddWithValue("@食譜描述", textBox6.Text);
            DBCommand.Parameters.AddWithValue("@成品照片", arr); 

            DBReader = DBCommand.ExecuteReader(); //執行

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
