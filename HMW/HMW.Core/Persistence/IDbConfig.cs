
namespace HMW.Core.Persistence
{
    public interface IDbConfig
    {
        string ConnectionString { get; set; }
    }

    public class DbConfig : IDbConfig
    {
        public string ConnectionString { get; set; }
    }
}