using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.Application.Dto
{
    public class NewProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public int PlanedHours { get; set; }
    }
}
