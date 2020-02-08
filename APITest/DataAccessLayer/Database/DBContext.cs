using System;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace DataAccessLayer.Database
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAlbumRatings> TAlbumRatings { get; set; }
        public virtual DbSet<TAlbums> TAlbums { get; set; }
        public virtual DbSet<TArtists> TArtists { get; set; }
        public virtual DbSet<TCategory> TCategory { get; set; }
        public virtual DbSet<TGenres> TGenres { get; set; }
        public virtual DbSet<TSongRatings> TSongRatings { get; set; }
        public virtual DbSet<TSongs> TSongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("Server =DESKTOP-4IVT239; Database=MusicDB; Trusted_Connection=True; MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer(ConstantsViewModel.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAlbumRatings>(entity =>
            {
                entity.ToTable("tAlbumRatings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.TAlbumRatings)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumRatings_Albums");
            });

            modelBuilder.Entity<TAlbums>(entity =>
            {
                entity.ToTable("tAlbums");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Review).IsRequired();

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.TAlbums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Albums_Artists");
            });

            modelBuilder.Entity<TArtists>(entity =>
            {
                entity.ToTable("tArtists");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.TArtists)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artists_Genres");
            });

            modelBuilder.Entity<TCategory>(entity =>
            {
                entity.ToTable("tCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TGenres>(entity =>
            {
                entity.ToTable("tGenres");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TGenres)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genres_Category");
            });

            modelBuilder.Entity<TSongRatings>(entity =>
            {
                entity.ToTable("tSongRatings");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.TSongRatings)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SongRatings_Songs");
            });

            modelBuilder.Entity<TSongs>(entity =>
            {
                entity.ToTable("tSongs");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.TSongs)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Albums");
            });
        }
    }
}
