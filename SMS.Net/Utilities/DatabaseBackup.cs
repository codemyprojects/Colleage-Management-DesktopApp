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

namespace SMS.Net.Utilities
{
    public partial class DatabaseBackup : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public DatabaseBackup()
        {
            InitializeComponent();
        }
        private void DatabaseBackup_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            serverName(".");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            blank("backup");
            //try
            //{
            //    SaveFileDialog SaveFD1 = new SaveFileDialog();
            //    string FileName = "";
            //    SaveFD1.InitialDirectory = "D:";
            //    SaveFD1.FileName = "";
            //    SaveFD1.Title = "Backup ";
            //    SaveFD1.DefaultExt = "bak";
            //    SaveFD1.Filter = "Ms-Access Files (*.mdb)|*.mdb|All Files|*.*";
            //    SaveFD1.Filter = "Backup Files (*.bak)|*.bak|All Files|*.*";
            //    SaveFD1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //    SaveFD1.FilterIndex = 1;
            //    SaveFD1.RestoreDirectory = true;
            //    if (SaveFD1.ShowDialog() == DialogResult.OK)
            //    {

            //        FileName = SaveFD1.FileName;
            //        Backup(FileName);
            //        MessageBox.Show("Backup Process is Completed Successfully !", "Backup Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error while backup " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        protected void Backup(string path)
        {
            // ----------------------------------- 
            // -- CREATE FILE BACKUP 
            // ----------------------------------- 
            //string src = Application.StartupPath + @"\sms_modified12";
            //string dst = path;
            //System.IO.File.Copy(src, dst, true);
        }
        public void serverName(string str)
        {

            con = new SqlConnection("Data Source=" + str + ";Database=Master;data source=.; uid=sa; pwd=ganesh;");

            con.Open();

            cmd = new SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                ComboBoxserverName.Items.Add(dr[2]);

            }

            dr.Close();

        }
        public void Createconnection()
        {

            con = new SqlConnection("Data Source=" + (ComboBoxserverName.Text) + ";Database=Master;data source=.; uid=sa; pwd=ganesh;");

            con.Open();

            ComboBoxDataBaseName.Items.Clear();

            cmd = new SqlCommand("select * from sysdatabases", con);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                ComboBoxDataBaseName.Items.Add(dr[0]);

            }

            dr.Close();

        }
        public void query(string que)
        {

            // ERROR: Not supported in C#: OnErrorStatement



            cmd = new SqlCommand(que, con);

            cmd.ExecuteNonQuery();

        }

       
        public void blank(string str)
        {

            if (string.IsNullOrEmpty(ComboBoxserverName.Text) | string.IsNullOrEmpty(ComboBoxDataBaseName.Text))
            {
                 label3.Visible = true;
                //MessageBox.Show("Server Name & Database can not be Blank");
                 label3.ForeColor = System.Drawing.Color.Red;
                 label3.Text = "Please!! Server && Database Can't be Blank";
                 return;
            }
            else
            {
                if (str == "backup")
                    {

                    SaveFileDialog1.FileName = ComboBoxDataBaseName.Text;
                    SaveFileDialog1.ShowDialog();
                    string s = null;
                    s = SaveFileDialog1.FileName;
                    query("Backup database " + ComboBoxDataBaseName.Text + " to disk='" + s + "'");
                    label3.Visible = true;
                    label3.Text = "Database BackedUp Successfully!!";
                    label3.ForeColor = System.Drawing.Color.Green;
                }

            }

        }



 

        private void ComboBoxserverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Createconnection();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

     
    }
}
