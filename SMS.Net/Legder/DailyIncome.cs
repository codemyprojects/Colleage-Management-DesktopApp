using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Legder
{
    public partial class DailyIncome : Form
    {
        int id;
        public DailyIncome()
        {
            InitializeComponent();
        }

        private void DailyIncome_Load(object sender, EventArgs e)
        {
            EnableDisableControls(false);
            BindDataGrid();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            AddNewButton.Enabled = false;
            SaveButton.Enabled = true;
            EditButton.Enabled = false;
            UpdateButton.Enabled = false;
            DeleteButtton.Enabled = false;
            CLoseButton.Enabled = false;
            dateTimePicker1.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            NarrationRichTextBox.Enabled = true;
        }
        private void EnableDisableControls(bool b)
        {

            EditButton.Enabled = b;
            UpdateButton.Enabled = b;
            DeleteButtton.Enabled = b;
            CLoseButton.Enabled = b;
            SaveButton.Enabled = b;
            dateTimePicker1.Enabled = b;
            textBox1.Enabled = b;
            textBox2.Enabled = b;
            textBox3.Enabled = b;
            NarrationRichTextBox.Enabled = b;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO dbo.DailyIncome(Sno,[Date],Particular,Amount,Narration) VALUES('"+Convert.ToInt32(textBox1.Text.Trim())+"','"+dateTimePicker1.Text+"','"+textBox2.Text.Trim()+"','"+Convert.ToInt32(textBox3.Text.Trim())+"','"+NarrationRichTextBox.Text.Trim()+"')";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                {
                    MessageBox.Show("Daily Income Added Succesfully!!");
                    dateTimePicker1.CustomFormat = null;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    NarrationRichTextBox.Text = string.Empty;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindDataGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM DailyIncome order by IncomeId desc";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                dataGridView1.DataSource = dt;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM DailyIncome WHERE IncomeId='" + id + "'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dateTimePicker1.Text = dr["Date"].ToString();
                        textBox1.Text = dr["Sno"].ToString();
                        textBox2.Text = dr["Particular"].ToString();
                        textBox3.Text = dr["Amount"].ToString();
                        NarrationRichTextBox.Text = dr["Narration"].ToString();
                    }
                    EditButton.Enabled = true;
                }
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show(id.ToString());
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            NarrationRichTextBox.Enabled = true;
            EditButton.Enabled = false;
            UpdateButton.Enabled = true;

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "UPDATE DailyIncome SET Sno='"+Convert.ToInt32(textBox1.Text.Trim())+"', Date='"+dateTimePicker1.Text+"',Particular='"+textBox2.Text.Trim()+"',Amount='"+Convert.ToDouble(textBox3.Text.Trim()+"',Narration='"+NarrationRichTextBox.Text.Trim()+"' WHERE IncomeId='"+id+"'";
                cmd.CommandText = "UPDATE DailyIncome SET Sno='"+textBox1.Text.Trim()+"',Date='"+dateTimePicker1.Text+"',Particular='"+textBox2.Text.Trim()+"',Amount='"+Convert.ToDouble(textBox3.Text.Trim())+"',Narration='"+NarrationRichTextBox.Text.Trim()+"' where IncomeId='"+id+"'";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if(x>0)
                {
                    MessageBox.Show("Daily Income Updated SUccessfully!!");
                    dateTimePicker1.CustomFormat = null;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    NarrationRichTextBox.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(dateTimePicker2.Text.Trim();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM DailyIncome WHERE Date='"+dateTimePicker2.Text.Trim()+"'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                if(dt.Rows.Count>0)
                {
                    dataGridView1.DataSource = dt;  }
                else
                {
                    MessageBox.Show("No Record found!!");
               
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteButtton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM dbo.DailyIncome WHERE IncomeId='"+id+"'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Record Deleted Successfully!!");
            }
        }

        private void CLoseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
