using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net.Staff
{
    public partial class StaffRegistration : Form
    {
        public static string x;
        public static string PictureName;
        public static int religionId;
        public StaffRegistration()
        {
            InitializeComponent();
        }

        private string GetRandomCode()
        {
            var chars = "0123456789";
            var stringChars = new char[2];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return "S" + finalString;

        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            Staff.StaffRegistration1 sr1 = new Staff.StaffRegistration1();
            Common.Staff.StaticStaffs.StaffCode = StaffCodeTextBox.Text.Trim();
            Common.Staff.StaticStaffs.StaffName = FirstNameTextBox.Text.Trim();
            if (MaleRadioButton.Checked == true)
                Common.Staff.StaticStaffs.StaffGender = "Male";
            if (FemaleRadioButton.Checked == true)
                Common.Staff.StaticStaffs.StaffGender ="Female";
            Common.Staff.StaticStaffs.StaffContact = StaffContactTextBox.Text.Trim();
            Common.Staff.StaticStaffs.StaffMobile = MobileTextBox.Text.Trim();
            Common.Staff.StaticStaffs.StaffEmail = EmailTextBox.Text.Trim();
            Common.Staff.StaticStaffs.StaffAddress = AddressTextBox.Text.Trim();
            Common.Staff.StaticStaffs.StaffPhoto = textImagePath.Text;
           
            //Read Image Bytes into a byte array
            Common.Staff.StaticStaffs.ImageData = ReadFile(textImagePath.Text);

            Common.Staff.StaticStaffs.StaffNationality = NationalityTextBox.Text.Trim();
            Common.Staff.StaticStaffs.StaffAge = AgeTextBox.Text.Trim();
            Common.Staff.StaticStaffs.Religion = religionId;
            Common.Staff.StaticStaffs.Caste =casteTextBox.Text.Trim();
            if(MarriedCheckBox.Checked==true)
            {
                Common.Staff.StaticStaffs.MaritalStatus = "Married";
            }
               
         if(UnmarriedCheckBox.Checked==true)
           {   
             Common.Staff.StaticStaffs.MaritalStatus = "Unmarried";
           }
             
              
            this.Hide();
            sr1.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void StaffRegistration_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(DateTime.Now.ToString());
            StaffCodeTextBox.Text = GetRandomCode();
            StaffCodeTextBox.ReadOnly = true;
            ReligionInfo();
        }
        private void ReligionInfo()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("dbo.spReligionInfo", null, true);
            ReligionComboBox.Items.Clear();
            ReligionComboBox.ValueMember = "ReligionId";
            ReligionComboBox.DisplayMember = "ReligionName";
            ReligionComboBox.DataSource = dt;
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



        private void AddButton_Click(object sender, EventArgs e)
        {

            //OpenFileDialog open = new OpenFileDialog();
            //open.Title = "Choose Image";
            //// image filters
            //open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    // display image in picture box
            //    pictureBox1.Image = new Bitmap(open.FileName);
            //    PictureName = open.FileName;
            //    //MessageBox.Show(PictureName.ToString());

            //}
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlres = dlg.ShowDialog();
            if (dlres != DialogResult.Cancel)
            {
                pictureBox1.ImageLocation = dlg.FileName;
              //  textBox1.Text = dlg.FileName;
                textImagePath.Text = dlg.FileName;
                ////MessageBox.Show(txtImagePath.ToString());
            }
        }
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReligionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(ReligionComboBox.SelectedValue!=null)
            {
                religionId = Convert.ToInt32(ReligionComboBox.SelectedValue);
            }
        }
    }
}
