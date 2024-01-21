using Microsoft.EntityFrameworkCore;

namespace WebApiNet5._0.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options):base(options) { }

        #region DbSet
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<HangHoa> HangHoas { get; set;}
        public DbSet<Loai> Loais { get; set;}
        public DbSet<DonHang> DonHangs { get; set;}
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set;}
        #endregion

        //Fluent API in Entity Framework Core
        //Truy cap trang: https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Don hang
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.ToTable("DonHang"); //Ten table
                entity.HasKey(dh => dh.MaDh); //Khoa chinh
                //Tao rang buoc
                entity.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()"); 
                entity.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });
            //Chi tiet don hang
            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.ToTable("ChiTietDonHang"); //Ten table
                entity.HasKey(e => new { e.MaDh, e.MaHH }); //Khoa chinh

                entity.HasOne(e => e.DonHang) //e.DonHang trong ChiTietDonHang
                    .WithMany(e => e.ChiTietDonHangs) //e.ChiTietDonHangs trong DonHang
                    .HasForeignKey(e => e.MaDh)
                    .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa) //e.HangHoa trong ChiTietDonHang
                    .WithMany(e => e.ChiTietDonHangs) //e.ChiTietDonHangs trong HangHoa
                    .HasForeignKey(e => e.MaDh)
                    .HasConstraintName("FK_DonHangCT_HangHoa");
            });
            //Users
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("NguoiDung");
                entity.HasKey(nd => nd.Id);
                entity.Property(nd => nd.Username).IsRequired().HasMaxLength(50);
                //IsUnique(): gia tri cua truong do phai la duy nhat trong tat ca cac ban ghi trong bang
                entity.HasIndex(nd => nd.Username).IsUnique();
                entity.Property(nd => nd.Password).IsRequired().HasMaxLength(250);
                entity.Property(nd => nd.Hoten).IsRequired().HasMaxLength(150);
                entity.Property(nd => nd.Email).IsRequired().HasMaxLength(150);
            });
        }
    }
}
