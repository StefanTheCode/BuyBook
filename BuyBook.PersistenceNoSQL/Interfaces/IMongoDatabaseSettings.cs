using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.PersistenceNoSQL.Interfaces
{
    public interface IMongoDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
