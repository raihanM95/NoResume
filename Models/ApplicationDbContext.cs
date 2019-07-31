using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NoResume.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

        public DbSet<AuditLogging> Audits { get; set; }
        public DbSet<ShortBio> ShortBios { get; set; }
        public DbSet<SocialProfile> SocialProfiles { get; set; }
        public DbSet<WorkingProfile> WorkingProfiles { get; set; }
    }
}