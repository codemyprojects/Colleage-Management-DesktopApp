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

namespace SMS.Net.Class
{
    public partial class EditClass : Form
    {
        public EditClass()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            
            SaveButton.Enabled = true;
            EnableDisableControls(true);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CodeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(CodeComboBox.SelectedValue!=null)
            {
                EnableDisableControls(false);
                SaveButton.Enabled = false;
                Common.Class.Class c = new Common.Class.Class();
                c.ClassId = Convert.ToInt32(CodeComboBox.SelectedValue.ToString());
                SqlDataReader sdr= BusinessLayer.Student.ClassSubjectInfo.GetClassSubjectInfoByClassId(c);
                ClassTextBox.Text = sdr["Class"].ToString();
                Subject1TextBox.Text = sdr["Subject1"].ToString();
                Subject2TextBox.Text = sdr["Subject2"].ToString();
                Subject3TextBox.Text = sdr["Subject3"].ToString();

            }

        }
        private void BindCodeComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            CodeComboBox.DisplayMember = "Class";
            CodeComboBox.ValueMember = "ClassId";
            CodeComboBox.DataSource = dt;
        }

        private void EditClass_Load(object sender, EventArgs e)
        {
            BindCodeComboBox();
            EnableDisableControls(false);
            SaveButton.Enabled = false;
            BindDataGrid();
         
        }
        private void EnableDisableControls(bool b)
        {
            ClassTextBox.Enabled = b;
            SectionComboBox.Enabled = b;
            ScheduleComboBox.Enabled = b;
            Subject1TextBox.Enabled = b;
            Subject2TextBox.Enabled = b;
            Subject3TextBox.Enabled = b;
        }
        private void BindDataGrid()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            dataGridView1.DataSource = dt;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Common.Class.Class c = new Common.Class.Class();
            c.ClassId = Convert.ToInt32(CodeComboBox.SelectedValue.ToString());
            SqlParameter[] param=new SqlParameter[]
            {
                new SqlParameter("@ClassId",c.ClassId)
            };
            DataBaseLayer.DbOperations.ExecProc("[student].[spDeleteClassSubjectById]", param, true);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
