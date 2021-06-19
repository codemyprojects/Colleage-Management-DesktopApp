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
    public partial class EditDepartment : Form
    {
        public EditDepartment()
        {
            InitializeComponent();
        }

        private void EditDepartment_Load(object sender, EventArgs e)
        {
            BindDepartmentComboBox();
            EnableDisableControls(false);
            EnableDisableReadOnly(true);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
                Common.Staff.Department department = new Common.Staff.Department();
                department.DepartmentId = Convert.ToInt32(DepartmentCodeComboBox.SelectedValue.ToString());
              //  MessageBox.Show(department.DepartmentId.ToString());
                department.DepartmentCode = DepartmentCodeTextBox.Text.Trim();
                department.DepartmentName = DepartmentNameTextBox.Text.Trim();
                department.DepartmentDescription = DepartmentDescriptionRichTextBox.Text.Trim();
                int row= BusinessLayer.Staff.StaffDataAccess.UpdateDepartment(department);
                if(row>0)
                {
                    MessageBox.Show("Updated Successfully!!");
                    DepartmentCodeComboBox.Text = "";
                    DepartmentCodeTextBox.Text =string.Empty;
                    DepartmentNameTextBox.Text = string.Empty;
                    DepartmentDescriptionRichTextBox.Text = string.Empty;

                }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Common.Staff.Department department = new Common.Staff.Department();
            department.DepartmentId = Convert.ToInt32(DepartmentCodeComboBox.SelectedValue.ToString());
            int row = BusinessLayer.Staff.StaffDataAccess.DeleteDepartment(department);
            if (row > 0)
            {
                MessageBox.Show("Department Deleted Successfully!!");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void BindDepartmentComboBox()
        {
          DataTable dt=  DataBaseLayer.DbOperations.GetDataTable("staff.spDepartmentDisplay", null, true);
          DepartmentCodeComboBox.DisplayMember = "Department";
          DepartmentCodeComboBox.ValueMember = "DepartmentId";
          DepartmentCodeComboBox.DataSource = dt;
        }

        private void DepartmentCodeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(DepartmentCodeComboBox!=null)
            {
                Common.Staff.Department department = new Common.Staff.Department();
                department.DepartmentId = Convert.ToInt32(DepartmentCodeComboBox.SelectedValue.ToString());
                SqlDataReader sdr=BusinessLayer.Staff.StaffDataAccess.GetDepartmentById(department);
                EnableDisableReadOnly(true);
                EnableDisableControls(true);
                if(string.IsNullOrEmpty(sdr["DepartmentCode"].ToString()))
                {
                    MessageBox.Show("No Data is Present!!");
                }
                else
                {
                    DepartmentCodeTextBox.Text = sdr["DepartmentCode"].ToString();
                    DepartmentNameTextBox.Text = sdr["DepartmentName"].ToString();
                    DepartmentDescriptionRichTextBox.Text = sdr["DepartmentDescription"].ToString();
                }
               
                ///MessageBox.Show(department.DepartmentId.ToString());
            }

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EnableDisableReadOnly(false);
        }
        private void EnableDisableReadOnly(bool b)
        {
            DepartmentCodeTextBox.ReadOnly = b;
            DepartmentNameTextBox.ReadOnly = b;
            DepartmentDescriptionRichTextBox.ReadOnly = b;

        }
        private void EnableDisableControls(bool b)
        {
            SaveButton.Enabled = b;
            EditButton.Enabled = b;
            DeleteButton.Enabled = b;
        }
    }
}
