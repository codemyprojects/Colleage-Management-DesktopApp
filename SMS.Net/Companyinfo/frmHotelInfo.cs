using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace SMS.Net.Companyinfo
{
    public partial class frmHotelInfo : Form
    {
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        //static string DBConn = "Data Source=(local);Initial Catalog=SMS;Integrated Security=True";
        SMS.Net.ConnectionString cs = new SMS.Net.ConnectionString();
        public frmHotelInfo()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            txtHotelName.Text = "";
            txtAltContactNo.Text = "";
            txtContactNo.Text = "";
            txtAddress.Text = "";
            txtServiceTaxNo.Text = "";
            txtTIN.Text = "";
            txtEmailID.Text = "";
            btnSave.Enabled = true;
            PictureBox1.Image = SMS.Net.Properties.Resources._12;
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
            txtHotelName.Focus();
        }
        private void frmHotelInfo_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtHotelName.Text=="")
            {
                MessageBox.Show("Please enter restaurant name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHotelName.Focus();
                return;
            }
            if (txtAddress.Text =="")
            {
                MessageBox.Show("Please enter address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return;
            }
            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please enter contact no.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select count(*) from HotelInfo Having count(*) >= 1";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists" + "\n" + "please update the Hotel Info", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into HotelInfo( HotelName, Address, ContactNo, ContactNo1, Email, TIN, STNo, Logo) VALUES ('" + txtHotelName.Text + "','" + txtAddress.Text + "','" + txtContactNo.Text + "','" + txtAltContactNo.Text + "','" + txtEmailID.Text + "','" + txtTIN.Text + "','" + txtServiceTaxNo.Text + "',@d1)";
                cmd = new SqlCommand(cb);
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(PictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d1",SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                GetData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(ID), RTRIM(HotelName), RTRIM(Address), RTRIM(ContactNo), RTRIM(ContactNo1), RTRIM(Email), RTRIM(TIN), RTRIM(STNo), Logo from HotelInfo", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtHotelName.Text == "")
                {
                    MessageBox.Show("Please enter restaurant name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHotelName.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter contact no.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update HotelInfo set  HotelName='" + txtHotelName.Text + "', Address='" + txtAddress.Text + "', ContactNo='" + txtContactNo.Text + "', ContactNo1='" + txtAltContactNo.Text + "', Email='" + txtEmailID.Text + "', TIN='" + txtTIN.Text + "', STNo='" + txtServiceTaxNo.Text + "', Logo=@d1 where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(PictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d1", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                GetData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cq = "delete from HotelInfo where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    GetData();
                }
                else
                {
                    MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteRecord();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
                txtHotelName.Text = dr.Cells[1].Value.ToString();
                txtAddress.Text = dr.Cells[2].Value.ToString();
                txtContactNo.Text = dr.Cells[3].Value.ToString();
                txtAltContactNo.Text = dr.Cells[4].Value.ToString();
                txtEmailID.Text = dr.Cells[5].Value.ToString();
                txtTIN.Text = dr.Cells[6].Value.ToString();
                txtServiceTaxNo.Text = dr.Cells[7].Value.ToString();
                byte[] data = (byte[])dr.Cells[8].Value;
                MemoryStream ms = new MemoryStream(data);
                PictureBox1.Image = Image.FromStream(ms);
                btnDelete.Enabled = true;
                btnUpdate_record.Enabled = true;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = OpenFileDialog1;
                _with1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;");
                _with1.FilterIndex = 4;
                //Clear the file name
                OpenFileDialog1.FileName = "";
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
