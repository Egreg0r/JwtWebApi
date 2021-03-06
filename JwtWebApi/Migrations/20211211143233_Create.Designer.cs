// <auto-generated />
using System;
using JwtWebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JwtWebApi.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20211211143233_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("JwtWebApi.Model.LoginModel", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserName");

                    b.ToTable("loginModels");

                    b.HasData(
                        new
                        {
                            UserName = "FirstUser",
                            Password = "PasswordFistUser"
                        },
                        new
                        {
                            UserName = "SecondUser",
                            Password = "PasswordSecond"
                        });
                });

            modelBuilder.Entity("JwtWebApi.Model.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LoginModelUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LoginModelUserName");

                    b.ToTable("tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2021, 12, 12, 0, 32, 33, 237, DateTimeKind.Local).AddTicks(4592),
                            LoginModelUserName = "FirstUser",
                            Message = "some text №1 from fist User"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2021, 12, 12, 0, 32, 33, 239, DateTimeKind.Local).AddTicks(1017),
                            LoginModelUserName = "FirstUser",
                            Message = "some text №2 from fist User"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2021, 12, 12, 0, 32, 33, 239, DateTimeKind.Local).AddTicks(1577),
                            LoginModelUserName = "FirstUser",
                            Message = "some text №3 from fist User"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2021, 12, 12, 0, 32, 33, 239, DateTimeKind.Local).AddTicks(2106),
                            LoginModelUserName = "FirstUser",
                            Message = "some text №4 from fist User"
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2021, 12, 12, 0, 32, 33, 239, DateTimeKind.Local).AddTicks(2625),
                            LoginModelUserName = "SecondUser",
                            Message = "some text №1 from second User"
                        });
                });

            modelBuilder.Entity("JwtWebApi.Model.Ticket", b =>
                {
                    b.HasOne("JwtWebApi.Model.LoginModel", "LoginModel")
                        .WithMany()
                        .HasForeignKey("LoginModelUserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoginModel");
                });
#pragma warning restore 612, 618
        }
    }
}
