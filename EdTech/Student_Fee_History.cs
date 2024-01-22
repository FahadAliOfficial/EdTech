using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class StudentFeeHistory
    {
        public int StudentFeeID { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal amountPaid { get; set; }

    }
}