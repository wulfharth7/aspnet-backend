using ef_core_haymatlos.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_core_haymatlos.Data
{
    public class DatabaseConfig : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=postgres;User Id=user;Password=admin;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OneToManyRelationshipConfiguration(modelBuilder);
        }

        private void OneToManyRelationshipConfiguration(ModelBuilder modelBuilder) //1-N relationship.
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User) 
                .HasForeignKey(p => p.Owner)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();                                                      //isRequired is used to prevent the relationship from being optional.
        }

        public DbSet<UserModel> Users { get; set;}
        public DbSet<PostModel> Posts { get; set;}
    }
}
