using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdTech
{
    public class TimeTable
    {
        public int Id { get; set; } = 0;
        public int CGrade { get; set; } = 0;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DayOfWeek Day { get; set; }
        public string Subject { get; set; } = "";
        
    }
}
