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

namespace SMS.Net.Staff
{   
    public partial class StaffGeneralInfo : Form
    {
        public static string Scode;
        public static string staffCode;
        public StaffGeneralInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  // SqlCommand cmd=new SqlCommand();
           
            Common.Staff.Staffs staff = new Common.Staff.Staffs();
            if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Please Enter a Staff Code");
            }
            else
            {
                staff.StaffCode = textBox1.Text.Trim();
                DataTable dt = BusinessLayer.Staff.StaffDataAccess.GetStaffByCode(staff);
                SqlDataReader sdr = BusinessLayer.Staff.StaffDataAccess.GetByCode(staff);
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("No Record Found");
                }
                else
                {
                    dataGridView1.DataSource = dt;
                    panel1.Visible = true;
                    staffCode = sdr["StaffCode"].ToString();
                    textBox2.Text = sdr["StaffName"].ToString();
                    textBox3.Text = sdr["StaffMobile"].ToString();
                    textBox4.Text = sdr["StaffEmail"].ToString();
                    EnableDisableReadOnly(true);
                    EditButton.Enabled = true;
                    DeleteButton.Enabled = true;
                   
                }
             
            }
          
        }

        private void StaffGeneralInfo_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[staff].[spStaffsInfoDisplay]", null, true);
            dataGridView1.DataSource = dt;
        }

        private void EnableDisableReadOnly(bool b)
        {
            textBox2.ReadOnly = b;
            textBox3.ReadOnly = b;
            textBox4.ReadOnly = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff.EditStaffRegistration esr = new Staff.EditStaffRegistration();
            esr.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {   
            SqlParameter[] param=new SqlParameter[]
            {
                new SqlParameter("@StaffCode",textBox1.Text.Trim())
            };
           int x= DataBaseLayer.DbOperations.ExecProc("staff.spDeleteStaffRegistrationByCode", param, true);
            if(x>0)
            {
                MessageBox.Show("Record Deleted Successfully!!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int Scode=(int)dataGridView1[2,e.RowIndex].Value;
            textBox1.Text = (string)dataGridView1[3, e.RowIndex].Value;
        }
    }
}
