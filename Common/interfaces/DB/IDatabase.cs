using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.interfaces.DB
{
    public interface IDatabase
    {
        string CreateConnection();
        ICollection<T>  GetData<T>();
        T GetScalar<T>(string query);
        void RunProc(string proc);
    }
}
