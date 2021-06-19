using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Staff
{
    public partial class Post : Form
    {
        public static SqlCommand cmd = new SqlCommand();
        public static int pid;
        public Post()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO [dbo].[PositionInfo] (PositionName) VALUES('"+textBox1.Text.Trim()+"')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Post Added Successfully!!");
                BindDataGrid();
            }
            else
            {
                MessageBox.Show("Post Can't be added due to some problem!!");
            }
        }

        private void Post_Load(object sender, EventArgs e)
        {
            BindDataGrid();
        }
        private void BindDataGrid()
        {
            cmd.CommandText = "SELECT * FROM [dbo].[PositionInfo]";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }

        private void CLoseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void DeleteButtton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM [dbo].[PositionInfo] WHERE PositionId='"+pid+"'";
            int x=DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Deleted successfuly");
                BindDataGrid();
            }
            else
            {
                MessageBox.Show("Delete failed");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pid = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            textBox1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [dbo].[PositionInfo] WHERE PositionId='" + pid + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["PositionName"].ToString();

            }
        }

    }
}
