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
    public partial class AllowanceDefine : Form
    {
        public int alId;
        public int posId;
        public AllowanceDefine()
        {
            InitializeComponent();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            AddNewButton.Enabled = false;
            SaveButton.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AllowanceDefine_Load(object sender, EventArgs e)
        {
         
            BindStaffPost();
            BindAllowance();
        }
        private void BindStaffPost()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  * FROM PositionInfo";
            comboBox2.DisplayMember = "PositionName";
            comboBox2.ValueMember = "PositionId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox2.DataSource = dt;
        }
        private void BindAllowance()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  * FROM  [dbo].[AllowanceInfo]";
            AllowanceComboBox.DisplayMember = "AllowanceName";
            AllowanceComboBox.ValueMember = "AllowanceId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            AllowanceComboBox.DataSource = dt;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO [dbo].[AllowanceDetailInfo] (AllowanceId,PositionId,AllowanceAmount) VALUES('"+alId+"','"+posId+"','"+AllowanceAmountTextBox.Text.Trim()+"')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Allowance Details added Successfully!!");
                AllowanceComboBox.Text = "";
                AllowanceAmountTextBox.Text = "";
                comboBox2.Text = "";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AllowanceComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AllowanceComboBox.SelectedValue!=null)
            {
                alId = Convert.ToInt32(AllowanceComboBox.SelectedValue);
                //MessageBox.Show(alId.ToString());
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                posId = Convert.ToInt32(comboBox2.SelectedValue);
               // MessageBox.Show(posId.ToString());
            }
        }

        private void CLoseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    
   
    }
}
