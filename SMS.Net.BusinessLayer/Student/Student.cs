/********************************************************************************
Copyright (C) Ganesh Pd Bhatta, Mix Open Foundation (http://sms.org).
***********************************************************************************/
using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Net.DataBaseLayer;

namespace SMS.Net.BusinessLayer
{
    public class Students
    {
        
    
       //public static int EnrollStudent(string code,string name,string gender)
       // {
       //     SqlParameter[] param = new SqlParameter[]
       //    {
       //        new SqlParameter("@StudentCode",code),
       //        new SqlParameter("@StudentName",name),
       //        new SqlParameter("@StudentGender",gender)
       //    };
       //     return DataBaseLayer.DbOperations.ExecProc("spInsertStudent", param, true);
       // }
        public static int EnrollStudent(Common.Student.StudentsEnroll student,Common.Student.GuardiansInfo guardian,Common.Class.Class clas)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentCode",student.StudentCode),
                new SqlParameter("@AcademicYearId",student.academicYearId),
                new SqlParameter("@ClassId",clas.ClassId),
                new SqlParameter("@StudentName",student.StudentName),
                new SqlParameter("@StudentGender",student.StudentGender),
                new SqlParameter("@StudentDoB",student.StudentDoB),
                new SqlParameter("@ReligionId",student.ReligionId),
                new SqlParameter("@StudentNationality",student.StudentNationality),
                new SqlParameter("@PermanentAddress",student.PermanentAddress),
                new SqlParameter("@TemporaryAddress",student.TemporaryAddress),
                new SqlParameter("@PreviousSchoolName",student.PreviousSchoolName),
                new SqlParameter("@PassedClass",student.PassedClass),
                new SqlParameter("@PassedYear",student.StudentPassedYear),
                new SqlParameter("@DivisionId",student.DivisionId),
               
                /* for inserting data into GuardiansInfo */
                new SqlParameter("@StudentId",""),
                new SqlParameter("@FatherName",guardian.FatherName),
                new SqlParameter("@FatherOccupation",guardian.FatherOccupation),
                new SqlParameter("@MotherName",guardian.MotherName),
                new SqlParameter("@MotherOccupation",guardian.MotherOccupation),
                new SqlParameter("@HomeNumber",guardian.HomeNumber),
                new SqlParameter("@MobileNumber",guardian.MobileNumber),

                //new SqlParameter("@PictureName",student.PictureName),
                //passing original path of the image to the picture parameter and passing converted binary image to the picture parameter
                new SqlParameter("@PictureName",(object)student.PictureName),
                new SqlParameter("@Picture",(object)student.Picture)

            };
 
            return DataBaseLayer.DbOperations.ExecProc("student.spStudentEnroll", param, true);
        }

        public static int EnrollStudent(Common.Student.StudentsEnroll student)
        {

            SqlParameter[] param=new SqlParameter[]
            {
                new SqlParameter("@PictureName",(object)student.PictureName),
                new SqlParameter("@Picture",(object)student.Picture)
                //new SqlParameter("@Picture",student.Picture)

            };
            return DataBaseLayer.DbOperations.ExecProc("common.spPictureInfo", param, true);

        }
        public static int UpdatePicture(Common.Student.StudentsEnroll student)
        {
            SqlParameter[] param=new SqlParameter[]
            {
                new SqlParameter("@StudentId",student.StudentId),
                new SqlParameter("@PictureName",student.PictureName)
            };
           return  DataBaseLayer.DbOperations.ExecProc("common.spUpadtePictureInfo", param, true);
        }

        //public static DataTable GetStudentsByCode(Common.Student.StudentsEnroll student)
        //{  
        //     SqlParameter[] param=new SqlParameter[]
        //     {
        //         new SqlParameter("@StudentCode",student.StudentCode)

        //     };
        //    return DataBaseLayer.DbOperations.GetDataTable("student.spSearchStudent",param,true);
        //}
        public static SqlDataReader GetStudentsByCode(Common.Student.StudentsEnroll student)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentCode",student.StudentCode)
            };
            SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("student.spSearchStudent", param, true);
            sdr.Read();
            return sdr;
        }
        public static DataTable GetStudentsByCodeClassId(Common.Student.StudentsEnroll student, Common.Class.Class c)
        {
            SqlParameter[] param = new SqlParameter[]
             {
                 new SqlParameter("@StudentCode",student.StudentCode),
                 new SqlParameter("@ClassId",c.ClassId)

             };
            return DataBaseLayer.DbOperations.GetDataTable("[student].[spGetStudentByCodeClassId]", param, true);
        }

        public static DataTable GetStudents()
       {
           return DataBaseLayer.DbOperations.GetDataTable("student.spStudents",null,true);
       }


        public static SqlDataReader SearchStudent(string code)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentCode",code)
            };
            return DataBaseLayer.DbOperations.GetDataReader("spSearchStudent", param, true);
        }

        public static int UpdateStudent(Common.Student.StudentsEnroll se,Common.Student.GuardiansInfo gi)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StudentCode",se.StudentCode),
                new SqlParameter("ClassId",se.ClassId),
                new SqlParameter("@StudentName",se.StudentName),
                new SqlParameter("@StudentGender",se.StudentGender),
                new SqlParameter("@StudentDoB",se.StudentDoB),
                new SqlParameter("@ReligionId",se.ReligionId),
                new SqlParameter("@StudentNationality",se.StudentNationality),
                /*new SqlParameter("@StudentPhoto",se.StudentPhoto),*/
                new SqlParameter("@PermanentAddress",se.PermanentAddress),
                new SqlParameter("@TemporaryAddress",se.TemporaryAddress),
                new SqlParameter("@PreviousSchoolName",se.PreviousSchoolName),
                new SqlParameter("@PassedClass",se.PassedClass),
                new SqlParameter("@Passedyear",se.StudentPassedYear),
                new SqlParameter("@DivisionId",se.DivisionId),
                new SqlParameter("@PictureName",(object)se.PictureName),
                new SqlParameter("@Picture",(object)se.Picture),

                new SqlParameter("@StudentId",se.StudentId),
                new SqlParameter("@FatherName",gi.FatherName),
                new SqlParameter("@FatherOccupation",gi.FatherOccupation),
                new SqlParameter("@MotherName",gi.MotherName),
                new SqlParameter("@MotherOccupation",gi.MotherOccupation),
                new SqlParameter("@HomeNumber",gi.HomeNumber),
                new SqlParameter("@MobileNumber",gi.MobileNumber)
            };
            return DataBaseLayer.DbOperations.ExecProc("[student].[spUpdateStudentEnroll]", param, true);
        }
    }
}
