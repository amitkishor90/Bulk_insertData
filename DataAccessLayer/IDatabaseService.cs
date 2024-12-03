using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDatabaseService
    {
        void InsertOrdersToDatabase(string tablename, DataTable orders);
    }
}
