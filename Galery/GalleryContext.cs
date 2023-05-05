using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Galery;

public partial class GalleryContext : DbContext
{
    public GalleryContext()
    {
    }

    public GalleryContext(DbContextOptions<GalleryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Creator> Creators { get; set; }

    public virtual DbSet<Crosscreatorpaint> Crosscreatorpaints { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Paint> Paints { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.1.14;database=gallery;user=student;password=student", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .HasColumnName("patronymic");
        });

        modelBuilder.Entity<Creator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("creator");

            entity.HasIndex(e => e.Genre, "FK_creator_genre");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Genre)
                .HasColumnType("int(11)")
                .HasColumnName("genre");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.Creators)
                .HasForeignKey(d => d.Genre)
                .HasConstraintName("FK_creator_genre");
        });

        modelBuilder.Entity<Crosscreatorpaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("crosscreatorpaint");

            entity.HasIndex(e => e.IdCreator, "FK_crosscreatorpaint_creator_id");

            entity.HasIndex(e => e.IdPaint, "FK_crosscreatorpaint_paint_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdCreator)
                .HasColumnType("int(11)")
                .HasColumnName("idCreator");
            entity.Property(e => e.IdPaint)
                .HasColumnType("int(11)")
                .HasColumnName("idPaint");

            entity.HasOne(d => d.IdCreatorNavigation).WithMany(p => p.Crosscreatorpaints)
                .HasForeignKey(d => d.IdCreator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_crosscreatorpaint_creator_id");

            entity.HasOne(d => d.IdPaintNavigation).WithMany(p => p.Crosscreatorpaints)
                .HasForeignKey(d => d.IdPaint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_crosscreatorpaint_paint_id");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("genre");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Genre1)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("genre");
        });

        modelBuilder.Entity<Paint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paint");

            entity.HasIndex(e => e.Genre, "FK_paint_genre");

            entity.HasIndex(e => e.Time, "FK_paint_time");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DateOfCreate)
                .HasColumnType("int(11)")
                .HasColumnName("dateOfCreate");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.Genre)
                .HasColumnType("int(11)")
                .HasColumnName("genre");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.PhotoPaint)
                .HasMaxLength(255)
                .HasColumnName("photoPaint");
            entity.Property(e => e.Time)
                .HasColumnType("int(11)")
                .HasColumnName("time");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.Paints)
                .HasForeignKey(d => d.Genre)
                .HasConstraintName("FK_paint_genre");

            entity.HasOne(d => d.TimeNavigation).WithMany(p => p.Paints)
                .HasForeignKey(d => d.Time)
                .HasConstraintName("FK_paint_time");
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("time");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Time1)
                .HasMaxLength(255)
                .HasColumnName("time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
