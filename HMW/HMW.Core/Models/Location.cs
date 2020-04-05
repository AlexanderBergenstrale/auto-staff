using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Models
{
    public class Location : ModelBase
    {
        public string OrganizationId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Telephone { get; set; }
    }
}
