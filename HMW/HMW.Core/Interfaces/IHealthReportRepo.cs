using HMW.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Interfaces
{
    public interface IHealthReportRepo
    {
        IList<HealthReport> GetAll();
        IList<HealthReport> GetByEmployeeId(string id);
        HealthReport Get(string id);
        void Save(HealthReport healthReport);


    }
}
