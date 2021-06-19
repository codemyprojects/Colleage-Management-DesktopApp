using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net.Companyinfo
{
    public partial class OrganizationInfo : Form
    {
  
        public static int cid;
        public static byte[] image;
         public  byte[] img;
        public OrganizationInfo()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlres = dlg.ShowDialog();
            if (dlres != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = dlg.FileName;
                textBox1.Text = dlg.FileName;
                ////MessageBox.Show(txtImagePath.ToString());
            }
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
                clearorgcontrol();
                //BindDataGrid();
            }
            //if (textBox1.Text == string.Empty || textBox1.Text == null || textBox1.Text == "")
            //{

               
            //    textBox1.Text = "\\SMS\\nimage.jpg";
            //    image = DataBaseLayer.DbOperations.ReadFile(textBox1.Text.Trim());
            //}
            //else
            //{
               
            //    image= DataBaseLayer.DbOperations.ReadFile(textBox1.Text);
            //}
        }
        private void BindDataGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [dbo].[OrganizationInfo]";
          //  cmd.CommandText = "SELECT [CompanyRegno],[CompanyName],[CompanyAddress],[CompanyPhone1],[CopanyPhone2],[CompanyEmail],[CompanyURL] FROM [SMS].[dbo].[CompanyInfo]";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
           dataGridView1.DataSource = dt;
           // dataGridView2.DataSource = dt;
        }
        private void clearorgcontrol()
        {
            textBoxGovRegdNum.Text = string.Empty;
            textBoxOrganzationName.Text = "";
            textBoxAddress.Text = "";
            textBoxPhone1.Text = string.Empty;
            textBoxPhone2.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxUrl.Text = "";
        }
     
   

      

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //cid = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT * FROM dbo.CompanyInfo WHERE CompanyId='" + cid + "'";
            //DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    textBoxGovRegdNum.Text = dr["CompanyRegno"].ToString();
            //    textBoxOrganzationName.Text = dr["CompanyName"].ToString();
            //    textBoxAddress.Text = dr["CompanyAddress"].ToString();
            //    textBoxPhone1.Text = dr["CompanyPhone1"].ToString();
            //    textBoxPhone2.Text = dr["CopanyPhone2"].ToString();
            //    textBoxEmail.Text = dr["CompanyEmail"].ToString();
            //    textBoxUrl.Text = dr["CompanyURL"].ToString();
            //      //  modified method for displaying image
            //    byte[] imageData = (byte[])dr["CompanyLogo"];
            //    img = imageData;
            //    //Initialize image variable
            //    Image newImage;
            //    //Read image data into a memory stream
            //    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            //    {
            //        ms.Write(imageData, 0, imageData.Length);

            //        //Set image variable value using memory stream.
            //        newImage = Image.FromStream(ms, true);
            //    }

            //    //set picture
            //    pictureBox1.Image = newImage;
            //}
            }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
        
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM dbo.CompanyInfo WHERE CompanyId='" + cid + "'";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
            //{
            //    e.Cancel = true;
            //}
        }

        private void OrganizationInfo_Load(object sender, EventArgs e)
        {
            //BindDataGrid();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        }
    }
