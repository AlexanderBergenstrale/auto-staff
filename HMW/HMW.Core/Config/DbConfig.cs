
using HMW.Core.Interfaces;

namespace HMW.Core.Config
{
    public class DbConfig : IDbConfig
    {
        public string ConnectionString { get; set; }
    }
}