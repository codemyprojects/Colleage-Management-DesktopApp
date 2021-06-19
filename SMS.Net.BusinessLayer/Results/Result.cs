/********************************************************************************
Copyright (C) Er. Ganesh Pd Bhatta
***********************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Net.BusinessLayer.Results
{
    public class Result
    {

        public static int ResutltEntry(Common.Result.Results r)
        {
            SqlParameter[] param = new SqlParameter[]
         {   
             new SqlParameter("@AcademicYearId",r.AcademicYearId),
             new SqlParameter("@ExamId",r.ExamId),
             new SqlParameter("@ExamDate",r.ExamDate),
             new SqlParameter("@ClassId",r.ClassId),
             new SqlParameter("@Section",r.Section),
             new SqlParameter("@SubjectId",r.SubjectId),
             new SqlParameter("@StudentId",r.StudentId),
             new SqlParameter("@FullMarks",r.FullMarks),
             new SqlParameter("@PassMarks",r.PassMarks),
             new SqlParameter("@TheoryFM",r.TheoryFullMarks),
             new SqlParameter("@TheoryPM",r.TheoryPassMarks),
             new SqlParameter("@ObtainedTheoryMarks",r.ObtainedTheoryMarks),
             new SqlParameter("@PracticalFM",r.PracticalFullMarks),
             new SqlParameter("@PracticalPM",r.PracticalPassMarks),
             new SqlParameter("@ObtainedPracticalMarks",r.PracticalMarks),
             new SqlParameter("@ObtainedMarks",r.ObtainedMarks),
             new SqlParameter("@Result",r.Result)
         };
            return DataBaseLayer.DbOperations.ExecProc("[student].[spResultEntry]", param, true);
        }
    }
}
