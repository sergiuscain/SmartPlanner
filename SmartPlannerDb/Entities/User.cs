using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartPlanner.Data.Entities
{
    public class User : IdentityUser
    {
        public List<Note> Notes { get; set; }
    }
}
