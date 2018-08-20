using Common.interfaces.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleDB
{
    public class OracleDatabase : IDatabase
    {

        public OracleDatabase()
        {

        }

        public string CreateConnection()
        {
            return "Oracle connection created";
        }

        public ICollection<T> GetData<T>()
        {
            return new List<T>();
        }

        public T GetScalar<T>(string query)
        {
            return default(T);
        }

        public void RunProc(string proc)
        {
            Console.WriteLine("Procedure oracle running ..." + proc);
        }
    }
}
