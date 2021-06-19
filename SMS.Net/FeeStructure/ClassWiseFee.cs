using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Net.FeeStructure
{
    public partial class ClassWiseFee : Form
    {   public  int  fid;
        public int fstatusId;
        public  string fstatus="";
        public  string academicYear="";
        public  string c="";
        public  string fname="";
        public  int cid;
        public  int aid;
        public int feeId;
        public ClassWiseFee()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ClassWiseFee_Load(object sender, EventArgs e)
        {
            SaveButton.Enabled = false;
            FeeStatusComboBox.Enabled = false;
            DeleteButton.Enabled = false;
            EditButton.Enabled = false;
            UpdateButton.Enabled = false;
            ClassInfo();
            BindYears();
           // BindGrid();
            EnableDisableControls(false);
            BindFeeStatusComboBox();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            DeleteButton.Enabled = false;
            EditButton.Enabled = false;
            UpdateButton.Enabled = false;
            AddButton.Enabled = false;
            EnableDisableControls(true);
            FeeStatusComboBox.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
      
            if (FeeStatusComboBox.SelectedValue.ToString() == "1")
                fstatus="Annually";

            //if (FeeStatusComboBox.SelectedValue.ToString() == "2")
            //    fstatus="Monthly";

            if (FeeStatusComboBox.SelectedValue.ToString() == "3")
                fstatus="Other";

            cmd.CommandText = "INSERT INTO  [dbo].[FeeDetailsInfo] ([AcademicYearId],[ClassId],[FeeId],[FeeStatus],[FeeAmount]) VALUES('" + Convert.ToUInt32(AcademicYearComboBox.SelectedValue.ToString()) + "','" + Convert.ToInt32(comboBox1.SelectedValue.ToString()) + "','" + Convert.ToInt32(comboBox2.SelectedValue.ToString()) + "','"+fstatus+"','" + textBox1.Text.Trim() + "')";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if(x==1)
            {
                MessageBox.Show("Fee Details Added Successfully!!");
                //SqlCommand cm = new SqlCommand();
                //cm.CommandText = "SELECT FeeDetailId AS ID,T2.AcademicYear,T3.Class,T1.FeeStatus,T5.FeeName, T1.FeeAmount   FROM FeeDetailsInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatus=T4.FeeStatus INNER JOIN FeeInfo T5 ON T1.FeeId=T5.FeeId WHERE T1.AcademicYearId='"+aid+"' AND T1.ClassId='"+cid+"' AND T1.FeeStatus='"+fstatus+"'";
                //DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cm);
                //if (dt.Rows.Count >0)
                //{
                //    dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                //    dataGridView1.DataSource = dt;
                //}
             
           
                //BindGrid();
                SaveButton.Enabled = true;
                AddButton.Enabled = true;
            }


        }

        private void AcademicYearComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(AcademicYearComboBox.SelectedValue!=null)
            {
                aid = Convert.ToInt32(AcademicYearComboBox.SelectedValue);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null)
            {
                cid = Convert.ToInt32(comboBox1.SelectedValue);
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "SELECT FeeDetailId AS ID,T2.AcademicYear,T3.Class,T1.FeeStatus,T5.FeeName, T1.FeeAmount   FROM FeeDetailsInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatus=T4.FeeStatus INNER JOIN FeeInfo T5 ON T1.FeeId=T5.FeeId WHERE T1.AcademicYearId='"+aid+"' AND T1.ClassId='"+cid+"'";
                //cm.CommandText = "SELECT FeeDetailId AS ID,T2.AcademicYear,T3.Class,T1.FeeStatus,T5.FeeName, T1.FeeAmount   FROM FeeDetailsInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatus=T4.FeeStatus INNER JOIN FeeInfo T5 ON T1.FeeId=T5.FeeId WHERE T1.AcademicYearId='" + aid + "' AND T2.ClassId='" + cid + "'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cm);
                if(dt.Rows.Count>=1)
                {
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue!=null)
            {
                feeId=Convert.ToInt32(comboBox2.SelectedValue);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT   * FROM FeeDetailsInfo WHERE FeeId='"+feeId+"'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                if(dt.Rows.Count>=1)
                {
                    MessageBox.Show("Fee Amount Already Added");
                    //AcademicYearComboBox.Text = "";
                    ClassComboBox.Text = "";
                    FeeStatusComboBox.Text = "";
                    comboBox2.Text = "";
                    textBox1.Text = string.Empty;
                }
            }
            else
            {
                comboBox2.SelectedIndex = 0;
                //feeId = comboBox2.SelectedValue;
            }
        }
        private void ClassInfo()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.spClassInfo", null, true);
            if (dt.Rows.Count > 0)
            {
                comboBox1.Items.Clear();
                comboBox1.ValueMember = "ClassId";
                comboBox1.DisplayMember = "Class";
                comboBox1.DataSource = dt;
            }
        }

        private void BindYears()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM student.AcademicYearInfo";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            AcademicYearComboBox.DisplayMember = "AcademicYear";
            AcademicYearComboBox.ValueMember = "AcademicYearId";
            AcademicYearComboBox.DataSource = dt;
        }
        private void BindComboBox(string fstatus)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.FeeId AS ID,T2.AcademicYear,T3.Class,T4.FeeStatus,T1.FeeName AS Fee FROM FeeInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatusId=T4.FeeStatusId WHERE T4.FeeStatus='"+fstatus+"' AND T2.AcademicYearId='" + aid + "' AND T3.ClassId='" + cid + "';";
            //cmd.CommandText = "SELECT FeeId,FeeName FROM FeeInfo where FeeStatusId='"+fstatusId+"' AND AcademicYearId='"+aid+"' AND ClassId='"+cid+"'";
            //cmd.CommandText = "SELECT t1.FeeId AS ID,t1.FeeName AS Fee,t2.FeeStatus as [Status] FROM dbo.FeeInfo t1 inner join dbo.FeeStatusInfo t2 on t1.FeeStatusId=t2.FeeStatusId INNER JOIN FeeDetailsInfo T3 ON  t1.FeeId=T3.FeeId WHERE T2.FeeStatus='Annually'";
            //cmd.CommandText = "SELECT FeeId,FeeName,FeeStatus FROM dbo.FeeInfo t1 inner join dbo.FeeStatusInfo t2 on t1.FeeStatusId=t2.FeeStatusId WHERE FeeStatus='"+FeeStatus+"'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox2.DisplayMember = "Fee";
            comboBox2.ValueMember = "ID";
            comboBox2.DataSource = dt;

        }

        //private void BindGrid()
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SELECT FeeDetailId as [S.NO],AcademicYear as [Year],Class,FeeName as [Fee],FeeStatus as [Status],FeeAmount as [Amount] FROM  dbo.FeeDetailsInfo t1 INNER JOIN student.ClassInfo t2 ON t1.ClassId=t2.ClassId INNER JOIN student.AcademicYearInfo t3 ON t1.AcademicYearId=t3.AcademicYearId inner join  dbo.FeeInfo t4 on t1.FeeId=t4.FeeId";
        //    DataTable dt = new DataTable();
        //    dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
        //    dataGridView1.DataSource = dt;
        //}
        private void BindGrid()
        {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "SELECT FeeDetailId AS ID,T2.AcademicYear,T3.Class,T1.FeeStatus,T5.FeeName, T1.FeeAmount   FROM FeeDetailsInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatus=T4.FeeStatus INNER JOIN FeeInfo T5 ON T1.FeeId=T5.FeeId";
             //cmd.CommandText = "SELECT   * FROM FeeDetailsInfo WHERE AcademicYearId='"+aid+"' AND ClassId='"+cid+"' AND FeeStatus='"+fstatus+"'";// AND FeeId='"+fid+"'";
            //cmd.CommandText = "SELECT T1.FeeId AS ID,T2.AcademicYear,T3.Class,T4.FeeStatus,T1.FeeName AS Fee FROM FeeInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatusId=T4.FeeStatusId WHERE T4.FeeStatus='" + fstatus + "' AND T2.AcademicYearId='" + aid + "' AND T3.ClassId='" + cid + "';";
            ////cmd.CommandText = "SELECT FeeDetailId as [S.NO],AcademiYear as [Year],Class,FeeName as [Fee],FeeStatus as [Status],FeeAmount as [Amount] FROM  dbo.FeeDetailsInfo t1 INNER JOIN student.ClassInfo t2 ON t1.ClassId=t2.ClassId INNER JOIN student.AcademicYearInfo t3 ON t1.AcademicYearId=t3.AcademicYearId inner join  dbo.FeeInfo t4 on t1.FeeId=t4.FeeId WHERE FeeStatus='" + fstatus + "'   AND t1.ClassId='" + cid + "' AND  AND t1.AcademicYearId='" + aid + "' ";
             DataTable dt = new DataTable();
             if (dt.Rows.Count >=1)
             {
                 dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                 dataGridView1.DataSource = dt;
             }
             
           
        }
        private void EnableDisableControls(bool b)
        {
            comboBox1.Enabled = b;
            comboBox2.Enabled = b;
            AcademicYearComboBox.Enabled = b;
            textBox1.Enabled = b;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fid = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                academicYear = Convert.ToString(dataGridView1[1, e.RowIndex].Value);
                c = Convert.ToString(dataGridView1[2, e.RowIndex].Value);
                fname = Convert.ToString(dataGridView1[4, e.RowIndex].Value);
                fstatus = Convert.ToString(dataGridView1[3, e.RowIndex].Value);
                EditButton.Enabled = true;
                UpdateButton.Enabled = true;
                DeleteButton.Enabled = true;


                AcademicYearComboBox.SelectedIndex = AcademicYearComboBox.FindString(academicYear);
                comboBox1.SelectedIndex = comboBox1.FindString(c);
                FeeStatusComboBox.SelectedIndex = FeeStatusComboBox.FindString(fstatus);
                comboBox2.SelectedIndex = comboBox2.FindString(fname);
                textBox1.Text = Convert.ToString(dataGridView1[5, e.RowIndex].Value);
                EnableDisableControls(true);
     
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            UpdateButton.Enabled = true;
            EditButton.Enabled = false;
            /*AcademicYearComboBox.SelectedIndex=AcademicYearComboBox.FindString(academicYear);
            comboBox1.SelectedIndex = comboBox1.FindString(c);
            FeeStatusComboBox.SelectedIndex = FeeStatusComboBox.FindString(fstatus);
            comboBox2.SelectedIndex = comboBox2.FindString(fname);
             */

            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE FeeDetailsInfo SET [AcademicYearId]='" + Convert.ToInt32(AcademicYearComboBox.SelectedValue.ToString()) + "',[ClassId]='" + Convert.ToInt32(comboBox1.SelectedValue.ToString()) + "',[FeeId]='" + Convert.ToInt32(comboBox2.SelectedValue.ToString()) + "',[FeeAmount]='" + Convert.ToInt32(textBox1.Text.Trim()) + "' where FeeDetailId='" + fid + "'";
            int x = DataBaseLayer.DbOperations.ExecProc(cmd);
            if (x == 1)
            {
                MessageBox.Show("Updated Successfully!!");
                BindGrid();
                //AcademicYearComboBox.Text = "";
                //ClassComboBox.Text = "";
                //FeeStatusComboBox.Text = "";
                comboBox2.Text = "";
                textBox1.Text = string.Empty;

            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                
                if(feeId==0)
                {
                    MessageBox.Show("You need to select Fee");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "DELETE FeeDetailsInfo where FeeDetailId='" + fid + "' AND FeeId='" + feeId + "'";
                    int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                    if (x == 1)
                    {
                        MessageBox.Show("Deleted Successfully!!");
                        BindGrid();
                    }

                }
                
            }
        }

        private void BindFeeStatusComboBox()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  * FROM dbo.FeeStatusInfo WHERE FeeStatusId!=2";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            FeeStatusComboBox.DisplayMember = "FeeStatus";
            FeeStatusComboBox.ValueMember = "FeeStatusId";
            FeeStatusComboBox.DataSource = dt;
        }

        private void FeeStatusComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(FeeStatusComboBox.SelectedValue!=null)
            {
               if(Convert.ToInt32(FeeStatusComboBox.SelectedValue)==1)
               {
                   //BindComboBox(1);
                   // BindGrid("Annually");
                   //fstatusId = 1;
                   fstatus = "Annually";
                   BindComboBox(fstatus);
                   try
                   {
                       SqlCommand cm = new SqlCommand();
                       cm.CommandText = "SELECT FeeDetailId AS ID,T2.AcademicYear,T3.Class,T1.FeeStatus,T5.FeeName, T1.FeeAmount   FROM FeeDetailsInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatus=T4.FeeStatus INNER JOIN FeeInfo T5 ON T1.FeeId=T5.FeeId WHERE T1.AcademicYearId='"+aid+"' AND T1.ClassId='"+cid+"' AND T1.FeeStatus='"+fstatus+"'";
                       //cm.CommandText = "SELECT FeeDetailId AS ID,T2.AcademicYear,T3.Class,T1.FeeStatus,T5.FeeName, T1.FeeAmount   FROM FeeDetailsInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatus=T4.FeeStatus INNER JOIN FeeInfo T5 ON T1.FeeId=T5.FeeId WHERE T1.AcademicYearId='" + aid + "' AND T1.ClassId='" + cid + "' AND T1.FeeStatus='" + fstatus + "'";
                       DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cm);
                       if (dt.Rows.Count >= 1)
                       {
                           dataGridView1.DataSource = dt;
                       }
                   }
                   catch(Exception ex)
                   {
                       MessageBox.Show(ex.Message);
                   }
                   
               }
             

               //if (FeeStatusComboBox.SelectedValue.ToString() == "2")
               //{
               //    BindComboBox(2);
               //  //  BindGrid("Monthly");
               //    fstatus = "Monthly";
               //    //fstatusId = 2;
               //    BindGrid();
               //}
                   

               else
               {
                  // BindComboBox(3);
                  // BindGrid("Other");
                   fstatus = "Other";
                   BindComboBox(fstatus);
                   //fstatusId = 3;
                   //BindGrid();
                   try
                   {
                       SqlCommand cm = new SqlCommand();
                       cm.CommandText = "SELECT FeeDetailId AS ID,T2.AcademicYear,T3.Class,T1.FeeStatus,T5.FeeName, T1.FeeAmount   FROM FeeDetailsInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatus=T4.FeeStatus INNER JOIN FeeInfo T5 ON T1.FeeId=T5.FeeId WHERE T1.AcademicYearId='"+aid+"' AND T1.ClassId='"+cid+"' AND T1.FeeStatus='" + fstatus + "'";
                       //cm.CommandText = "SELECT FeeDetailId AS ID,T2.AcademicYear,T3.Class,T1.FeeStatus,T5.FeeName, T1.FeeAmount   FROM FeeDetailsInfo T1 INNER JOIN student.AcademicYearInfo T2 ON T1.AcademicYearId=T2.AcademicYearId INNER JOIN student.ClassInfo T3 ON T1.ClassId=T3.ClassId INNER JOIN FeeStatusInfo T4 ON T1.FeeStatus=T4.FeeStatus INNER JOIN FeeInfo T5 ON T1.FeeId=T5.FeeId WHERE T1.AcademicYearId='" + aid + "' AND T1.ClassId='" + cid + "',T1.FeeStatus='" + fstatus + "'";
                       DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cm);
                       if (dt.Rows.Count >= 1)
                       {
                           dataGridView1.DataSource = dt;
                       }
                   }
                   catch(Exception ex)
                   {
                       MessageBox.Show(ex.Message);
                   }
                  
               }
        

            }
            //BindComboBox(int FeeId);
        }

        private void FeeStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AcademicYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
