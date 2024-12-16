using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartPlannerDb.Model
{
    public class User : IdentityUser
    {
        public List<Note> Notes { get; set; }
    }
}
