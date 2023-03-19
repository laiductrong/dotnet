﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230318181641_3dbSvMhDt")]
    partial class _3dbSvMhDt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("WebAPI.Models.DiemThi", b =>
                {
                    b.Property<float>("diem")
                        .HasColumnType("real");

                    b.Property<int>("lanThi")
                        .HasColumnType("int");

                    b.Property<int>("monHocIdId")
                        .HasColumnType("int");

                    b.Property<int>("sinhVienIdId")
                        .HasColumnType("int");

                    b.HasIndex("monHocIdId");

                    b.HasIndex("sinhVienIdId");

                    b.ToTable("DiemThis");
                });

            modelBuilder.Entity("WebAPI.Models.GiangVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("chuyenNganh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("khoaId")
                        .HasColumnType("int");

                    b.Property<string>("tenGV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("khoaId");

                    b.ToTable("GiangViens");
                });

            modelBuilder.Entity("WebAPI.Models.Khoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("tenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Khoas");
                });

            modelBuilder.Entity("WebAPI.Models.Lop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("khoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("khoaId");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("WebAPI.Models.MonHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("soTiet")
                        .HasColumnType("int");

                    b.Property<string>("tenMH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MonHocs");
                });

            modelBuilder.Entity("WebAPI.Models.SinhVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("gioiTinh")
                        .HasColumnType("bit");

                    b.Property<int>("lopId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ngaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("tenSV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("lopId");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("WebAPI.Models.DiemThi", b =>
                {
                    b.HasOne("WebAPI.Models.MonHoc", "monHocId")
                        .WithMany()
                        .HasForeignKey("monHocIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.SinhVien", "sinhVienId")
                        .WithMany()
                        .HasForeignKey("sinhVienIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("monHocId");

                    b.Navigation("sinhVienId");
                });

            modelBuilder.Entity("WebAPI.Models.GiangVien", b =>
                {
                    b.HasOne("WebAPI.Models.Khoa", "khoa")
                        .WithMany()
                        .HasForeignKey("khoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("khoa");
                });

            modelBuilder.Entity("WebAPI.Models.Lop", b =>
                {
                    b.HasOne("WebAPI.Models.Khoa", "khoa")
                        .WithMany()
                        .HasForeignKey("khoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("khoa");
                });

            modelBuilder.Entity("WebAPI.Models.SinhVien", b =>
                {
                    b.HasOne("WebAPI.Models.Lop", "lop")
                        .WithMany()
                        .HasForeignKey("lopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lop");
                });
#pragma warning restore 612, 618
        }
    }
}
