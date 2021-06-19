using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net.Staff
{
    public partial class AddDepartment : Form
    {
        public AddDepartment()
        {
            InitializeComponent();
            SaveButton.Enabled = false;
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {  
            SaveButton.Enabled=true;
            AddNewButton.Enabled = false;
            EnableDisableControls(true);
         
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(ValiDateTextBox())
            {
                Common.Staff.Department department = new Common.Staff.Department();
                department.DepartmentCode = DepartmentCodeTextBox.Text.Trim();
                department.DepartmentName = DepartmentNameTextBox.Text.Trim();
                department.DepartmentDescription = DepartmentDescriptionRichTextBox.Text.Trim();
                int row = BusinessLayer.Staff.StaffDataAccess.AddDepartment(department);
                if (row > 0)
                {
                    MessageBox.Show("Department Added Successfully!!");
                    DepartmentNameTextBox.Text = string.Empty;
                    DepartmentDescriptionRichTextBox.Text = string.Empty;
                    DepartmentCodeTextBox.Text = string.Empty;

                }
                ClearControls();
                EnableDisableControls(false);
                AddNewButton.Enabled = true;
            }
           
           
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddDepartment_Load(object sender, EventArgs e)
        {
            EnableDisableControls(false);
            DepartmentCodeTextBox.ReadOnly = true;
            DepartmentCodeTextBox.Text = GetRandomCode();
        }
        private string GetRandomCode()
        {
            var chars = "0123456789";
            var stringChars = new char[2];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return "D"+finalString;

        }
        private void EnableDisableControls(bool x)
        {
            SaveButton.Enabled = x;
            DepartmentNameTextBox.Enabled = x;
            DepartmentDescriptionRichTextBox.Enabled = x;
        }
        
        private bool ValiDateTextBox()
        {
            TextBox[] txtBox = {DepartmentCodeTextBox,DepartmentNameTextBox};
            for(int i=0;i<txtBox.Length;i++)
            {
                if(txtBox[i].Text==string.Empty)
                {
                    MessageBox.Show("Please Donot Leave TextBox Empty");
                    txtBox[i].Focus();
                    return false;
                }
            }
            return true;
        }
        private void ClearControls()
        {
            DepartmentCodeTextBox.Text = string.Empty;
            DepartmentNameTextBox.Text = string.Empty;
            DepartmentDescriptionRichTextBox.Text = string.Empty;
        }
      
    }
}
