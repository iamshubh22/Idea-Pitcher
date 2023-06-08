using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Migrations;
using IdeaPitcher.DAL.Models;
using IdeaPitcher.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IdeaPitcher.DAL.Data;

public class ApplicationDbContext : IdentityDbContext<IdeaPitcherUser>
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ContentModel> Posts { get; set; }

    public DbSet<CommentModel> Comment { get; set; }

    public DbSet<TeamModel> Team { get; set; }

    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
       // builder.Entity<TeamModel>()
       //.HasOne(t => t.TeamLeader)
       //.WithOne()
       //.HasForeignKey<TeamModel>(t => t.TeamLeaderId);

       // builder.Entity<IdeaPitcherUser>()
       //     .HasOne(u => u.Team)
       //     .WithOne(t => t.TeamLeader)
       //     .HasForeignKey<IdeaPitcherUser>(u => u.TeamId);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<IdeaPitcherUser>
    {
        public void Configure(EntityTypeBuilder<IdeaPitcherUser> builder)
        {
            builder.Property(u => u.Name).HasMaxLength(255);
        }
    }
}
