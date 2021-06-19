using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Class
{
    public partial class ClassAdd : Form
    {
        public static int cid;
        public ClassAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassCodeTextBox.Enabled = true;
            ClassTextBox.Enabled = true;
            AddNewButton.Enabled = false;
            SaveButton.Enabled = true;
            UpdateButton.Enabled = false;
            CancelButton.Enabled = true;
                      
            

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            AddNewButton.Enabled = true;
            SaveButton.Enabled = false;
            UpdateButton.Enabled = false;
            CancelButton.Enabled = true;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into student.ClassInfo(Class) values ('" + ClassTextBox.Text.Trim() + "')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("New record item inserted");
                BindDataGrid();
            }
            else
            {
                MessageBox.Show("New Record Item Not Added!");
            }
            
        }

        private void ClassAdd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMSDataSet.ClassInfo' table. You can move, or remove it, as needed.
            this.classInfoTableAdapter.Fill(this.sMSDataSet.ClassInfo);
            AddNewButton.Enabled = true;
            SaveButton.Enabled = false;
            UpdateButton.Enabled = false;
            CancelButton.Enabled = true;
            ClassCodeTextBox.Enabled = false;
            ClassTextBox.Enabled = false;

            ClassCodeTextBox.Text = GetRandomCode();
            ClassCodeTextBox.ReadOnly = true;
            EnableDisableControls(false);

        }
        private string GetRandomCode()
        {
            var chars = "CL84";
            var stringChars = new char[3];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;

        }

        private void EnableDisableControls(bool x)
        {
            SaveButton.Enabled = x;
            ClassTextBox.Enabled = x;
        
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            AddNewButton.Enabled = true;
            SaveButton.Enabled = false;
            UpdateButton.Enabled =  false;
            CancelButton.Enabled = true;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE student.ClassInfo set Class='"+ClassTextBox.Text.Trim()+"' where ClassId='"+cid+"'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Update Data SuccessFully");
                BindDataGrid();
            }

            
        }

        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student.ClassInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            dataGridView1.DataSource = dt;


        }


        //private void ModifyButton_Click(object sender, EventArgs e)
        //{
        //    AddNewButton.Enabled = true;
        //    SaveButton.Enabled = false;
        //    ModifyButton.Enabled = false;
        //    UpdateButton.Enabled = true;
        //    CancelButton.Enabled = true;
            
        //}

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AddNewButton.Enabled = false;
            SaveButton.Enabled = false;
            UpdateButton.Enabled = true;
            CancelButton.Enabled = true;
            ClassTextBox.Enabled = true;

            cid = Convert.ToInt32(dataGridView1[0,e.RowIndex].Value);
            ClassTextBox.Text = Convert.ToString(dataGridView1[1,e.RowIndex].Value);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
