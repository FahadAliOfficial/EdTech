using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class Salary
    {
        public int SalaryID { get; set; }
        public int? TeacherID { get; set; }
        public int? StaffID { get; set; }
        public string S_Month { get; set; }
        public DateTime issueDate { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal HouseRent { get; set; }
        public decimal Others { get; set; }
        public decimal deductions { get; set; }


        //public decimal CalculateTotalSalary()
        //{

        //}


    }
}