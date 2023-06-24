using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Barang> Barangs { get; set; }
        public DbSet<BarangMasuk> BarangMasuks { get; set; }
        public DbSet<BarangKeluar> BarangKeluars { get; set; }
        public DbSet<DetailBarkeluar> DetailBarkeluars { get; set; }
        public DbSet<DetailBarMasuk> DetailBarMasuks { get; set; }

        //Fluent API --Relation Configuration--
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //One Roles has many User
            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Roles)
                .HasForeignKey(u => u.UserRoles)
                .OnDelete(DeleteBehavior.Restrict);

            //One Supplier has many Barang Masuk
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.BarangMasuk)
                .WithOne(bm => bm.Supplier)
                .HasForeignKey(bm => bm.IdSuppllier)
                .OnDelete(DeleteBehavior.Restrict);

            //One Barang Masuk has many detail barang masuk
            modelBuilder.Entity<BarangMasuk>()
                .HasMany(bm => bm.DetailBarMasuk)
                .WithOne(dm => dm.BarangMasuk)
                .HasForeignKey(dm => dm.IdMasuk)
                .OnDelete(DeleteBehavior.Restrict);

            //One Barang has many detail barang masuk
            modelBuilder.Entity<Barang>()
                .HasMany(b => b.DetailBarMasuk)
                .WithOne(dm => dm.Barang)
                .HasForeignKey(dm => dm.KodeBarang)
                .OnDelete(DeleteBehavior.Restrict);

            //One Barang has many detail barang keluar
            modelBuilder.Entity<Barang>()
                .HasMany(b => b.DetailBarkeluar)
                .WithOne(dk => dk.Barang)
                .HasForeignKey(dk => dk.KodeBarang)
                .OnDelete(DeleteBehavior.Restrict);

            //One Barang Keluar has many detail barang keluar
            modelBuilder.Entity<BarangKeluar>()
                .HasMany(bk => bk.DetailBarkeluar)
                .WithOne(dk => dk.BarangKeluar)
                .HasForeignKey(dk => dk.IdKeluar)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
