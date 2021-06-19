/********************************************************************************
Copyright (C) Er. Ganesh Pd Bhatta
***********************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Net.BusinessLayer.Staff
{
   public class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffContact { get; set; }
    }
    public class StaffDetail:Staff
    {
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
    public class StaffDataAccess
    {
        public static List<Staff> GetStaffList()
        {
            List<Staff> StaffList = new List<Staff>();
            DataTable dt = new DataTable();
            dt = DataBaseLayer.DbOperations.GetDataTable("spStaffsInfoDisplay", null, true);
            foreach(DataRow dr in dt.Rows)
            {
                Staff s = new Staff();
                s.StaffId = Convert.ToInt32( dr["StaffId"]);
                s.StaffName = dr["StaffName"].ToString();
                s.StaffContact = dr["StaffContact"].ToString();
                StaffList.Add(s);
            }
            return StaffList;
        }

        public static int  AddStaff(Common.Staff.Staffs staff,Common.Staff.Department d)
        {
            SqlParameter[] param = new SqlParameter[]
            {  
                new SqlParameter("@StaffCode",staff.StaffCode),
                new SqlParameter("@StaffName",staff.StaffName),
                new SqlParameter("@StaffGender",staff.StaffGender),
                new SqlParameter("@StaffContact",staff.StaffContact),
                new SqlParameter("@StaffMobile",staff.StaffMobile),
                new SqlParameter("@StaffEmail",staff.StaffEmail),
                new SqlParameter("@StaffAddress",staff.StaffAddress),
                new SqlParameter("@StaffPhoto",(object)staff.StaffPhoto),
                new SqlParameter("@ImageData",(object)staff.ImageData),
                new SqlParameter("@StaffNationality",staff.StaffNationality),
                new SqlParameter("@StaffAge",staff.StaffAge),
                new SqlParameter("@Religion",staff.Religion),
                new SqlParameter("@Caste",staff.Caste),
                new SqlParameter("@MaritalStatus",staff.MaritalStatus),
                new SqlParameter("@StaffQualification",staff.StaffQualification),
                new SqlParameter("@DepartmentId", d.DepartmentId),
                new SqlParameter("@StaffPost",staff.StaffPost),
                new SqlParameter("@StaffEnrollMentDate",""),
                new SqlParameter("@StaffSalary",staff.StaffSalary),
                new SqlParameter("@StaffContractTerminationDate",""),
                new SqlParameter("@JobStatus",staff.JobStatus),
                new SqlParameter("@PreviousExperience",staff.PreviousExperience),
                new SqlParameter("@NoOfYear",staff.NoOfYea),
                new SqlParameter("@Remarks",staff.Remarks),
                new SqlParameter("@PreviousEmployer",staff.PreviousEmployer),
                new SqlParameter("@StaffType",staff.StaffType),
                new SqlParameter("@Subject1",staff.Subject1),
                new SqlParameter("@Subject2",staff.Subject2),
                new SqlParameter("@Subject3",staff.Subject3),
                new SqlParameter("@Subject4",staff.Subject4),
     
            };
            return DataBaseLayer.DbOperations.ExecProc("[staff].[StaffRegistration]", param, true);
        }
        public static int AddDepartment(Common.Staff.Department department)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DepartmentCode ",department.DepartmentCode),
                new SqlParameter("@DepartmentName ",department.DepartmentName),
                new SqlParameter("@DepartmentDescription",department.DepartmentDescription)
            };
            return DataBaseLayer.DbOperations.ExecProc("[staff].[spAddDepartment]", param, true);
        }
        public static SqlDataReader GetDepartmentById(Common.Staff.Department department)
        {
           
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DepartmentId",department.DepartmentId)

            };
            SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("[staff].[spDisplayDepartmentById]", param, true);
            sdr.Read();
            return sdr;
        }
        public static int UpdateDepartment(Common.Staff.Department department)
        {
            SqlParameter[] param = new SqlParameter[]
            {   
                new SqlParameter("@DepartmentId",department.DepartmentId),
                new SqlParameter("@DepartmentCode",department.DepartmentCode),
                new SqlParameter("@DepartmentName",department.DepartmentName),
                new SqlParameter("@DepartmentDescription",department.DepartmentDescription)
            };
           return DataBaseLayer.DbOperations.ExecProc("staff.spUpdateDepartment",param,true);
        }
        public static int DeleteDepartment(Common.Staff.Department department)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DepartmentId",department.DepartmentId)

            };
            return DataBaseLayer.DbOperations.ExecProc("[staff].[spDeleteDepartmentById]", param, true);
        }

        public static SqlDataReader GetTotalStaffByDepartmentId(Common.Staff.Department department)
        {
            SqlParameter[] param = new SqlParameter[]
           {
               new SqlParameter("@DepartmentId",department.DepartmentId)
           };

            SqlDataReader sdr= DataBaseLayer.DbOperations.GetDataReader("staff.spGetTotalStaffById", param, true);
            sdr.Read();
            return sdr;
        }
        public static DataTable GetStaffByCode(Common.Staff.Staffs staff)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StaffCode",staff.StaffCode)
            };
            return DataBaseLayer.DbOperations.GetDataTable("[staff].[spDisplayStaffByCode]", param, true);
        }

        public static SqlDataReader GetByCode(Common.Staff.Staffs staff)
        {
            SqlParameter[] param = new SqlParameter[]
            {
               new SqlParameter("@StaffCode",staff.StaffCode)
            };
            SqlDataReader sdr= DataBaseLayer.DbOperations.GetDataReader("[staff].[spDisplayStaffByCode]", param, true);
            sdr.Read();
            return sdr;
        }

        public static int UpadateStaffRegistration(Common.Staff.Staffs staff,Common.Staff.Department department)
        {
            SqlParameter[] param = new SqlParameter[]
            {  
                new SqlParameter("@DepartmentId",department.DepartmentId),
                new SqlParameter("@StaffCode",staff.StaffCode),
                new SqlParameter("@StaffName",staff.StaffName),
                new SqlParameter("@StaffGender",staff.StaffGender),
                new SqlParameter("@StaffContact",staff.StaffContact),
                new SqlParameter("@StaffMobile",staff.StaffMobile),
                new SqlParameter("@StaffEmail",staff.StaffEmail),
                new SqlParameter("@StaffAddress",staff.StaffAddress),
                new SqlParameter("@StaffPhoto",(object)staff.StaffPhoto),
                new SqlParameter("@ImageData",(object)staff.ImageData),
                new SqlParameter("@StaffNationality",staff.StaffNationality),
                new SqlParameter("@StaffAge",staff.StaffAge),
                new SqlParameter("@Religion",staff.Religion),
                new SqlParameter("@Caste",staff.Caste),
                new SqlParameter("@MaritalStatus",staff.MaritalStatus),
                new SqlParameter("@StaffQualification",staff.StaffQualification),
                new SqlParameter("@StaffPost",staff.StaffPost),
                new SqlParameter("@StaffEnrollMentDate",""),
                new SqlParameter("@StaffSalary",staff.StaffSalary),
                new SqlParameter("@StaffContractTerminationDate",""),
                new SqlParameter("@JobStatus",staff.JobStatus),
                new SqlParameter("@PreviousExperience",staff.PreviousExperience),
                new SqlParameter("@NoOfYear",staff.NoOfYea),
                new SqlParameter("@Remarks",staff.Remarks),
                new SqlParameter("@PreviousEmployer",staff.PreviousEmployer),
                new SqlParameter("@StaffType",staff.StaffType),
                new SqlParameter("@Subject1",staff.Subject1),
                new SqlParameter("@Subject2",staff.Subject2),
                new SqlParameter("@Subject3",staff.Subject3),
                new SqlParameter("@Subject4",staff.Subject4),
     
            };
            return DataBaseLayer.DbOperations.ExecProc("[staff].[spUpdateStaffRegistration]", param, true);
        }

    }
}
