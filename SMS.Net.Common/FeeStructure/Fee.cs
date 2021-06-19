/********************************************************************************
Copyright (C) Er. Ganesh Pd Bhatta
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Net.Common.FeeStructure
{
   public class Fee
    {
        public int FeeId { get; set; }
        public string FeeCode { get; set; }
        public string FeeName { get; set; }
        public string FeeAmount { get; set; }
        public string FeeDescription { get; set; }
        public int AcademicYearId{get;set;}
	    public int ClassId{get;set;} 
	    public double FormFee{get;set;}
	    public double AdmissionFee{get;set;}
	    public double TutionFee{get;set;} 
	    public double LibraryFee{get;set;}
	    public double ComputerFee{get;set;} 
	    public double SportsFee{get;set;} 
	    public double HostelFee{get;set;} 
	    public double LabFee{get;set;} 
	    public double TransportationFee{get;set;} 
	    public double CanteenFee{get;set;} 
	    public double ExtraTutionFee{get;set;} 
	    public double OtherFee{get;set;}
        public double TotalFee { get; set; }

    }
}
