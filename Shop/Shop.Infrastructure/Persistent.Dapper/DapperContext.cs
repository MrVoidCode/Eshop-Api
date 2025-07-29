using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Shop.Infrastructure.Persistent.Dapper
{
    internal class DapperContext
    {
        private readonly string _ConnectionString;

        public DapperContext(string connectionstring)
        {
            _ConnectionString = connectionstring;
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_ConnectionString);

        public string Inventories => $"[Seller].Inventories";
    }
}
