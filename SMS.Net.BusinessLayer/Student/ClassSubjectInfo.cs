/********************************************************************************
Copyright (C) Er. Ganesh Pd Bhatta
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

namespace SMS.Net.BusinessLayer.Student
{
    public class ClassSubjectInfo
    {
        public static int AddClassSubjectInfo(Common.Class.Class c)
        {
            SqlParameter[] param = new SqlParameter[]
          {
              new SqlParameter("@Subject1",c.Subject1),
              new SqlParameter("@Subject2",c.Subject2),
              new SqlParameter("@Subject3",c.Subject3),
              new SqlParameter("@Subject4",c.Subject4),
              new SqlParameter("@Subject5",c.Subject5),
              new SqlParameter("@Subject6",c.Subject6),
              new SqlParameter("@Subject7",c.Subject7),
              new SqlParameter("@Subject8",c.Subject8),
              new SqlParameter("@Subject9",c.Subject9),
              new SqlParameter("@Subject10",c.Subject10),
              new SqlParameter("@Subject11",c.Subject11),
              new SqlParameter("@Subject12",c.Subject12),
              new SqlParameter("@Subject13",c.Subject13),
              new SqlParameter("@Subject14",c.Subject14),
              new SqlParameter("@Subject15",c.Subject15),
              new SqlParameter("@Subject16",c.Subject16),
              new SqlParameter("@Subject17",c.Subject17),
              new SqlParameter("@Subject18",c.Subject18),
              new SqlParameter("@Subject19",c.Subject19),
              new SqlParameter("@Subject20",c.Subject20),
              new SqlParameter("@ClassCode",c.ClassCode),
              new SqlParameter("@SubjectId",""),
              new SqlParameter("@Class",c.ClassName),
              new SqlParameter("@Schedule",c.ClassSchedule)

          };
            return DataBaseLayer.DbOperations.ExecProc("[student].[spClassSubjectInfo]", param, true);
        }

        public static SqlDataReader GetClassSubjectInfoByClassId(Common.Class.Class c)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ClassId",c.ClassId)
            };
           SqlDataReader sdr= DataBaseLayer.DbOperations.GetDataReader("student.spDisplayClassSubjectById", param, true);
           sdr.Read();
           return sdr;
        }
        
    }
}
