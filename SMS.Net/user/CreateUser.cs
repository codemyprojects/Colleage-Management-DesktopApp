using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SMS.Net.user
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
{
            //EnableDisableControls(true);
            Common.user.UsersInfo u = new Common.user.UsersInfo();
            Common.Staff.Roles role = new Common.Staff.Roles();
            role.RoleId =Convert.ToInt32(RoleComboBox.SelectedValue.ToString());
            u.UserName = UserNameTextBox.Text.Trim().ToLower();

            //MD5CryptoServiceProvider md5hasher = new MD5CryptoServiceProvider();
            //byte[] pass;
            //byte[] cpass;
            //UTF8Encoding enc = new UTF8Encoding();
            //pass = md5hasher.ComputeHash(enc.GetBytes(UserPasswordTextBox.Text.Trim()));
            //cpass = md5hasher.ComputeHash(enc.GetBytes(RetypePasswordTextBox.Text.Trim()));

            //pass = md5hasher.ComputeHash(enc.GetBytes("g"));
            //cpass = md5hasher.ComputeHash(enc.GetBytes("g"));
            
            //MessageBox.Show(pass.ToString());
            //MessageBox.Show(cpass.ToString());

            u.Password = UserPasswordTextBox.Text.Trim();
            role.RetypePassword = RetypePasswordTextBox.Text.Trim();
            if(UserNameTextBox.Text==string.Empty||UserPasswordTextBox.Text==string.Empty)
            {
                MessageBox.Show("Supply Username & Password", "Read Message");
            }
            {
                if (u.Password == role.RetypePassword)
                {
                    int x = BusinessLayer.user.users.CreateUser(u, role);
                    if (x > 0)
                    {
                        MessageBox.Show("User Created Successfully!!");
                        clearcontrols();
                    }
                }
                else
                {
                    MessageBox.Show("Password & Retype Password do not match!!");
                }
            }
            
           
        }

        private void RoleComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(RoleComboBox.SelectedValue!=null)
            {
                Common.Staff.Roles role = new Common.Staff.Roles();
                role.RoleId = Convert.ToInt32(RoleComboBox.SelectedValue.ToString());
            }
        }
        private void BindRoleComboBox()
        {
           DataTable dt = DataBaseLayer.DbOperations.GetDataTable("staff.spRoleView", null, true);
           RoleComboBox.DisplayMember = "Role";
           RoleComboBox.ValueMember = "RoleId";
           RoleComboBox.DataSource = dt;
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            BindRoleComboBox();
            EnableDisableControls(false);
            CreateButton.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void EnableDisableControls(bool b)
        {
            UserNameTextBox.Enabled = b;
            UserPasswordTextBox.Enabled = b;
            RetypePasswordTextBox.Enabled = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CreateButton.Enabled = true;
            EnableDisableControls(true);
            button2.Enabled = false;
        }
        private void clearcontrols()
        {
            UserNameTextBox.Text = "";
            UserPasswordTextBox.Text = "";
            RetypePasswordTextBox.Text = "";
        }

        private void RetypePasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            CreateButton.Enabled = true;
        }
    }
}
