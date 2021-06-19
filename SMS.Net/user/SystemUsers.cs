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
    public partial class SystemUsers : Form
    {   public static int UId;
        public static int RCode;
        private int rowIndex = 0;
        public SystemUsers()
        {
            InitializeComponent();
        }
        private void SystemUsers_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            SaveButton.Enabled = false;
            RoleLabel.Visible = false;
            RoleComboBox.Visible = false;
            EnableDisableControls(true);
            dataGridView1.DataSource = BusinessLayer.user.users.GetSystemUsers();
            //BindRoleComboBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            RoleNameTextBox.ReadOnly = true;
            button2.Enabled = false;
            BindRoleComboBox();
            EnableDisableControls(false);
            RoleLabel.Visible = true;
            RoleComboBox.Visible = true;
        }

        public void CreateButton_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId",UId),
                new SqlParameter("@RoleId",RCode),
                new SqlParameter("@UserName",UserNameTextBox.Text.Trim()),
                new SqlParameter("@Password",UserPasswordTextBox.Text.Trim()),
                new SqlParameter("@RetypePassword",RetypePasswordTextBox.Text.Trim())
            };
            int x=DataBaseLayer.DbOperations.ExecProc("[user].spUpdateUser",param,true);
            if(x==1)
            {
                MessageBox.Show("User Record Updated Successfully!!");
                dataGridView1.DataSource = BusinessLayer.user.users.GetSystemUsers();
            }
        }
        protected void BindRoleComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("staff.spRoleView", null, true);
            RoleComboBox.DisplayMember = "Role";
            RoleComboBox.ValueMember = "RoleId";
            RoleComboBox.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Common.user.UsersInfo u = new Common.user.UsersInfo();
            u.UserId =(int)dataGridView1[0, e.RowIndex].Value;
            UId = u.UserId;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId",u.UserId)
            };
            SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("[user].spSystemUserBuId", param, true);
            sdr.Read();
            groupBox1.Visible = true;
            button2.Enabled = true;
           // EnableDisableControls(true);
            RoleNameTextBox.Text = sdr["RoleName"].ToString();
            //RoleComboBox.ValueMember = sdr["RoleName"].ToString();
            UserNameTextBox.Text = sdr["UserName"].ToString();
            UserPasswordTextBox.Text = sdr["Password"].ToString();
            RetypePasswordTextBox.Text = sdr["RetypePassword"].ToString();
           // MessageBox.Show(u.UserId.ToString());

        }

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void RoleComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //RoleNameTextBox.Clear();
            if(RoleComboBox.SelectedValue!=null)
            {
                
                RCode = Convert.ToInt32(RoleComboBox.SelectedValue.ToString());
                //RoleNameTextBox.Text = RoleComboBox.SelectedText.ToString();
                //MessageBox.Show(RoleComboBox.SelectedValue.ToString());
                if(Convert.ToInt32(RoleComboBox.SelectedValue)==2)
                {
                    RoleNameTextBox.ReadOnly = true;
                    RoleNameTextBox.Text = "(Usr) User";
                    RoleComboBox.Visible = false;
                    RoleLabel.Visible = false;
                }
                else
                {
                    RoleNameTextBox.ReadOnly = true;
                    RoleNameTextBox.Text = "(Admin) Administrator";
                    RoleComboBox.Visible = false;
                    RoleLabel.Visible = false;
                }
                
            }
        }
        private void EnableDisableControls(bool b)
        {
            RoleNameTextBox.ReadOnly = b;
            UserNameTextBox.ReadOnly = b;
            UserPasswordTextBox.ReadOnly = b;
            RetypePasswordTextBox.ReadOnly = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Common.user.UsersInfo u = new Common.user.UsersInfo();
          //  u.UserId = (int)dataGridView1[0, e.RowIndex].Value;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@UserId",UId)
            };
            int x = DataBaseLayer.DbOperations.ExecProc("[user].spDeleUserById", param, true);
            if(x==1)
            {
                MessageBox.Show("User Deleted Successfully!!");
                dataGridView1.DataSource = BusinessLayer.user.users.GetSystemUsers();
            }
            else
            {
                MessageBox.Show("Due to some problem User Can't be deleted");
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) 
            {
                DialogResult res = MessageBox.Show("Are you sure", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res==DialogResult.Yes)
                {
                    this.dataGridView1.Rows[e.RowIndex].Selected = true;
                   // this.rowIndex = e.RowIndex;
                    //MessageBox.Show(this.rowIndex.ToString());
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                    ////MessageBox.Show(this.dataGridView1.CurrentCell.ToString());
                    //MessageBox.Show(dataGridView1[0, e.RowIndex].Value.ToString());
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "DELETE FROM [user].UsersInfo WHERE UserId='" + Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString()) + "'";
                    int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                    dataGridView1.DataSource = BusinessLayer.user.users.GetSystemUsers();
                }
              
                //this.contextMenuStrip1.Show(this.dataGridView1, e.Location); 
                //contextMenuStrip1.Show(Cursor.Position); 
            }
        }

       
    }
}

