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

namespace SMS.Net.Student
{
    public partial class DisplayStudents : Form
    {
        public DisplayStudents()
        {
            InitializeComponent();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            //Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
            //student.StudentCode = CodeTextBox.Text.Trim();
            //DataTable dt = BusinessLayer.Students.GetStudentsByCode(student);
            //dataGridView1.DataSource = dt;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void StudentCodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayStudents_Load(object sender, EventArgs e)
        {
        }
        private void EditStudentByCode()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentCode",CodeTextBox.Text.Trim())
            };
            SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("student.spSearchStudent", param, true);
            sdr.Read();
            StudentNameTextBox.Text = sdr["Name"].ToString();
        }

        private void DisplayStudents_Click(object sender, EventArgs e)
        {
         
        }

        private void DisplayStudents_MouseClick(object sender, MouseEventArgs e)
        {
            EditStudentByCode();
        }
    }
}
