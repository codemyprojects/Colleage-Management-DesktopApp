using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Organization
{
    public partial class OrganizationInfo : Form
    {
        public static int cid;
        public static byte[] image;
        public static byte[] img;
        
        public OrganizationInfo()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Common.Student.StudentsEnroll student = new Common.Student.StudentsEnroll();
            if (textBox1.Text == string.Empty || textBox1.Text == null || textBox1.Text == "")
            {

                textBox1.Text = "\\SMS\\nimage.jpg";
                student.Picture = DataBaseLayer.DbOperations.ReadFile(textBox1.Text.Trim());
            }
            else
            {
                student.Picture = DataBaseLayer.DbOperations.ReadFile(textBox1.Text);
            }


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO dbo.OrganizationInfo(OrgReg,OrgLocation,OrgPhone,OrgEmail,OrgUrl,OrgLogo) VALUES('" + textBoxGovRegdNum.Text.Trim() + "','" + textBoxAddress.Text.Trim() + "','" + textBoxPhone1.Text.Trim() + "','" + textBoxEmail.Text.Trim() + "','" + textBoxUrl.Text.Trim() + " ','" + student.Picture + "')";
            //cmd.CommandText = "INSERT INTO CompanyInfo(CompanyRegno,CompanyName,CompanyAddress,CompanyPhone1,CopanyPhone2,CompanyEmail,CompanyURL,PictureName,Picture)VALUES('" + textBoxGovRegdNum.Text.Trim() + "','" + textBoxOrganzationName.Text.Trim() + "','" + textBoxAddress.Text.Trim() + "','" + textBoxPhone1.Text.Trim() + "','" + textBoxPhone2.Text.Trim() + "','" + textBoxEmail.Text.Trim() + "','" + textBoxUrl.Text.Trim() + ",'"+textBox1.Text.Trim()+"' ,'" + image + "')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Company created successfully!!");
                //clearorgcontrol();
                //BindDataGrid();
            }
        }
    }
}
