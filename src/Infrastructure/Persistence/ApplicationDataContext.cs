using Microsoft.EntityFrameworkCore;
using Domain.Entities;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<UserRoute> UserRoutes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRoute>()
            .HasKey(ur => new { ur.UserRouteId, ur.UserId, ur.RouteId });

        modelBuilder.Entity<UserRoute>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoutes)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRoute>()
            .HasOne(ur => ur.Route)
            .WithMany(r => r.UserRoutes)
            .HasForeignKey(ur => ur.RouteId);
    }
}
   