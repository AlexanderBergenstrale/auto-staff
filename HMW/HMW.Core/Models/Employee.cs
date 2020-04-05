using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Models
{
    public class Employee : ModelBase
    {
        public string OrganizationId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}
