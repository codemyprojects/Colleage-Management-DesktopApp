using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net.user
{
    public partial class ChangePassword : Form
    {
        int roleId;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Login.RoleId == 0 || Login.RoleId == 1)
            {
                SaveButton.Enabled = true;
                EnableDisableContols(true);
                UserNameTextBox.Focus();
                ChangeButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("You are not Administrator","Access Denied");
            }
            
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
             EnableDisableContols(false);
            //BindRoleComboBox();
             SaveButton.Enabled = false;
            //panel1.Visible = false;
            //panel2.Visible = false;
        }
        private void EnableDisableContols(bool b)
        {
            UserNameTextBox.Enabled = b;
            OldPasswordTextBox.Enabled = b;
            NewPasswordTextBox.Enabled = b;
            RetypePasswordTextBox.Enabled = b;
        }
        private void BindRoleComboBox()
        {
            //    DataTable dt = DataBaseLayer.DbOperations.GetDataTable("staff.spRoleView", null, true);
            //    RoleComboBox.DisplayMember = "Role";
            //    RoleComboBox.ValueMember = "RoleId";
            //    RoleComboBox.DataSource = dt;
        }

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Login.RoleId.ToString()); 
            SqlParameter[] p = new SqlParameter[]
            {
              //  new SqlParameter("@RoleId",Login.RoleId),
                new SqlParameter("@UserName",UserNameTextBox.Text.Trim()),
                new SqlParameter("@OldPassword",OldPasswordTextBox.Text.Trim()),
                new SqlParameter("@NewPassword",NewPasswordTextBox.Text.Trim())

            };
            if(NewPasswordTextBox.Text.Trim()!=RetypePasswordTextBox.Text.Trim())
            {
                MessageBox.Show("New Password && Retype Password Do not Match", "Please Try Again");
            }
             else
            {
                int row = DataBaseLayer.DbOperations.ExecProc("student.spUpdatePassword", p, true);
                if (row == 1)
                {
                    MessageBox.Show("Password Changed Sucessfully", "Congrats!!");
                }

            }
         
             //SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("[user].spShowUserNamePassword", p, true);
             //SqlDataReader sdr = (SqlDataReader)DataBaseLayer.DbOperations.GetScalarValue("[user].[spSysteUsers]", null, true);
             //sdr.Read();
             //if (sdr["UserName"].ToString() == UserNameTextBox.Text.Trim() || sdr["Password"].ToString() == RetypePasswordTextBox.Text.Trim())
             //{
             //    MessageBox.Show("Invalid User Or Password!!", "Please Try Again");
             //}
            }
         
        
        private void BindUserNameComboBox()
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewPasswordTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            CheckPassword();
        }
        private void CheckPassword()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                //new SqlParameter("@RoleId",Login.RoleId),
                new SqlParameter("@UserName",UserNameTextBox.Text.Trim()),
                new SqlParameter("@Password",OldPasswordTextBox.Text.Trim())

            };
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[user].spShowUserNamePassword", param, true);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Invalid UserName Or Old Password??", "Please Try Again");
            }
        }

        private void RoleComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(RoleComboBox.SelectedValue!=null)
            {
             //   roleId = Convert.ToInt32(RoleComboBox.SelectedValue);
            }
        }

       
      
    }
}
