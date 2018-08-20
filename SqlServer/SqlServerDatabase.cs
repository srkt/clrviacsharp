using Common.attributes;
using Common.interfaces.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServer
{
    public class SqlServerDatabase : IDatabase
    {
        public SqlServerDatabase()
        {

        }


        [ReflectionInvocation(true,DisabledByUser ="Ravi")]
        public string CreateConnection()
        {
            return "SqlServer connection created";
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
            Console.WriteLine("Procedure SqlServer running ..." + proc);
        }
    }
}
