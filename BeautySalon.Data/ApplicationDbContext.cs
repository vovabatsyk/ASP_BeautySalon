using BeautySalon.Data.Models;
using BeautySalon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PostModel> PostModels { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<CommentModel> CommentModels { get; set; }

    }
}
