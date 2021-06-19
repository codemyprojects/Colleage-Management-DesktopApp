/********************************************************************************
Copyright (C) Er. Ganesh Pd Bhatta
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Net.Common.Result
{
  public  class Results
    {
       

            public  int AcademicYearId { get; set; }
            public  int ExamId { get; set; }
            public  string ExamDate { get; set; }
            public  int ClassId { get; set; }
            public  string Section { get; set; }
            public int StudentId { get; set; }
            public  int SubjectId { get; set; }
           
            public  int FullMarks { get; set; }
            public  int PassMarks { get; set; }
            public  int TheoryFullMarks { get; set; }
            public  int TheoryPassMarks { get; set; }
            public  int ObtainedTheoryMarks { get; set; }
            public  int PracticalFullMarks { get; set; }
            public  int PracticalPassMarks { get; set; }
            public  int PracticalMarks { get; set; }
            public int ObtainedMarks { get; set; }
            public  string Result { get; set; }
        
    }
}
