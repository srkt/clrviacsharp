using Clr.Via.CSharp.AppDomains.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clr.Via.CSharp.AppDomains
{
    [Serializable]
    public class Project : ITask
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public ICollection<ITask> SubTasks { get; set; }

        public Project(string name)
        {
            this.Name = name;
        }

        public void SetDates(DateTime start, DateTime finish)
        {
            this.StartDate = start;
            this.FinishDate = finish;
        }
    }
}
