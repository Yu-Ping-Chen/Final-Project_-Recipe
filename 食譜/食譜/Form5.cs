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

namespace 食譜
{
    public partial class Form5 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-UGLUQ41A\\SQLEXPRESS; Initial Catalog = recipe; Integrated security =true");        
        public Form5()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //食材
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable step = new DataTable();
            step.Columns.Add("步驟名稱", typeof(string));
            step.Columns.Add("步驟圖片", typeof(Image));
            dataGridView1.DataSource = step;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) //食材
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from dbo.食材 as 食材, ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable(); //告訴GridView資料來源為誰
            dataTable.Columns.Add("食材名稱", typeof(string));
            dataTable.Columns.Add("食材分量", typeof(string));
            dataGridView1.DataSource = dataTable;
            da.Fill(dataTable);
            //dataGridView1.DataBind();//綁定
            conn.Close(); //連線關閉   */
        }
    }
}
