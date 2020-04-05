using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Models
{
    public class Absence
    {
        public string EmployeeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string LocationId { get; set; }
        public DateTime Created { get; set; }
        public string Note { get; set; }
    }
}
