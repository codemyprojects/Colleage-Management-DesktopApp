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

namespace SMS.Net.BusinessLayer.FeeStructure
{
   public class AddFee
    {
        public static int AddFeeStructure(Common.FeeStructure.Fee f)
        {
            SqlParameter[] param = new SqlParameter[]
           {
               new SqlParameter("@AcademicYearId",f.AcademicYearId),
               new SqlParameter("@ClassId ",f.ClassId),
               new SqlParameter("@FormFee",f.FormFee),
               new SqlParameter("@AdmissionFee",f.AdmissionFee),
               new SqlParameter("@TutionFee",f.TutionFee),
               new SqlParameter("@LibraryFee",f.LibraryFee),
               new SqlParameter("@ComputerFee ",f.ComputerFee),
               new SqlParameter("@SportsFee",f.SportsFee),
               new SqlParameter("@HostelFee",f.HostelFee),
               new SqlParameter("@LabFee",f.LabFee), 
               new SqlParameter("@TransportationFee ",f.TransportationFee),
               new SqlParameter("@CanteenFee",f.CanteenFee),
               new SqlParameter("@ExtraTutionFee",f.ExtraTutionFee),
               new SqlParameter("@OtherFee",f.OtherFee),
               new SqlParameter("@TotalFee",f.TotalFee)
           };
            return DataBaseLayer.DbOperations.ExecProc("student.spFeeStructureInfo", param, true);
        }

       public static SqlDataReader ViewFee(Common.Class.Class c)
        {
            SqlParameter[] param = new SqlParameter[]
           {
               new SqlParameter("@ClassId",c.ClassId)

           };
            SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("student.[spFeeStructureDisplay]", param, true);
            sdr.Read();
            return sdr;
        }
       public static SqlDataReader DisplyFeeByFeeId(Common.FeeStructure.Fee f)
       {
           SqlParameter[] param = new SqlParameter[]
               {
                   new SqlParameter("@FeeId",f.FeeId)
               };
           SqlDataReader sdr = DataBaseLayer.DbOperations.GetDataReader("student.DisplyFeeByFeeId", param, true);
           sdr.Read();
           return sdr;
       }
    }
}
