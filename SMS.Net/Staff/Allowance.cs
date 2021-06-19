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
    public partial class Allowance : Form
    {
        public static int aid;
        public static SqlCommand cmd = new SqlCommand();
        public Allowance()
        {
            InitializeComponent();
            BindGrid();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "INSERT INTO  AllowanceInfo(AllowanceName) VALUES('"+textBox1.Text.Trim()+"')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Allwance added successfully!!");
                BindGrid();               
                textBox1.Text = string.Empty;
               // AddNewButton.Enabled = false;
            }
        }

        private void Allowance_Load(object sender, EventArgs e)
        {
           
        }
        private void BindGrid()
        {
            cmd.CommandText = "SELECT * FROM AllowanceInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            aid =Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            textBox1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.AllowanceInfo WHERE AllowanceId='" + aid + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["AllowanceName"].ToString();
                
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
           // UpdateButton.Enabled = true;
           // EditButton.Enabled = false;
            textBox1.Enabled = true;
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
           // EditButton.Enabled = false;
           


        }
        
        private void CLoseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void DeleteButtton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM dbo.AllowanceInfo WHERE AllowanceId='"+aid+"'";
            int x=DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Deleted successfuly");
                BindGrid();
            }
            else
            {
                MessageBox.Show("Delete unsuccessful");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
