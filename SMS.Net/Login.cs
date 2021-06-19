using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net
{
    public partial class Login : Form
    {
        public static string RoleCode = string.Empty;
        public static int RoleId = 1;
        public Login()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            

        }

        private void Login_Load(object sender, EventArgs e)
        {
            BindRoleComboBox();
            this.ActiveControl = UserNameTextBox;
            UserNameTextBox.Focus();
            //label3.Visible = false;
        }
        private bool ValidateTextBox()
        {
            TextBox[] txtBox = { UserNameTextBox, PasswordTextBox };
            for (int i = 0; i < txtBox.Length; i++)
            {
                if (txtBox[i].Text == string.Empty)
                {

                    MessageBox.Show("UserName OR Password Can't be Blank");
                    return false;
                }
            }
            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            // label3.Text = string.Empty;
            Application.Exit();
            //this.DialogResult = DialogResult.Cancel;
        }

        private void BindRoleComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("staff.spRoles", null, true);
            RoleComboBox.ValueMember = "RoleId";
            RoleComboBox.DisplayMember = "RoleName";
            RoleComboBox.DataSource = dt;
        }

        private void RoleComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MessageBox.Show(RoleComboBox.SelectedValue.ToString());
            if (RoleComboBox.SelectedValue != null)
            {
                // Common.Login.Login.RoleCode =RoleComboBox.SelectedValue.ToString();
                Common.Login.Login.RoleId = Convert.ToInt32(RoleComboBox.SelectedValue);
                RoleId = Common.Login.Login.RoleId;
            }


        }

        private void UserNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.ActiveControl = PasswordTextBox;
            //PasswordTextBox.Focus();
            //if (e.KeyChar == '\t' || e.KeyChar == (char)13)
            //{
            //    e.Handled = true;
            //}
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
                this.ActiveControl = PasswordTextBox;
                PasswordTextBox.Focus();
            }

        }

        private void UserNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab)
            //{
            //    //textBox1.AppendText(@"\t");

            //}
            //PasswordTextBox.Focus();
            if (e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = PasswordTextBox;
                PasswordTextBox.Focus();
            }
        }

        private void UserNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = PasswordTextBox;
                PasswordTextBox.Focus();
            }
        }

        private void UserNameTextBox_Enter(object sender, EventArgs e)
        {


            //this.ActiveControl = PasswordTextBox;
            //PasswordTextBox.Focus();
        }

        private void PasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!PasswordTextBox.AcceptsReturn)
                {
                    btnLogin.PerformClick();
                }
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            //    SMSMDI smsmdi = new SMSMDI();
            //    smsmdi.Show();
            //    this.Hide();
        }

        private void OkButton_Enter(object sender, EventArgs e)
        {

            if (ValidateTextBox())
            {
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@RoleId",RoleId),
                new SqlParameter("@UserName",UserNameTextBox.Text.Trim()),
                new SqlParameter("@Password",PasswordTextBox.Text.Trim())
    
            };
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[user].[spUsersInfo]", param, true);
                if (dt.Rows.Count == 1)
                {

                    //if (Common.Login.Login.RoleCode == "" || Common.Login.Login.RoleCode == string.Empty)
                    //   RoleCode = "Admin";
                    // else
                    // RoleCode = Common.Login.Login.RoleCode;
                    RoleId = Common.Login.Login.RoleId;
                    //MessageBox.Show(RoleCode);
                    //MessageBox.Show("Welcome!", "Main", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SMSMDI smsmdi = new SMSMDI();
                    smsmdi.Show();
                    this.Hide();
                }
                else
                {
                    //label3.Visible = true;
                    //label3.ForeColor = System.Drawing.Color.Red;
                    //label3.Text = "UserName OR Password Do not Match!!";
                    DialogResult res = MessageBox.Show("UserName OR Password Do not Match!!", "Access Denied", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        UserNameTextBox.Focus();
                        UserNameTextBox.Text = string.Empty;
                        PasswordTextBox.Text = string.Empty;
                    }


                }
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (ValidateTextBox())
            //{
            //    SqlParameter[] param = new SqlParameter[]
            //{
            //    new SqlParameter("@RoleId",RoleId),
            //    new SqlParameter("@UserName",UserNameTextBox.Text.Trim()),
            //    new SqlParameter("@Password",PasswordTextBox.Text.Trim())
    
            //};
            //    //DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[user].[spUsersInfo]",param, true);

            //    SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("[user].[spUsersInfo]", param, true);
            //    sdr.Read();
            //    if (String.Compare(sdr["UserName"].ToString(), UserNameTextBox.Text.Trim()) == 0 )
            //    {
            //        MessageBox.Show("Welcome!!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Password do not match");
            //    }

            //PASSWORD DECODING
            
            if (ValidateTextBox())
            {
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@RoleId",RoleId),
                new SqlParameter("@UserName",UserNameTextBox.Text.Trim()),
                new SqlParameter("@Password",PasswordTextBox.Text.Trim())
    
            };
                SqlParameter[] param1 = new SqlParameter[]
            {
                new SqlParameter("@RoleId",RoleId),
                new SqlParameter("@UserName",UserNameTextBox.Text.Trim()),
                new SqlParameter("@Password",PasswordTextBox.Text.Trim())
    
            };
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[user].[spUsersInfo]", param, true);
                SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("[user].[spUsersInfo]", param1, true);
                sdr.Read();

                //PASSWORD DECODING
                //MD5CryptoServiceProvider md5hasher = new MD5CryptoServiceProvider();
                //byte[] pass;
                //UTF8Encoding enc = new UTF8Encoding();
                //pass = md5hasher.ComputeHash(enc.GetBytes(PasswordTextBox.Text.Trim()));



                if (dt.Rows.Count == 1)
                // if (dt.Rows.Count == 1 && string.Equals(sdr["UserName"].ToString().ToUpper(),UserNameTextBox.Text.Trim()) && string.Equals(sdr["Password"].ToString(),PasswordTextBox.Text.Trim()))
                {

                    //if (Common.Login.Login.RoleCode == "" || Common.Login.Login.RoleCode == string.Empty)
                    //   RoleCode = "Admin";
                    // else
                    if(String.Compare(sdr["UserName"].ToString(), UserNameTextBox.Text.Trim()) == 0 && String.Compare(sdr["Password"].ToString(),PasswordTextBox.Text.Trim())==0)
                    {
                        RoleCode = Common.Login.Login.RoleCode;
                        //   MessageBox.Show(UserNameTextBox.Text.ToString());
                        //MessageBox.Show("Welcome!", "Main", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SMSMDI smsmdi = new SMSMDI();
                        smsmdi.Show();
                        this.Hide();

                    }
                    

                }
                else
                {
                    //label3.Visible = true;
                    //label3.ForeColor = System.Drawing.Color.Red;
                    //label3.Text = "UserName OR Password Do not Match!!";
                    DialogResult res = MessageBox.Show("UserName OR Password Do not Match!!", "Access Denied", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        UserNameTextBox.Focus();
                        UserNameTextBox.Text = string.Empty;
                        PasswordTextBox.Text = string.Empty;
                    }


                }
            }

            }












        }
    }
