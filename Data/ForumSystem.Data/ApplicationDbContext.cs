using ForumSystem.Data.Migrations;
using ForumSystem.DataModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ForumSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Tag> Tags { get; set; }
    }
}
