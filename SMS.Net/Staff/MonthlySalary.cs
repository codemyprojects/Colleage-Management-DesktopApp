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
    public partial class MonthlySalary : Form
    {
        public int staffid;
        public double totalAllowance = 0;
        public double totalAdvance = 0;
        public double bs = 0; //for basic salary
        public double ta = 0; //for total allowance
        public double grade = 0;// for grade(amount)
        public double tot = 0;//total salary 
        public double grosstot = 0; // grosstotal salay
        public double dtotal;//deduced tottal 
        public double advnc = 0;// advance amount 
        public double radvnc = 0; //returned advance
        public double pf = 0;//provident fund
        public double tx = 0;//tax amount
        public double dt = 0;//
        public double nt = 0;//net total
        public double netot = 0;//
        public static int sid;
        public static int mid;
        public static int yid;
        public static string stafftype;
        public string pickerdate;
        public static double aAmount;
        public MonthlySalary()
        {
            InitializeComponent();
        }

        private void MonthlySalary_Load(object sender, EventArgs e)
        {


            BindStaffName();
            BindBatch();
            BindMonthComboBox();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(staffid.ToString());
            BindDataGrid();
            BindAdvanceGrid();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                sid = Convert.ToInt32(comboBox1.SelectedValue);
                staffid = Convert.ToInt32(comboBox1.SelectedValue);
                // MessageBox.Show(sid.ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT T1.StaffId,T2.PositionName,T4.BasicSalary,T4.StaffType,T4.DateOfJoin,T4.DateOfPermanency,T4.DateOfPromotion FROM staff.StaffsInfo T1 INNER JOIN dbo.PositionInfo T2 ON T1.StaffPost=T2.PositionId INNER JOIN LevelInfo T3 ON T1.JobStatus=T3.LevelId  INNER JOIN dbo.StaffDetailInfo T4 ON T1.StaffId=T4.StaffId WHERE T1.StaffId='" + sid + "'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    staffid = Convert.ToInt32(dr["StaffId"].ToString());
                    PostionNameTextBox.Text = dr["PositionName"].ToString();
                    BasicSalaryTextBox.Text = dr["BasicSalary"].ToString();
                    BasicSalary.Text = dr["BasicSalary"].ToString();
                    if (dr["StaffType"].ToString() == "Permanent")
                    {
                        radioButton1.Checked = true;
                    }
                    if (dr["StaffType"].ToString() == "Temporary")
                    {
                        radioButton2.Checked = true;
                    }
                    DateOfJoinTextBox.Text = dr["DateOfJoin"].ToString();
                    DateOfPermanency.Text = dr["DateOfPermanency"].ToString();
                    DateOfPromotion.Text = dr["DateOfPromotion"].ToString();

                }
            }
        }
        private void BindStaffName()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM staff.StaffsInfo T1 INNER JOIN dbo.PositionInfo T2 ON T1.StaffPost=T2.PositionId INNER JOIN LevelInfo T3 ON T1.JobStatus=T3.LevelId  INNER JOIN dbo.StaffDetailInfo T4 ON T1.StaffId=T4.StaffId";
            comboBox1.DisplayMember = "StaffName";
            comboBox1.ValueMember = "StaffId";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            comboBox1.DataSource = dt;
        }
        private void BindDataGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT T3.AllowanceName,T2.AllowanceAmount FROM StaffAllowanceDetails T1 INNER JOIN AllowanceDetailInfo T2 ON T1.AllowanceId=T2.AllowanceId INNER JOIN AllowanceInfo T3 ON T3.AllowanceId=T2.AllowanceId INNER JOIN staff.StaffsInfo T4 ON T1.StaffId=T4.StaffId WHERE T1.StaffId='" + staffid + "'";
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
                foreach (DataRow dr in dt.Rows)
                {
                    totalAllowance = totalAllowance + Convert.ToDouble(dr["AllowanceAmount"].ToString());
                }
                dataGridView1.DataSource = dt;
                TotalAllowanceTextBox.Text = totalAllowance.ToString();
                AllowanceTotal.Text = totalAllowance.ToString();
                totalAllowance = 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindAdvanceGrid()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT T1.AdvanceAmount FROM dbo.EmployeeAdvance T1 INNER JOIN staff.StaffsInfo t2 ON T1.StaffId=t2.StaffId WHERE t2.StaffId='" + staffid + "'";
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                totalAdvance = totalAdvance + Convert.ToDouble(dr["AdvanceAmount"].ToString());
            }
            dataGridView2.DataSource = dt;
            textBox1.Text = totalAdvance.ToString();
            Advance.Text = totalAdvance.ToString();

        }


        private void SaveButton_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                if (Convert.ToInt32(TotalAllowanceTextBox.Text) == 0)
                {
                    bs = 0;
                    ta = 0;
                    grade = 0;
                    tot = 0;
                    grosstot = 0;

                    advnc = 0;
                    radvnc = 0;
                    pf = 0;
                    tx = 0;
                    dt = 0;
                    nt = 0;
                    netot = 0;
                    cmd.CommandText = "INSERT INTO dbo.StaffSalaryPaymentInfo(StaffId,Position,StaffType,DateOfJoin,Year,Month,DatePicker,BasicSalary,AllowanceTotal,Grade,PyableTotal,GrossTotal,Advance,ReturnedAdvance,ProvidentFund,Tax,DeducedTotal,NetTotal) VALUES ('" + sid + "','" + PostionNameTextBox.Text.Trim() + "','" + stafftype + "','" + DateOfJoinTextBox.Text.Trim() + "','" + yid + "','" + mid + "','" + pickerdate + "','" + Convert.ToDouble(BasicSalary.Text.Trim()) + "','" + ta + "','" + dt + "','" + tot + "','" + grosstot + "','" + advnc + "','" + radvnc + "','" + pf + "','" + tx + "','" + dtotal + "','" + netot + "')";
                }
                else if ((bs == 0) || (ta == 0) || (grade == 0) || (tot == 0) || (grosstot == 0) || (advnc == 0) || (radvnc == 0) || (pf == 0) || (tx == 0) || (dt == 0) || (nt == 0) || (netot == 0))
                {
                    bs = ta = grade = 0;

                }
                else
                {
                    //cmd.CommandText = "INSERT INTO StaffSalaryPaymentInfo ([BasicSalary],[AllowanceTotal],[Grade],[PyableTotal],[GrossTotal],[Advance],[ReturnedAdvance],[ProvidentFund] ,[Tax],[dtotal],[NetTotal]) VALUES('"+Convert.ToDouble(BasicSalary.Text.Trim())+"','"+Convert.ToDouble(AllowanceTotal.Text.Trim())+"','"+GradeTotal.Text.Trim()+"','"+Convert.ToDouble(Total.Text.Trim())+"','"+Convert.ToDouble(Gross.Text.Trim())+"','"+Convert.ToDouble(Advance.Text.Trim())+"','"+Convert.ToDouble(ReturnedAdvance.Text.Trim())+"','"+Convert.ToDouble(PF.Text.Trim())+"','"+Convert.ToDouble(Tax.Text.Trim()+"','"+Convert.ToDouble(DTotal.Text.Trim())+",'"+Convert.ToDouble(NetTotal.Text.Trim())+"')";
                    //cmd.CommandText = "INSERT INTO StaffSalaryPaymentInfo (BasicSalary,AllowanceTotal,Grade,PyableTotal,GrossTotal,Advance,ReturnedAdvance,ProvidentFund,Tax,DeducedTotal,NetTotal) VALUES ('" + Convert.ToDouble(BasicSalary.Text.Trim()) + "','" + Convert.ToDouble(AllowanceTotal.Text.Trim()) + "','" + Convert.ToDouble(GradeTotal.Text.Trim()) + "','" + Convert.ToDouble(Total.Text.Trim()) + "','" + Convert.ToDouble(Gross.Text.Trim()) + "','" + Convert.ToDouble(Advance.Text.Trim()) + "','" + Convert.ToDouble(ReturnedAdvance.Text.Trim()) + "','" + Convert.ToDouble(PF.Text.Trim()) + "','" + Convert.ToDouble(Tax.Text.Trim()) + "','" + Convert.ToDouble(DTotal.Text.Trim()) + "','" + Convert.ToDouble(NetTotal.Text.Trim()) + "')";

                }
                cmd.CommandText = "INSERT INTO dbo.StaffSalaryPaymentInfo(StaffId,Position,StaffType,DateOfJoin,Year,Month,DatePicker,BasicSalary,AllowanceTotal,Grade,PyableTotal,GrossTotal,Advance,ReturnedAdvance,ProvidentFund,Tax,DeducedTotal,NetTotal) VALUES ('" + sid + "','" + PostionNameTextBox.Text.Trim() + "','" + stafftype + "','" + DateOfJoinTextBox.Text.Trim() + "','" + yid + "','" + mid + "','" + pickerdate + "','" + Convert.ToDouble(BasicSalary.Text.Trim()) + "','" + Convert.ToDouble(AllowanceTotal.Text.Trim()) + "','" + Convert.ToDouble(GradeTotal.Text.Trim()) + "','" + Convert.ToDouble(Total.Text.Trim()) + "','" + Convert.ToDouble(Gross.Text.Trim()) + "','" + Convert.ToDouble(Advance.Text.Trim()) + "','" + Convert.ToDouble(ReturnedAdvance.Text.Trim()) + "','" + Convert.ToDouble(PF.Text.Trim()) + "','" + Convert.ToDouble(Tax.Text.Trim()) + "','" + Convert.ToDouble(DeducedTotal.Text.Trim()) + "','" + Convert.ToDouble(NetTotal.Text.Trim()) + "')";
                //DataBaseLayer.DbOperations.ExecProc(cmd);
                int x = DataBaseLayer.DbOperations.ExecProc(cmd);
                if (x == 1)
                {
                    MessageBox.Show("Salary Payed Successfylly!!");
                    comboBox2.Text = "";
                    comboBox1.Text = "";
                    comboBox3.Text = "";
                    PostionNameTextBox.Text = string.Empty;
                    BasicSalaryTextBox.Text = string.Empty;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    DateOfJoinTextBox.Text = string.Empty;
                    DateOfPermanency.Text = string.Empty;
                    DateOfPromotion.Text = string.Empty;
                    TotalAllowanceTextBox.Text = string.Empty;
                    BasicSalary.Text = string.Empty;
                    AllowanceTotal.Text = string.Empty;
                    GradeTotal.Text = string.Empty;
                    Total.Text = string.Empty;
                    Gross.Text = string.Empty;
                    Advance.Text = string.Empty;
                    ReturnedAdvance.Text = string.Empty;
                    PF.Text = string.Empty;
                    Tax.Text = string.Empty;
                    DeducedTotal.Text = string.Empty;
                    NetTotal.Text = string.Empty;
                    dateTimePicker1.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BasicSalary_TextChanged(object sender, EventArgs e)
        {
            //tot =ta+Convert.ToDouble(BasicSalary.Text.Trim());
            //Total.Text = tot.ToString();
            //if (BasicSalary.Text == string.Empty || AllowanceTotal.Text == string.Empty)
            //{
            //    tot = bs + ta;
            //}
            //else
            //{
            bs = Convert.ToDouble(BasicSalary.Text.Trim());
            tot = bs + ta;
            //}

            //AllowanceTotal.Text = tot.ToString();
            Total.Text = tot.ToString();
            try
            {
                bs = Convert.ToDouble(BasicSalary.Text.Trim());
                tot = bs + ta;
                Total.Text = tot.ToString();
                NetTotal.Text = tot.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AllowanceTotal_TextChanged(object sender, EventArgs e)
        {
            //if(BasicSalary.Text==string.Empty || AllowanceTotal.Text==string.Empty)
            //{
            //    tot = bs + ta;
            //}
            //else
            //{
            //}

            //AllowanceTotal.Text = tot.ToString();

            try
            {
                ta = Convert.ToDouble(AllowanceTotal.Text.Trim());
                tot = bs + ta;
                Total.Text = tot.ToString();
                NetTotal.Text = tot.ToString();


            }
            catch (Exception ex)
            {

            }
        }

        private void GradeTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grade = Convert.ToDouble(GradeTotal.Text.Trim());
                grosstot = tot + grade;
                Gross.Text = grosstot.ToString();
                NetTotal.Text = grosstot.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Advance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                advnc = Convert.ToDouble(Advance.Text.Trim());
                dt = advnc - radvnc + pf + tx;
                //dt = advnc+ pf + tx;
                DeducedTotal.Text = dt.ToString();
                // textBox1.Text = advnc.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReturnedAdvance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                radvnc = Convert.ToDouble(ReturnedAdvance.Text.Trim());
                ////dt = radvnc+advnc + pf + tx;
                //dt = advnc + pf + tx;
                //dt = advnc - radvnc;
                //DeducedTotal.Text = dt.ToString();
                Advance.Text = dt.ToString();


                //double x = advnc-radvnc;
                //Advance.Text =Convert.ToString(x);
                //aAmount = Convert.ToDouble(Advance.Text);
                //Advance.Text = string.Empty;
                //double raAmount;

                //       raAmount = Convert.ToDouble(ReturnedAdvance.Text);
                //double reaAmount = aAmount - raAmount;
                //Advance.Text = Convert.ToString(reaAmount);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PF_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pf = Convert.ToDouble(PF.Text.Trim());
                dt = pf + advnc + tx;
                //dt = tx + advnc + radvnc + pf;
                DeducedTotal.Text = dt.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Tax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tx = Convert.ToDouble(Tax.Text.Trim());
                dt = tx + radvnc + pf;
                DeducedTotal.Text = dt.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void NetTotal_TextChanged(object sender, EventArgs e)
        {



        }

        private void DTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grosstot = Convert.ToDouble(Gross.Text.Trim());
                //tot = Convert.ToDouble(Total.Text.Trim());
                dt = Convert.ToDouble(DeducedTotal.Text.Trim());
                nt = grosstot - dt;
                NetTotal.Text = nt.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                //yid =Convert.ToInt32(comboBox2.SelectedValue);
            }
        }
        private void BindBatch()
        {
            try
            {
                DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spYearsInfo]", null, true);
                comboBox2.DisplayMember = "AcademicYear";
                comboBox2.ValueMember = "AcademicYear";
                comboBox2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue != null)
            {
                mid = Convert.ToInt32(comboBox3.SelectedValue);
            }
        }
        private void BindMonthComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spMontshInfo]", null, true);
            comboBox3.ValueMember = "MonthId";
            comboBox3.DisplayMember = "MonthName";
            comboBox3.DataSource = dt;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                stafftype = radioButton1.Text;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                stafftype = radioButton2.Text;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            pickerdate = dateTimePicker1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Total_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
