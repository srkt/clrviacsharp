using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clr.Via.CSharp.AppDomains.interfaces
{
    public interface ITask
    {
        string Name { get; set; }
        DateTime StartDate { get; set; }
        DateTime? FinishDate { get; set; }
    }
}
