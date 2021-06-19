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
    public partial class AddClass : Form
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            AddNewButton.Enabled = false;
            EnableDisableControls(true);
        }

        private void AddClass_Load(object sender, EventArgs e)
        {
            ClassCodeTextBox.Text = GetRandomCode();
            ClassCodeTextBox.ReadOnly = true;
            EnableDisableControls(false);
        }
        private string GetRandomCode()
        {
            var chars = "CL84";
            var stringChars = new char[3];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;

        }
        private void EnableDisableControls(bool x)
        {
            SaveButton.Enabled = x;
            ClassTextBox.Enabled = x;
            SectionComboBox.Enabled = x;
            ScheduleComboBox.Enabled = x;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            Common.Class.Class c = new Common.Class.Class();
            //c.Subject1 = Subject1TextBox.Text.Trim();
            //c.Subject2 = Subject2TextBox.Text.Trim();
            //c.Subject3 = Subject3TextBox.Text.Trim();
            //c.Subject3 = "";
            //c.Subject4 = "";
            //c.Subject5 = "";
            //c.Subject6 = "";
            //c.Subject7 = "";
            //c.Subject8 = "";
            //c.Subject9 = "";
            //c.Subject10 = "";
            //c.Subject11 = "";
            //c.Subject12 = "";
            //c.Subject13 = "";
            //c.Subject14 = "";
            //c.Subject15 = "";
            //c.Subject16 = "";
            //c.Subject17 = "";
            //c.Subject18 = "";
            //c.Subject19 = "";
            //c.Subject20 = "";
            //c.ClassCode = ClassCodeTextBox.Text.Trim();
            //c.ClassName = ClassTextBox.Text.Trim();
           // c.Section = "A";
            //c.ClassSchedule = "Morning/Evening";
            if(string.IsNullOrEmpty(c.Subject1)==false)
            {
                int row = BusinessLayer.Student.ClassSubjectInfo.AddClassSubjectInfo(c);
                if (row == 2)
                {
                    MessageBox.Show("Record Added Successfully!!");
                }
                else
                {
                    MessageBox.Show("Record not saved!!");
                }
                AddNewButton.Enabled = true;
                EnableDisableControls(false);
            }
            else
            {
               // MessageBox.Show("Please Enter Subject Name!");
              string s= DateTime.Now.ToString();
               // DateTime dt=DateTime.Today;
                MessageBox.Show(string.Format("{0:yyyy/mm/dd}", s));
            }
         
            
        }
       
        }
    }

