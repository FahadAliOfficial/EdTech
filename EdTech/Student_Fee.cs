using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class StudentFee
    {
        public StudentFee()
        {
        }

        public int StudentKey { get; set; }//foreign key to reference the student table
        public int id { get; set; } // for database usage, primary key
        public string S_name { get; set; }
        public string FeeType { get; set; }
        public decimal Total_Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string Fee_status { get; set; }
        public int BillingNumber { get; set; }
        public DateTime? BillingDate { get; set; }
        public DateTime? ExtendDate { get; set; }
        public bool IsPaid { get; set; }

        public Student student { get; set; } = new Student();





        //public StudentFee(int studentID, string studentName, string feeType, decimal totoal_feeAmount, DateTime dueDate, DateTime paidDate, string feeStatus, int billingNumber, DateTime billingDate, DateTime extendDate)
        //{
        //    this.id = studentID;
        //    this.S_name = studentName;
        //    this.FeeType = feeType;
        //    Total_Amount = totoal_feeAmount;
        //    DueDate = dueDate;
        //    PaidDate = paidDate;
        //    this.Fee_status = feeStatus;
        //    this.BillingNumber = billingNumber;
        //    this.BillingDate = billingDate;
        //    this.ExtendDate = extendDate;
        //}


        public void displayStudentFeeInfo()
        {

            Console.WriteLine($" studentID: {StudentKey}\n student Name: {S_name}\n feeType: {FeeType}\n total Fee: {Total_Amount}\n dueDate : {DueDate}\n" +
            $"paidDate : {PaidDate}\n deeStatus : {Fee_status}\n billingNumber : {BillingNumber}\n billing date : {BillingDate}\n extended date : {ExtendDate}\n");
        }


        public void CalculateLateFee()
        {
            if (!PaidDate.HasValue || PaidDate.Value <= DueDate.Value)
            {
                return;
            }
            if (PaidDate.HasValue && DateTime.Now > DueDate.Value)
            {
                TimeSpan lateDays = DateTime.Now - DueDate.Value;
                decimal lateFee = lateDays.Days * 100;

                Total_Amount += lateFee;
            }

        }

        public void GernateInvoice()
        {
            //BillingNumber = GenerateUniqueBillingNumber();
            BillingDate = DateTime.Now;

        }

        public void MarkPayment()
        {
            IsPaid = true;
            PaidDate = DateTime.Now;
        }

        public void SendFeeRemainder()
        {
            TimeSpan daysUntillDue = DueDate.Value - DateTime.Now;
            int daysThreshold = 5;// basically the system should send reminder 5 days before the fee is due

            if (daysUntillDue.Days <= daysThreshold && !IsPaid)
            {
                string remainderMsg = $"Dear {S_name}, your fee is due on {DueDate}";
                //SendNotification(StudentID, remainderMsg);
            }
        }



    }
}