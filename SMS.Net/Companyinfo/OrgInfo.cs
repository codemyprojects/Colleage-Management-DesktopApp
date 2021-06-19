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
    public partial class OrgInfo : Form
    {
        public  byte[] pic;
        public OrgInfo()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            pic= DataBaseLayer.DbOperations.ReadFile(textBox1.Text);
            cmd.CommandText = "INSERT INTO ImageInfo(ImageName,Image) VALUES('"+textBox1.Text.Trim()+"','"+pic+"')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Company created successfully!!");
      
            }
        }
        private void BindDataGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM [dbo].ImageInfo";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void OrgInfo_Load(object sender, EventArgs e)
        {
            //BindDataGrid();
        }

        
    }
}
