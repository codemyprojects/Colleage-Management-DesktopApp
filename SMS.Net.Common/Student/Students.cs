/********************************************************************************
Copyright (C) Er. Ganesh Pd Bhatta
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Net.Common.Student
{  
    
   public  class Students
    {
        //public int StudentId { get; set; }
        //public string StudentCode { get; set; }
        //public string StudentName { get; set; }
        //public string StudentGender { get; set; }
        public string StudentAddress { get; set; }
        //public string StudentContact { get; set; }
    }
    public class StudentsEnroll:Students
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public int academicYearId { get; set; }
        public string ClassName { get; set; }
        public string StudentRollNumber { get; set; }
        public string StudentName { get; set; }
        public string StudentGender { get; set; }
        public string StudentEmail { get; set; }
        public DateTime StudentDoB { get; set; }
        public int ReligionId { get; set; }
        public string StudentNationality { get; set; }
        public string PermanentAddress { get; set; }
        public string TemporaryAddress { get; set; }
        public string StudentPhoto { get; set; }
        public int ClassId { get; set; }
        public int PassedClass { get; set; }
        public int StudentPassedYear { get; set; }
        public string PreviousSchoolName { get; set; }
        public int DivisionId { get; set; }
        public byte[] ImageToByte { get; set; }

        public int PictureId { get; set; }
        public string PictureName { get; set; }
        public byte[] Picture { get; set; }
    }

    public class GuardiansInfo : StudentsEnroll
    {
        public int    GuardianId { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOccupation { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
    }
}
