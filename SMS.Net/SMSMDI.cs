using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net
{
    public partial class SMSMDI : Form
    {
        private int childFormNumber = 0;
        private int xPos = 0;
       // Login l = new Login();
        public SMSMDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
         
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

     

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void enrollStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student.StudentEnroll se = new Student.StudentEnroll();
            se.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Student.DisplayStudents d = new Student.DisplayStudents();
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student.StudentEnroll se = new Student.StudentEnroll();
            se.Show();
        }

        private void newDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.AddDepartment ad = new Staff.AddDepartment();
            ad.Show();
        }

        private void editDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.EditDepartment ed = new Staff.EditDepartment();
            ed.Show();
        }

        private void departmentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.ViewDepartment vd = new Staff.ViewDepartment();
            vd.Show();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.CreateUser cu = new user.CreateUser();
            cu.Show();
        }

        private void addClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Class.AddClass ac = new Class.AddClass();
           // ac.Show();
        }

        //private void editClassToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Class.EditClass ec = new Class.EditClass();
        //    ec.Show();
        //}

        private void enrollStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.StaffRegistration sr = new Staff.StaffRegistration();
            sr.Show();
        }

        private void studentEnrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Student.StudentEnroll se = new Student.StudentEnroll();
            //se.Show();
            Student.StudentEnroll obj = new Student.StudentEnroll();
            obj.Show();
        }

        private void generalInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Staff.StaffGeneralInfo sgi = new Staff.StaffGeneralInfo();
            sgi.Show();

        }

        private void deleteStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.StaffGeneralInfo sgi = new Staff.StaffGeneralInfo();
            sgi.Show();
        }

     

        private void feeStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FeeStructure.AddFeeStructure afs = new FeeStructure.AddFeeStructure();
            //afs.Show();
            FeeStructure.ClassWiseFee cef = new FeeStructure.ClassWiseFee();
            cef.Show();
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.DatabaseBackup db = new Utilities.DatabaseBackup();
            db.Show();
        }

        private void feeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FeeStructure.ViewFeeStructure vfs = new FeeStructure.ViewFeeStructure();
            //vfs.Show();
        }

        private void feePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FeeStructure.AddPayment ap = new FeeStructure.AddPayment();
            //ap.Show();
            FeeStructure.StudentFeePayment sfp = new FeeStructure.StudentFeePayment();
            sfp.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (this.Width == xPos)
            //{
            //    //repeat marquee
            //    this.label1.Location = new System.Drawing.Point(0, 200);
            //    xPos = 0;
            //}
            //else
            //{
            //    this.label1.Location = new System.Drawing.Point(xPos, 200);
            //    xPos++;
            //}
        }

        private void SMSMDI_Load(object sender, EventArgs e)
        {
            if (Login.RoleId==0 || Login.RoleId==1)
            {
                RoleLabel.Text = "Welcome :: " + "Admin";
                editMenu.Enabled = true;
              //  exitToolStripMenuItem.Enabled = true;
                changePasswordToolStripMenuItem.Enabled = true;
                toolStripMenuItem3.Enabled = true;
                createUserToolStripMenuItem.Enabled = true;
                payToolStripMenuItem.Enabled = true;
                feeToolStripMenuItem2.Enabled = true;
                pictureBox2.Enabled = true;
                pictureBox3.Enabled = true ;
                pictureBox9.Enabled = true;
                pictureBox10.Enabled = true;
                pictureBox4.Enabled = true;
                pictureBox5.Enabled = true;
            }
            else
            {
                RoleLabel.Text = "Welcome::" +"User";
                editMenu.Enabled = false;
                //exitToolStripMenuItem.Enabled = false;
                changePasswordToolStripMenuItem.Enabled = true;
                toolStripMenuItem3.Enabled = false;
                createUserToolStripMenuItem.Enabled = false;
                payToolStripMenuItem.Enabled = false;
                feeToolStripMenuItem2.Enabled = false;
                pictureBox2.Enabled = false;
                pictureBox3.Enabled = false;
                pictureBox9.Enabled = false;
                pictureBox10.Enabled = false;
                pictureBox4.Enabled = false;
                pictureBox5.Enabled = false;
            }
                
            // MessageBox.Show(Login.role.ToString());
           // timer1.Start();
            //label1.Text = "Welcome To School Management System Version 1.0";
        }

        private void statusStrip_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void statusStrip_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            //timer1.Stop();
           // label1.Visible = false;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            //timer1.Start();
            //label1.Visible = true;
        }

        private void createUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            user.CreateUser cu = new user.CreateUser();
            cu.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            user.SystemUsers su = new user.SystemUsers();
            su.Show();
        }

        private void newStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.ChangePassword cp = new user.ChangePassword();
            cp.Show();
        }

        private void generalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student.DisplayStudents ds = new Student.DisplayStudents();
            ds.Show();
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marksNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results.MarksEntry me = new Results.MarksEntry();
            me.Show();
        }

        private void usersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void classReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports.Form2 f = new Reports.Form2();
            //f.Show();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void informationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void editStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student.UpdateStudent us = new Student.UpdateStudent();
            us.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void attendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendence.StudentAttendence sa = new Attendence.StudentAttendence();
            sa.Show();
        }

        private void cryptographyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void modifyMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results.ModifyMarks mm = new Results.ModifyMarks();
            mm.Show();
        }

        private void calculaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad");
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results.AddSubjects a=new Results.AddSubjects();
            a.Show();
        }

        private void RoleLabel_Click(object sender, EventArgs e)
        {

        }

        private void defineFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void feeRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FeeStructure.SearchFee sf = new FeeStructure.SearchFee();
            sf.Show();
        }

        private void staffDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.StaffDetails sd = new Staff.StaffDetails();
            sd.Show();
        }

        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Staff.Post p = new Staff.Post();
            //p.Show();
        }

        private void allowanceDefineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.AllowanceDefine ad = new Staff.AllowanceDefine();
            ad.Show();
        }

        private void employeeAllowanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.EmployeeAllowanceDetail ead = new Staff.EmployeeAllowanceDetail();
            ead.Show();
        }

        private void montlySalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void allowanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Staff.Allowance a = new Staff.Allowance();
            //a.Show();
        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Staff.Advance a = new Staff.Advance();
            //a.Show();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailyLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Legder.DailyLedger dl = new Legder.DailyLedger();
            dl.Show();
        }

        private void dailyIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Legder.DailyIncome di = new Legder.DailyIncome();
            di.Show();
        }

        private void dailyExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Legder.DailyExpenses de = new Legder.DailyExpenses();
            de.Show();
        }

        private void billGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeStructure.BillInfo bi = new FeeStructure.BillInfo();
            bi.Show();
        }

        private void editMenu_Click(object sender, EventArgs e)
        {

        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeStructure.BillPayment bp = new FeeStructure.BillPayment();
            bp.Show();
        }

        private void extraFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
       

        }

        private void billCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeStructure.BillCancel bc = new FeeStructure.BillCancel();
            bc.Show();
        }

        private void receiptCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void paymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeStructure.PaymentHistory ph = new FeeStructure.PaymentHistory();
            ph.Show();
        }

        private void receiptRePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeStructure.RePrintBill rpb = new FeeStructure.RePrintBill();
            rpb.Show();
        }

        private void billPrintToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            FeeStructure.BillPrint bp = new FeeStructure.BillPrint();
            bp.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res== DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void feeGenerationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.FeeGenerationInfo fg = new Reports.FeeGenerationInfo();
            fg.Show();

        }

        private void feePaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports.Form2 rp= new Reports.Form2();
            Reports.StudentPaymentRpt spr = new Reports.StudentPaymentRpt();
            spr.Show();
          
        }

        private void feeDetailsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports.FeeDetailsInfo fd = new Reports.FeeDetailsInfo();
            //fd.Show();
            Reports.ViewFeeDetails vfd = new Reports.ViewFeeDetails();
            vfd.Show();
        }

        

        

        private void resultToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void feeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void feeAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void staffsReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void departmentInformationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Staff.ViewDepartment vd = new Staff.ViewDepartment();
            vd.Show();
        }

        private void marksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Results.MarksheetGeneration mg = new Results.MarksheetGeneration();
            //mg.Show();
        }

        private void marksReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Reports.MarkReport m = new Reports.MarkReport();
            Reports.ViewMarkSheet m = new Reports.ViewMarkSheet();
            m.Show();
        }

        private void findClassToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void batchwiseFeeSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeStructure.DefineFee df = new FeeStructure.DefineFee();
            df.Show();
        }

        private void academicBatchSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.AcademicYearInfo ay = new Common.AcademicYearInfo();
            ay.Show();
        }

        private void sectionTypeSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.SectionType st = new Common.SectionType();
            st.Show();
        }

        private void examTypeSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.ExamType et = new Common.ExamType();
            et.Show();
        }

        private void organizationSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Companyinfo.CompanyInfo ci = new Companyinfo.CompanyInfo();
            //ci.Show();
            Companyinfo.OrganizationInfo oi = new Companyinfo.OrganizationInfo();
            oi.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Student.StudentEnroll se = new Student.StudentEnroll();
            se.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            user.CreateUser cu = new user.CreateUser();
            cu.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            user.ChangePassword cp = new user.ChangePassword();
            cp.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Student.UpdateStudent ms = new Student.UpdateStudent();
            ms.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FeeStructure.BillInfo fg = new FeeStructure.BillInfo();
            fg.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            FeeStructure.BillPayment sp = new FeeStructure.BillPayment();
            sp.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Staff.MonthlySalary ms = new Staff.MonthlySalary();
            ms.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Attendence.StudentAttendence sa = new Attendence.StudentAttendence();
            sa.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labeStudentAttendence_Click(object sender, EventArgs e)
        {

        }

        private void labelSalary_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure to Exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure to Logout?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if(res==DialogResult.Yes)
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void monthlySalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.MonthlySalary ms = new Staff.MonthlySalary();
            ms.Show();
        }

        private void displaySalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.DisplaySalary ds = new Staff.DisplaySalary();
            ds.Show();
        }

        private void staffSalaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.StaffSalaryReport ssr = new Reports.StaffSalaryReport();
            ssr.Show();
        }

        private void marksheetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Results.MarksheetGeneration mg = new Results.MarksheetGeneration();
            mg.Show();
        }

        private void classwiseResutlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results.ClasswiseResult cr = new Results.ClasswiseResult();
            cr.Show();
            //Student.ClassWiseStudents cws = new Student.ClassWiseStudents();
            //cws.Show();
        }

        private void dailyAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Staff.StaffAttendence sa = new Staff.StaffAttendence();
            //sa.Show();
            Staff.EmployeeAttendence ea = new Staff.EmployeeAttendence();
            ea.Show();
        }

        private void viewClassFeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FeeStructure.ClassWiseFeeDetail cwdf = new FeeStructure.ClassWiseFeeDetail();
          cwdf.Show();
        }

        private void batchFeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void classwiseStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student.ClassWiseStudents cws = new Student.ClassWiseStudents();
            cws.Show();
        }

        private void studentRegistraionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ViewStudentByRegistration vs = new Reports.ViewStudentByRegistration();
            vs.Show();
        }

        private void staffRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ViewStaffsInfoReport vsir = new Reports.ViewStaffsInfoReport();
            vsir.Show();
        }

        private void organizationDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Companyinfo.CompanyInfo ci = new Companyinfo.CompanyInfo();
            //ci.Show();
            Companyinfo.OrganizationInfo oi = new Companyinfo.OrganizationInfo();
            oi.Show();
            //Companyinfo.Form1 ci = new Companyinfo.Form1();
            //ci.Show();
           // Companyinfo.OrgInfo obj = new Companyinfo.OrgInfo();
           // obj.Show();
        }

        private void academicYearWiseSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.ClassSubjectsViewReport csvr = new Reports.ClassSubjectsViewReport();
            csvr.Show();
        }

        private void batchWiseFeeeSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeStructure.ClassWiseFeeDetail cwdf = new FeeStructure.ClassWiseFeeDetail();
            cwdf.Show();
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.StudentResultReport srr = new Reports.StudentResultReport();
            srr.Show();
        }

        private void classSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class.ClassAdd cls = new Class.ClassAdd();
            cls.Show();
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeAdvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff.StaffAdvance sa = new Staff.StaffAdvance();
            sa.Show();
        }

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reports.Form1 f = new Reports.Form1();
            //f.Show();
        }

        private void salarySlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.StaffSalarySlip sss = new Reports.StaffSalarySlip();
            sss.Show();
        }

        private void organizationSettingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Companyinfo.frmHotelInfo f = new Companyinfo.frmHotelInfo();
            f.Show();
        }

        private void religionSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeStructure.Common.ReligionInfo r = new FeeStructure.Common.ReligionInfo();
            r.Show();
        }

        private void postToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Staff.Post p = new Staff.Post();
            p.Show();

        }

        private void advanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Staff.Advance A = new Staff.Advance();
            A.Show();
        }

        private void allowanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Staff.Allowance Al = new Staff.Allowance();
            Al.Show();
        }
         



     
    }
}
