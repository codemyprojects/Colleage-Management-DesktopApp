using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.FeeStructure.Common
{
    public partial class ReligionInfo : Form
    {
        int rid;
        public ReligionInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTo dbo.ReligionInfo(ReligionName)values('"+ReligionTextBox.Text.Trim()+"')";
            int x=DataBaseLayer.DbOperations.ExecProc(cmd);
           if(x==1)
           {

               MessageBox.Show("Data Inserted Successfully");
               BindDataGrid();

           }

        }
        public void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.ReligionInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM dbo.ReligionInfo WHERE ReligionId='"+rid+"'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Data Deleted Successfully");
                BindDataGrid();
            }
            
        }

        private void ReligionInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMSDataSet8.ReligionInfo' table. You can move, or remove it, as needed.
            this.religionInfoTableAdapter.Fill(this.sMSDataSet8.ReligionInfo);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rid=Convert.ToInt32(dataGridView1[0,e.RowIndex].Value);
            ReligionTextBox.Text = Convert.ToString(dataGridView1[1, e.RowIndex].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE dbo.ReligionInfo SET ReligionName='"+ReligionTextBox.Text.Trim()+"' WHERE ReligionId='"+rid+"'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Data Updated Successfully");
                BindDataGrid();
            }


        }
    }
}
