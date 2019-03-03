using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Demos.SalesTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Designation { get; set; }
        public string Department { get; set; }
        public IdentityUser ReportingManger { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectDocument> ProjectDocument { get; set; }
        public DbSet<SupportingDocument> SuportingDocument { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<SubRegion> SubRegion { get; set; }
        public DbSet<ProjectDocumentInfo> ProjectDocumentInfo { get; set; }
        public DbSet<SupportingDocumentInfo> SupportingDocumentInfo { get; set; }
    }
}