using System;
using System.Collections.Generic;
using ef_core_haymatlos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ef_core_haymatlos.Data;

public partial class PostgresContext : IdentityDbContext<User>
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //Scaffold-DbContext "Server=localhost;Database=postgres;User Id=user;Password=admin;" dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models
        => optionsBuilder.UseNpgsql("Server=localhost;Database=postgres;User Id=user;Password=admin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("posts_pkey");

            entity.ToTable("posts");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Like).HasColumnName("like");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.Tag).HasColumnName("tag");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Uuid).HasColumnName("uuid");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.Posts)
                .HasPrincipalKey(p => p.Uuid)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("nickname");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.HasIndex(e => e.Nickname, "user_nickname_nickname1_key").IsUnique();

            entity.HasIndex(e => e.Uuid, "user_uuid_uuid1_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Nickname).HasColumnName("nickname");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Uuid).HasColumnName("uuid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        return base.SaveChanges();
    }
}



//Note: Once you have created the model, you must use the Migration commands whenever you change the model to keep the database up to date with the model.