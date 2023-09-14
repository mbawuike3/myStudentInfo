﻿// <auto-generated />
using System;
using CrashCourseWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrashCourseWeb.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CrashCourseWeb.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2139393-8a35-4149-9224-2e6f9222d270"),
                            Email = "favourmbagwu@gmail.com",
                            FirstName = "Favour",
                            LastName = "Mbagwu",
                            Password = "niceGurl2001",
                            Tel = "09033226688",
                            Username = "mbah34"
                        },
                        new
                        {
                            Id = new Guid("b437d473-10bf-4d38-88e4-51fa0f7db8ae"),
                            Email = "klaus@gmail.com",
                            FirstName = "Okorie",
                            LastName = "Kelechi",
                            Password = "klaus44",
                            Tel = "09033233772",
                            Username = "modrid68"
                        },
                        new
                        {
                            Id = new Guid("e0c21146-6f67-45d2-948d-4664f1b06deb"),
                            Email = "chommy@gmail.com",
                            FirstName = "Chioma",
                            LastName = "Mbawuiwe",
                            Password = "chomzy44",
                            Tel = "09033260778",
                            Username = "Chiom68"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
