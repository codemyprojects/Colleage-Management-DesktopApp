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
    public partial class Advance : Form
    {
        int adv;
        public Advance()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="INSERT INTO AdvanceInfo(AdvanceName)values('"+textBox1.Text.Trim()+"')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Data Inserted Successfully");
                BindDataGrid();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.AdvanceInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            adv = Convert.ToInt32(dataGridView1[0,e.RowIndex].Value);
            textBox1.Text = Convert.ToString(dataGridView1[1,e.RowIndex].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM AdvanceInfo where AdvanceId='"+adv+"'; ";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Data Deleted Successfully");
                BindDataGrid();
            }
        }

        private void Advance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMSDataSet7.AdvanceInfo' table. You can move, or remove it, as needed.
            this.advanceInfoTableAdapter.Fill(this.sMSDataSet7.AdvanceInfo);

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update dbo.AdvanceInfo set AdvanceName='" +textBox1.Text+ "'  where AdvanceId='" + adv + "'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Successfully updated");
                BindDataGrid();
            }
        }

        private void CLoseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
