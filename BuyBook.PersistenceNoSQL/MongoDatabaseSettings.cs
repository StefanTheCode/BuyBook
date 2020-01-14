using BuyBook.PersistenceNoSQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyBook.PersistenceNoSQL
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
