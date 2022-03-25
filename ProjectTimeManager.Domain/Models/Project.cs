using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public int PlanedHours { get; set; }
        public long SecondCounter { get; set; }
        public bool NowWorking { get; set; }
        public DateTime? WorkStart { get; set; }
    }
}
