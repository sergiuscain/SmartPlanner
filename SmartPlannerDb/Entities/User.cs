using Microsoft.AspNetCore.Identity;
using System.Drawing;

namespace SmartPlannerDb.Entities
{
    public class User : IdentityUser
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
