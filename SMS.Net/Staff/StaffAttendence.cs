using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.Staff
{
    public partial class StaffAttendence : Form
    {
        public StaffAttendence()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO AttendeceInfo(Status) values('"+textBox2.Text.Trim()+"')";
            int x=DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Attendence Status Added!!");
            }
        }

        private void StaffAttendence_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM AtttendenceInfo where ID='"+textBox1.Text.Trim()+"'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Record Deleted!!!");
            }
        }
    }
}
