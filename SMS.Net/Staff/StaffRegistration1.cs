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
    public partial class StaffRegistration1 : Form
    {
        public static int did;
        public static int jobstatus;
        public static int positionId;
        public StaffRegistration1()
        {
            InitializeComponent();
        }

        private void BindDepartmentComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("staff.spDepartmentDisplay", null, true);
            DepartmentCombox.DisplayMember = "Department";
            DepartmentCombox.ValueMember = "DepartmentId";
            DepartmentCombox.DataSource = dt;
        }
        private void BindPositionInfo()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.PositionInfo";
            DataTable dt = new DataTable();
            dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox1.DisplayMember = "PositionName";
            comboBox1.ValueMember = "PositionId";
            comboBox1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Staff.StaffRegistration sr= new Staff.StaffRegistration();
            Common.Staff.Staffs staff = new Common.Staff.Staffs();
            staff.StaffCode = Common.Staff.StaticStaffs.StaffCode;
            staff.StaffName =Common.Staff.StaticStaffs.StaffName;
            staff.StaffGender= Common.Staff.StaticStaffs.StaffGender;
            staff.StaffContact=Common.Staff.StaticStaffs.StaffContact;
            staff.StaffMobile=Common.Staff.StaticStaffs.StaffMobile;
            staff.StaffEmail=Common.Staff.StaticStaffs.StaffEmail;
            staff.StaffAddress=Common.Staff.StaticStaffs.StaffAddress;
            staff.StaffPhoto=Common.Staff.StaticStaffs.StaffPhoto;
            staff.ImageData = Common.Staff.StaticStaffs.ImageData;
            staff.StaffNationality= Common.Staff.StaticStaffs.StaffNationality;
            staff.StaffAge=Common.Staff.StaticStaffs.StaffAge;
            staff.Religion = Common.Staff.StaticStaffs.Religion;
            staff.Caste = Common.Staff.StaticStaffs.Caste;
            staff.MaritalStatus = Common.Staff.StaticStaffs.MaritalStatus;


            //collection data from the Registration1 form
            Common.Staff.Department d=new Common.Staff.Department();
            d.DepartmentId = did;
            staff.StaffQualification = QualificationTextBox.Text.Trim();
            staff.StaffPost =positionId;
           // staff.StaffEnrollMentDate = null;
          //  staff.StaffSalary = Convert.ToDouble(SalaryTextBox.Text.Trim());
            //staff.StaffContractTerminationDate = null;
            staff.JobStatus = jobstatus;
            if (YesRadioButton.Checked == true)
                staff.PreviousExperience = true;
            if (NoRadioButton.Checked == true)
                staff.PreviousExperience = false;
            staff.NoOfYea = NoOfYearTextBox.Text.Trim();
            staff.PreviousEmployer = PreviousEmployeerTextBox.Text.Trim();
            staff.Remarks = RemarkTextBox.Text.Trim();
            if(TeachingCheckBox.Checked==true)
                staff.StaffType = TeachingCheckBox.Text.Trim();
            if (NonTeachingCheckBox.Checked == true)
                staff.StaffType = NonTeachingCheckBox.Text.Trim();
            staff.Subject1 = Subject1TextBox.Text.Trim();
            staff.Subject2 = Subject2TextBox.Text.Trim();
            staff.Subject3 = Subject3TextBox.Text.Trim();
            staff.Subject4 = Subject4TextBox.Text.Trim();
           int row= BusinessLayer.Staff.StaffDataAccess.AddStaff(staff,d);
            if(row>0)
            {
                MessageBox.Show("Staff Enrolled Successfyll!");
                DepartmentCombox.Text = "";
                QualificationTextBox.Text = string.Empty;
                comboBox1.Text = "";
                EnrollDateTextBox.Text = string.Empty;
                SalaryTextBox.Text = string.Empty;
                ContractTerminationTextBox.Text = string.Empty;
                comboBox2.Text = "";
                TeachingCheckBox.Checked = false;
                NonTeachingCheckBox.Checked = false;
                Subject1TextBox.Text = string.Empty;
                Subject2TextBox.Text = string.Empty;
                Subject3TextBox.Text = string.Empty;
                Subject4TextBox.Text = string.Empty;
                YesRadioButton.Checked = false;
                NoRadioButton.Checked = false;
                NoOfYearTextBox.Text = string.Empty;
                RemarkTextBox.Text = string.Empty;
                PreviousEmployeerTextBox.Text = string.Empty;
            }


        }

        private void StaffRegistration1_Load(object sender, EventArgs e)
        {
            BindDepartmentComboBox();
            Bindstatus();
            BindPositionInfo();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DepartmentCombox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(DepartmentCombox.SelectedValue!=null)
            {
                did =Convert.ToInt32(DepartmentCombox.SelectedValue);
                //MessageBox.Show(did.ToString());
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                jobstatus = Convert.ToInt32(comboBox2.SelectedValue);
            }
        }
        private void Bindstatus()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.JobStatusInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox2.DisplayMember = "JobStatus";
            comboBox2.ValueMember = "JobStatusId";
            comboBox2.DataSource = dt;

        }

        private void YesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(YesRadioButton.Checked==true)
            {
                NoOfYearTextBox.Enabled = true;
                PreviousEmployeerTextBox.Enabled = true;
                RemarkTextBox.Enabled = true;
            }
        }

        private void NoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (NoRadioButton.Checked == true)
            {
                NoOfYearTextBox.Enabled = false;
                PreviousEmployeerTextBox.Enabled = false;
                RemarkTextBox.Enabled = false;
            }
        }

        private void TeachingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TeachingCheckBox.Checked)
            {
                groupBox2.Enabled = true;
                NonTeachingCheckBox.Checked = false;
            }
            
        }

        private void NonTeachingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(NonTeachingCheckBox.Checked)
            {
                groupBox2.Enabled = false;
                TeachingCheckBox.Checked = false;
            }
            
        }

        private void Subject4TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                positionId = Convert.ToInt32(comboBox1.SelectedValue);
            }
        }

    }
}
