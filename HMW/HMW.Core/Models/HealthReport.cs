using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Models
{
    public class HealthReport : ModelBase
    {
        public enum HealthStatus
        {
            NotSet,
            Healthy,
            Sick
        }

        public string EmployeeId { get; set; }
        public string Note { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public HealthStatus Status { get; set; }
    }
}
