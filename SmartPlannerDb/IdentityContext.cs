using Microsoft.EntityFrameworkCore;
using SmartPlannerDb.Model;
using SmartPlannerDb;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartPlannerDb
{
    public class IdentityContext : IdentityDbContext<User>
    {
        
    }
}
