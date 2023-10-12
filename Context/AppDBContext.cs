using ClsOutDocDeliveryCtrl.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ClsOutDocDeliveryCtrl.Context;

internal class AppDBContext : DbContext
{
    public AppDBContext()
    {

    }
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    // DbSet properties for your entities
    public DbSet<Project> Projects { get; set; }    
    public DbSet<Document> Documents { get; set; }

    // Add any additional configuration here
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ClsOutDocDeliveryCtrl"].ConnectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //unique project name
        modelBuilder.Entity<Project>()
            .HasIndex(p => p.Name)
            .IsUnique();

        // Configure the relationship between Project and Document with cascading delete
        modelBuilder.Entity<Document>()
            .HasOne(d => d.Project)
            .WithMany(p => p.Documents)
            .HasForeignKey(d => d.ProjectId)
            .HasPrincipalKey(p => p.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        //project id in the document is not null 
        modelBuilder.Entity<Document>()
            .Property(d => d.ProjectId)
            .IsRequired();

        //project id  + document name is unique combination
        modelBuilder.Entity<Document>()
            .HasIndex(d => new { d.Name, d.ProjectId })
            .IsUnique();
    }
}
