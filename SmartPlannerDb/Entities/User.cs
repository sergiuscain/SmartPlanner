using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SmartPlannerDb.Model;

namespace SmartPlannerDb.Entities
{
    public class User : IdentityUser 
    {
        public ICollection<Note> Notes { get; set; }
        public ICollection<TaskModel> Tasks { get; set; }
    }
}
