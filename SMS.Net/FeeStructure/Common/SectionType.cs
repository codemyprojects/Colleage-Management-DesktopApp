using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Common
{
    public partial class SectionType : Form
    {
        public static int sid;
        
        public SectionType()
        {
            InitializeComponent();
        }

        private void SectionType_Load(object sender, EventArgs e)
        {
            EditButton.Enabled = false;
            SaveButton.Enabled = false;
            DeleteButton.Enabled = false;
            SectionTypeTextBox.Enabled = false;
            BindDataGrid();
            
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            SectionTypeTextBox.Enabled = true;
            AddButton.Enabled = false;
            SaveButton.Enabled = true;
            UpdateButton.Enabled = false;
            EditButton.Enabled = false;
            if(SectionTypeTextBox.Text==string.Empty)
            {
                MessageBox.Show("Please type Section type");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;
            sid =Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            SectionTypeTextBox.Text=Convert.ToString(dataGridView1[1,e.RowIndex].Value);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            AddButton.Enabled = false;
            SaveButton.Enabled = false;
            UpdateButton.Enabled = false;
            EditButton.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM student.SectionInfo where SectionId='"+sid+"'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Delete Successfully");
                BindDataGrid();
            }
        }
        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.SectionInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;


        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            AddButton.Enabled = false;
            SaveButton.Enabled = false;
            EditButton.Enabled = false;
            UpdateButton.Enabled = true;
            DeleteButton.Enabled = false;
            SectionTypeTextBox.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            AddButton.Enabled = true;
            SaveButton.Enabled = false;
            SectionTypeTextBox.Enabled = true;
            UpdateButton.Enabled = false;
            DeleteButton.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into student.SectionInfo(SectionName) values ('" + SectionTypeTextBox.Text.Trim() + "')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("New record item inserted");
                BindDataGrid();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            AddButton.Enabled = false;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update student.SectionInfo set SectionName='" + SectionTypeTextBox.Text.Trim() + "'  where SectionId='" + sid + "'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Successfully updated");
                BindDataGrid();
            }
        }


    }
}
