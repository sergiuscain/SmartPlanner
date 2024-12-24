using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SmartPlannerDb.Entities
{
    public class User : IdentityUser 
    {
        public ICollection<Note> Notes { get; set; }
        public ICollection<TaskModel> Tasks { get; set; }
        public ICollection<Goal> Goals { get; set; }
    }
}
