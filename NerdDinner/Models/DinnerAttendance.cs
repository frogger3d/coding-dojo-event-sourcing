using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class DinnerAttendance
    {
        public int DinnerAttendanceId { get; set; }

        public int DinnerId { get; set; }

        public int AttendanceCount { get; set; }
    }
}