using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Contexts;
public class MsDbContext : IdentityDbContext {
    public MsDbContext(DbContextOptions<MsDbContext> options) : base(options) { }
    public DbSet<SavedPassword> SavedPasswords { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasMany(x => x.SavedPasswords).WithOne(x => x.Category).OnDelete(DeleteBehavior.NoAction);
    }
}