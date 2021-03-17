using JongSnamFootball.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class RepositoryDbContext : DbContext
    {
        private const string Schema = "jsnfb";

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {

        }

        public virtual DbSet<UserModel> Users { get; set; }

        public virtual DbSet<StoreModel> Stores { get; set; }

        public virtual DbSet<FieldModel> Fields { get; set; }

        public virtual DbSet<ReservationModel> Reservations { get; set; }

        public virtual DbSet<ImageFieldModel> ImagesField { get; set; }

        public virtual DbSet<PaymentModel> Payments { get; set; }

        public virtual DbSet<DiscountModel> Discounts { get; set; }

        public virtual DbSet<ReviewModel> Reviews { get; set; }

        public virtual DbSet<SubDistrictModel> SubDistricts { get; set; }


        public virtual DbSet<DistrictModel> Districts { get; set; }


        public virtual DbSet<ProvinceModel> Provinces { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable(nameof(Users), Schema);
            });

            modelBuilder.Entity<StoreModel>(entity =>
            {
                entity.ToTable(nameof(Stores), Schema);
            });

            modelBuilder.Entity<FieldModel>(entity =>
            {
                entity.HasOne(s => s.StoreModel).WithOne().HasForeignKey<FieldModel>(x => x.StoreId);
                entity.HasMany(s => s.ImageFieldModel).WithOne().HasForeignKey(s => s.FieldId);
                entity.HasOne(s => s.DiscountModel).WithOne().HasForeignKey<DiscountModel>(s => s.FieldId);
                entity.ToTable(nameof(Fields), Schema);
            });

            modelBuilder.Entity<ReservationModel>(entity =>
            {
                entity.HasOne(s => s.UserModel).WithOne().HasForeignKey<ReservationModel>(x => x.UserId);
                entity.HasOne(s => s.StoreModel).WithOne().HasForeignKey<ReservationModel>(x => x.StoreId);
                entity.HasOne(s => s.FieldModel).WithOne().HasForeignKey<ReservationModel>(x => x.FieldId);
                entity.HasMany(s => s.PaymentModel).WithOne().HasForeignKey(s => s.ReservationId);
                entity.ToTable(nameof(Reservations), Schema);
            });

            modelBuilder.Entity<ImageFieldModel>(entity =>
            {
                entity.ToTable(nameof(ImagesField), Schema);
            });

            modelBuilder.Entity<PaymentModel>(entity =>
            {
                entity.ToTable(nameof(Payments), Schema);
            });

            modelBuilder.Entity<DiscountModel>(entity =>
            {
                entity.ToTable(nameof(Discounts), Schema);
            });

            modelBuilder.Entity<ReviewModel>(entity =>
            {
                entity.HasOne(s => s.UserModel).WithOne().HasForeignKey<ReviewModel>(s => s.UserId);

                entity.HasOne(s => s.StoreModel).WithOne().HasForeignKey<ReviewModel>(s => s.StoreId);

                entity.ToTable(nameof(Reviews), Schema);
            });

            modelBuilder.Entity<SubDistrictModel>(entity =>
            {
                entity.HasOne(s => s.DistrictModel).WithOne().HasForeignKey<SubDistrictModel>(s => s.DistrictId);

                entity.ToTable(nameof(SubDistricts), Schema);
            });

            modelBuilder.Entity<DistrictModel>(entity =>
            {
                entity.HasOne(s => s.ProvinceModel).WithOne().HasForeignKey<DistrictModel>(s => s.ProvinceId);

                entity.ToTable(nameof(Districts), Schema);
            });

            modelBuilder.Entity<ProvinceModel>(entity =>
            {
                entity.ToTable(nameof(Provinces), Schema);
            });

        }

    }
}
