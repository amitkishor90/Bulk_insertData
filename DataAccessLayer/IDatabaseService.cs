using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal interface IDatabaseService
    {
        void InsertOrdersToDatabase(string connectionString, DataTable orders);
    }
}
