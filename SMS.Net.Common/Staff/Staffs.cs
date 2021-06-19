/********************************************************************************
Copyright (C) Er. Ganesh Pd Bhatta
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Net.Common.Staff
{
   public class Staffs
    {
        public  int StaffId { get; set; }
        public string StaffCode { get; set; }
        public string StaffName { get; set; }
        public string StaffContact { get; set; }
        public string StaffAddress { get; set; }

  
        public string  StaffMobile {get;set;}
        public string StaffEmail { get; set; }
        public string StaffPhoto {get;set;}
        public byte[] ImageData { get; set; }
        public string StaffNationality {get;set;}
        public string StaffAge {get;set;}
        public string StaffGender { get; set; }
        public int Religion{get;set;}
        public string Caste {get;set;}
        public string MaritalStatus {get;set;}
        public string StaffQualification {get;set;}
        public int StaffPost {get;set;}
        public string StaffEnrollMentDate {get;set;}
        public double StaffSalary {get;set;} 
        public string StaffContractTerminationDate{get;set;} 
        public int JobStatus {get;set;}
        public bool? PreviousExperience {get;set;}
        public string NoOfYea {get;set;}
        public string Remarks {get;set;}
        public string PreviousEmployer{get;set;}
        public string StaffType{get;set;}  
        public string Subject1{get;set;}  
        public string Subject2{get;set;} 
        public string Subject3{get;set;}
        public string Subject4{get;set;}
        public bool? Status { get; set; }
    

    }
   public class Department:Staffs
    {
        public int? DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription{    get; set;}
       
    }
   
}
