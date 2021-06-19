using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Companyinfo
{
    public partial class CompanyInfo : Form
    {
        public static int cid;
        public static byte[] image;
        public static byte[] img;
        public CompanyInfo()

        {
            InitializeComponent();
        
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO dbo.OrganizationInfo(OrgName,OrgLocation,OrgPhone,OrgEmail,OrgUrl,OrgLogo)";
           // cmd.CommandText = "INSERT INTO CompanyInfo(CompanyRegno,CompanyName,CompanyAddress,CompanyPhone1,CopanyPhone2,CompanyEmail,CompanyURL,CompanyLogo)VALUES('" + textBoxGovRegdNum.Text.Trim() + "','" + textBoxOrganzationName.Text.Trim() + "','" + textBoxAddress.Text.Trim() + "','" + textBoxPhone1.Text.Trim() + "','" + textBoxPhone2.Text.Trim() + "','" + textBoxEmail.Text.Trim() + "','" + textBoxUrl.Text.Trim() + "','" + image + "')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Company created successfully!!");
                clearorgcontrol();
                //BindDataGrid();
            }

        }
        private void BindDataGrid()
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT * FROM dbo.CompanyInfo";
            //DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            //dataGridView1.DataSource = dt;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM dbo.CompanyInfo WHERE CompanyId='" + cid + "'";
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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

            //}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
           // image = textBox1.Text;
            image= DataBaseLayer.DbOperations.ReadFile(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlres = dlg.ShowDialog();
            if (dlres != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = dlg.FileName;
                textBox1.Text = dlg.FileName;
                ////MessageBox.Show(txtImagePath.ToString());
            }
            // image = textBox1.Text;
            image = DataBaseLayer.DbOperations.ReadFile(textBox1.Text);
        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            //BindDataGrid();
        }


        }
    
    }

