using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlannerDb.Entities
{
    public class Goal
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public int TotalProgress { get; set; }
        public int CurrentProgress { get; set; }

        //Навигационные свойства:
        public User User { get; set; }

        // Связь с проектом (необязательное свойство)
        public Guid? ProjectId { get; set; } // Nullable Guid
    }
}
