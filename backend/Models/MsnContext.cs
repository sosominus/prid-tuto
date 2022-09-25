using Microsoft.EntityFrameworkCore;

namespace prid_tuto.Models;

public class MsnContext : DbContext
{
    public MsnContext(DbContextOptions<MsnContext> options)
        : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Member>().HasIndex(m => m.FullName).IsUnique();

        modelBuilder.Entity<Member>().HasData(
            new Member { Pseudo = "ben", Password = "ben", FullName = "Benoît Penelle" },
            new Member { Pseudo = "bruno", Password = "bruno", FullName = "Bruno Lacroix" },
            new Member { Pseudo = "alain", Password = "alain", FullName = "Alain Silovy" },
            new Member { Pseudo = "xavier", Password = "xavier", FullName = "Xavier Pigeolet" },
            new Member { Pseudo = "boris", Password = "boris", FullName = "Boris Verhaegen" },
            new Member { Pseudo = "marc", Password = "marc", FullName = "Marc Michel" }
        );
    }

    public DbSet<Member> Members => Set<Member>();
    public DbSet<User> Users => Set<User>();
}