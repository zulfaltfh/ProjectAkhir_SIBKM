﻿// <auto-generated />
using System;
using API_New.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_New.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230626073846_AddTableandRelation")]
    partial class AddTableandRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_New.Models.Barang", b =>
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

            modelBuilder.Entity("API_New.Models.BarangKeluar", b =>
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

            modelBuilder.Entity("API_New.Models.BarangMasuk", b =>
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

            modelBuilder.Entity("API_New.Models.DetailBarMasuk", b =>
                {
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

                    b.Property<string>("UserNIP")
                        .IsRequired()
                        .HasColumnType("char(8)")
                        .HasColumnName("nip_employee");

                    b.HasKey("IdMasuk");

                    b.HasIndex("KodeBarang");

                    b.HasIndex("UserNIP");

                    b.ToTable("tb_tr_detail_barang_masuk");
                });

            modelBuilder.Entity("API_New.Models.DetailBarkeluar", b =>
                {
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

                    b.Property<string>("UserNIP")
                        .IsRequired()
                        .HasColumnType("char(8)")
                        .HasColumnName("nip_employee");

                    b.HasKey("IdKeluar");

                    b.HasIndex("KodeBarang");

                    b.HasIndex("UserNIP");

                    b.ToTable("tb_tr_detail_barang_keluar");
                });

            modelBuilder.Entity("API_New.Models.Roles", b =>
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

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("API_New.Models.Supplier", b =>
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

            modelBuilder.Entity("API_New.Models.Users", b =>
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

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("UserNIP");

                    b.ToTable("tb_m_users");
                });

            modelBuilder.Entity("API_New.Models.UsersRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("UserNIP")
                        .IsRequired()
                        .HasColumnType("char(8)")
                        .HasColumnName("user_nip");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserNIP");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("API_New.Models.BarangMasuk", b =>
                {
                    b.HasOne("API_New.Models.Supplier", "Supplier")
                        .WithMany("BarangMasuk")
                        .HasForeignKey("IdSuppllier")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("API_New.Models.DetailBarMasuk", b =>
                {
                    b.HasOne("API_New.Models.BarangMasuk", "BarangMasuk")
                        .WithMany("DetailBarMasuk")
                        .HasForeignKey("IdMasuk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_New.Models.Barang", "Barang")
                        .WithMany("DetailBarMasuk")
                        .HasForeignKey("KodeBarang")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_New.Models.Users", "Users")
                        .WithMany("DetailBarMasuk")
                        .HasForeignKey("UserNIP")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("BarangMasuk");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("API_New.Models.DetailBarkeluar", b =>
                {
                    b.HasOne("API_New.Models.BarangKeluar", "BarangKeluar")
                        .WithMany("DetailBarkeluar")
                        .HasForeignKey("IdKeluar")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_New.Models.Barang", "Barang")
                        .WithMany("DetailBarkeluar")
                        .HasForeignKey("KodeBarang")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_New.Models.Users", "Users")
                        .WithMany("DetailBarkeluar")
                        .HasForeignKey("UserNIP")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("BarangKeluar");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("API_New.Models.UsersRole", b =>
                {
                    b.HasOne("API_New.Models.Roles", "Roles")
                        .WithMany("UsersRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_New.Models.Users", "Users")
                        .WithMany("UsersRole")
                        .HasForeignKey("UserNIP")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("API_New.Models.Barang", b =>
                {
                    b.Navigation("DetailBarMasuk");

                    b.Navigation("DetailBarkeluar");
                });

            modelBuilder.Entity("API_New.Models.BarangKeluar", b =>
                {
                    b.Navigation("DetailBarkeluar");
                });

            modelBuilder.Entity("API_New.Models.BarangMasuk", b =>
                {
                    b.Navigation("DetailBarMasuk");
                });

            modelBuilder.Entity("API_New.Models.Roles", b =>
                {
                    b.Navigation("UsersRole");
                });

            modelBuilder.Entity("API_New.Models.Supplier", b =>
                {
                    b.Navigation("BarangMasuk");
                });

            modelBuilder.Entity("API_New.Models.Users", b =>
                {
                    b.Navigation("DetailBarMasuk");

                    b.Navigation("DetailBarkeluar");

                    b.Navigation("UsersRole");
                });
#pragma warning restore 612, 618
        }
    }
}
