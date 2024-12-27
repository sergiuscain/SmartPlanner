using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlannerDb.Entities
{
    public class SubTask
    {
        public Guid SubTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid TaskId { get; set; }
        public TaskModel Task { get; set; }
    }
}
