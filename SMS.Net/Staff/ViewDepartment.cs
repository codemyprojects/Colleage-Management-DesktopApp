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
    public partial class ViewDepartment : Form
    {
        public ViewDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void BindDepartmentComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("staff.spDepartmentDisplay", null, true);
            DepartmentCodeComboBox.DisplayMember = "Department";
            DepartmentCodeComboBox.ValueMember = "DepartmentId";
            DepartmentCodeComboBox.DataSource = dt;
        }
        private void EnableDisableReadOnly(bool b)
        {
            DepartmentCodeTextBox.ReadOnly = b;
            DepartmentNameTextBox.ReadOnly = b;
            DepartmentDescriptionRichTextBox.ReadOnly = b;
            TotalStaffs.ReadOnly = b;

        }

        private void ViewDepartment_Load(object sender, EventArgs e)
        {
            BindDepartmentComboBox();
            panel2.Visible = false;

        }

        private void DepartmentCodeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(DepartmentCodeComboBox.SelectedValue!=null)
            {
                Common.Staff.Department department = new Common.Staff.Department();
                department.DepartmentId = Convert.ToInt32(DepartmentCodeComboBox.SelectedValue.ToString());
                SqlDataReader sdr = BusinessLayer.Staff.StaffDataAccess.GetDepartmentById(department);
                panel2.Visible = true;
                EnableDisableReadOnly(true);
                SqlDataReader dr = BusinessLayer.Staff.StaffDataAccess.GetTotalStaffByDepartmentId(department);
                TotalStaffs.Text = dr["TotalStaffs"].ToString();
                DepartmentCodeTextBox.Text = sdr["DepartmentCode"].ToString();
                DepartmentNameTextBox.Text = sdr["DepartmentName"].ToString();
                DepartmentDescriptionRichTextBox.Text = sdr["DepartmentDescription"].ToString();
            }
        }

        private void DepartmentCodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
