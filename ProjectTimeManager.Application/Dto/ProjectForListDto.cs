using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.Application.Dto
{
    public class ProjectForListDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int PlanedHours { get; set; }
        public double ActualHours { get; set; }
    }
}
