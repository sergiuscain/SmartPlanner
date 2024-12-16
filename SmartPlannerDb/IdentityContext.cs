using Microsoft.AspNet.Identity.EntityFramework;
using SmartPlanner.Data.Entities;

namespace SmartPlannerDb
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext() : base() {}
        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}
