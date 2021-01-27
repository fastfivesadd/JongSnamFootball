using JongSnamFootball.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class RepoDbContext : DbContext
    {
        private const string Schema = "jsnfb";

        public RepoDbContext(DbContextOptions<RepoDbContext> options) : base(options)
        {

        }

        public virtual DbSet<UserMemberModel> Usermember { get; set; }

        public virtual DbSet<StoreModel> Store { get; set; }

        public virtual DbSet<FieldModel> Field { get; set; }

        public virtual DbSet<ReservationModel> Reservation { get; set; }

        public virtual DbSet<PictureFieldModel> Picturefield { get; set; }

        public virtual DbSet<PaymentModel> Payment { get; set; }

        public virtual DbSet<DiscountModel> Discount { get; set; }

        public virtual DbSet<CommentModel> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMemberModel>(entity =>
            {
                entity.ToTable(nameof(Usermember), Schema);
            });

            modelBuilder.Entity<StoreModel>(entity =>
            {
                entity.HasMany(s => s.CommentModel).WithOne().HasForeignKey(x => x.StoreId);
                entity.ToTable(nameof(Store), Schema);
            });

            modelBuilder.Entity<FieldModel>(entity =>
            {
                entity.ToTable(nameof(Field), Schema);
            });

            modelBuilder.Entity<ReservationModel>(entity =>
            {
                entity.ToTable(nameof(Reservation), Schema);
            });

            modelBuilder.Entity<PictureFieldModel>(entity =>
            {
                entity.ToTable(nameof(Picturefield), Schema);
            });

            modelBuilder.Entity<PaymentModel>(entity =>
            {
                entity.ToTable(nameof(Payment), Schema);
            });

            modelBuilder.Entity<DiscountModel>(entity =>
            {
                entity.ToTable(nameof(Discount), Schema);
            });

            modelBuilder.Entity<CommentModel>(entity =>
            {
                entity.HasOne(s => s.UserModel).WithOne().HasForeignKey<CommentModel>(s => s.MemberId);

                entity.HasOne(s => s.StoreModel).WithOne().HasForeignKey<CommentModel>(s => s.StoreId);

                entity.ToTable(nameof(Comment), Schema);
            });
        }

    }
}
