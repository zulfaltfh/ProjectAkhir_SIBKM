﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Barang", b =>
                {
                    b.Property<string>("KodeBarang")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("kd_barang");

                    b.Property<string>("JenisBarang")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("jenis_barang");

                    b.Property<string>("NamaBarang")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nama_barang");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stok_barang");

                    b.HasKey("KodeBarang");

                    b.ToTable("tb_m_barang");
                });

            modelBuilder.Entity("API.Models.BarangKeluar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_barang_keluar");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Pembeli")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nama_pembeli");

                    b.Property<DateTime>("TanggalKeluar")
                        .HasColumnType("datetime")
                        .HasColumnName("tanggal_keluar");

                    b.HasKey("Id");

                    b.ToTable("tb_tr_barang_keluar");
                });

            modelBuilder.Entity("API.Models.BarangMasuk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_barang_masuk");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdSuppllier")
                        .HasColumnType("int")
                        .HasColumnName("id_supplier");

                    b.Property<DateTime>("TanggalMasuk")
                        .HasColumnType("datetime")
                        .HasColumnName("tanggal_masuk");

                    b.HasKey("Id");

                    b.HasIndex("IdSuppllier");

                    b.ToTable("tb_tr_barang_masuk");
                });

            modelBuilder.Entity("API.Models.DetailBarMasuk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detail_masuk");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdMasuk")
                        .HasColumnType("int")
                        .HasColumnName("id_masuk");

                    b.Property<int>("JumlahMasuk")
                        .HasColumnType("int")
                        .HasColumnName("jumlah");

                    b.Property<string>("KodeBarang")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("kd_barang");

                    b.HasKey("Id");

                    b.HasIndex("IdMasuk");

                    b.HasIndex("KodeBarang");

                    b.ToTable("tb_tr_detail_barang_masuk");
                });

            modelBuilder.Entity("API.Models.DetailBarkeluar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detail_keluar");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdKeluar")
                        .HasColumnType("int")
                        .HasColumnName("id_keluar");

                    b.Property<int>("JumlahKeluar")
                        .HasColumnType("int")
                        .HasColumnName("jumlah");

                    b.Property<string>("KodeBarang")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("kd_barang");

                    b.HasKey("Id");

                    b.HasIndex("IdKeluar");

                    b.HasIndex("KodeBarang");

                    b.ToTable("tb_tr_detail_barang_keluar");
                });

            modelBuilder.Entity("API.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("API.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_supplier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nama_supplier");

                    b.Property<string>("NoTelp")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasColumnName("no_telp");

                    b.HasKey("Id");

                    b.ToTable("tb_m_supplier");
                });

            modelBuilder.Entity("API.Models.Users", b =>
                {
                    b.Property<string>("UserNIP")
                        .HasColumnType("char(8)")
                        .HasColumnName("nip");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("no_telepon");

                    b.Property<int>("UserRoles")
                        .HasColumnType("int")
                        .HasColumnName("roles");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("UserNIP");

                    b.HasIndex("UserRoles");

                    b.ToTable("tb_m_users");
                });

            modelBuilder.Entity("API.Models.BarangMasuk", b =>
                {
                    b.HasOne("API.Models.Supplier", "Supplier")
                        .WithMany("BarangMasuk")
                        .HasForeignKey("IdSuppllier")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("API.Models.DetailBarMasuk", b =>
                {
                    b.HasOne("API.Models.BarangMasuk", "BarangMasuk")
                        .WithMany("DetailBarMasuk")
                        .HasForeignKey("IdMasuk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Barang", "Barang")
                        .WithMany("DetailBarMasuk")
                        .HasForeignKey("KodeBarang")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("BarangMasuk");
                });

            modelBuilder.Entity("API.Models.DetailBarkeluar", b =>
                {
                    b.HasOne("API.Models.BarangKeluar", "BarangKeluar")
                        .WithMany("DetailBarkeluar")
                        .HasForeignKey("IdKeluar")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Barang", "Barang")
                        .WithMany("DetailBarkeluar")
                        .HasForeignKey("KodeBarang")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("BarangKeluar");
                });

            modelBuilder.Entity("API.Models.Users", b =>
                {
                    b.HasOne("API.Models.Roles", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("UserRoles")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("API.Models.Barang", b =>
                {
                    b.Navigation("DetailBarMasuk");

                    b.Navigation("DetailBarkeluar");
                });

            modelBuilder.Entity("API.Models.BarangKeluar", b =>
                {
                    b.Navigation("DetailBarkeluar");
                });

            modelBuilder.Entity("API.Models.BarangMasuk", b =>
                {
                    b.Navigation("DetailBarMasuk");
                });

            modelBuilder.Entity("API.Models.Roles", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("API.Models.Supplier", b =>
                {
                    b.Navigation("BarangMasuk");
                });
#pragma warning restore 612, 618
        }
    }
}
