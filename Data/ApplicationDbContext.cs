
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YogamedAppRole.Models;

namespace YogamedAppRole.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DiseaseTable> DiseaseTable { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<UserDisease> UserDisease { get; set; }
        public virtual DbSet<YogaTable> YogaTable { get; set; }
    }
}
