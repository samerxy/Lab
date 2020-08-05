﻿// <auto-generated />
using System;
using Labs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Labs.Migrations
{
    [DbContext(typeof(LabsContext))]
    [Migration("20200601104631_init005")]
    partial class init005
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Labs.infrastructure.Dates", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("LabID")
                        .HasColumnType("integer");

                    b.Property<bool>("isBooked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("ID");

                    b.HasIndex("LabID");

                    b.ToTable("dates");
                });

            modelBuilder.Entity("Labs.infrastructure.Email", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("pass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("path")
                        .HasColumnType("text");

                    b.Property<string>("supj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("emails");
                });

            modelBuilder.Entity("Labs.infrastructure.LDT", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDone")
                        .HasColumnType("boolean");

                    b.Property<int>("LabID")
                        .HasColumnType("integer");

                    b.Property<int>("TimeID")
                        .HasColumnType("integer");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("LabID");

                    b.HasIndex("TimeID");

                    b.ToTable("Ldts");
                });

            modelBuilder.Entity("Labs.infrastructure.LT", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("LabID")
                        .HasColumnType("integer");

                    b.Property<int>("TestID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("LabID");

                    b.HasIndex("TestID");

                    b.ToTable("lt");
                });

            modelBuilder.Entity("Labs.infrastructure.Lab", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LabName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("ID");

                    b.ToTable("Labs");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            LabName = "Pure",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("Labs.infrastructure.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("RoleType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            RoleType = "ADMIN"
                        },
                        new
                        {
                            ID = 2,
                            RoleType = "USER"
                        });
                });

            modelBuilder.Entity("Labs.infrastructure.Test", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("LabID")
                        .HasColumnType("integer");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("LabID");

                    b.ToTable("tests");
                });

            modelBuilder.Entity("Labs.infrastructure.Time", b =>
                {
                    b.Property<int>("TimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DateID")
                        .HasColumnType("integer");

                    b.Property<int?>("datesID")
                        .HasColumnType("integer");

                    b.Property<bool>("isAvailable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TimeID");

                    b.HasIndex("datesID");

                    b.ToTable("times");

                    b.HasData(
                        new
                        {
                            TimeID = 1,
                            DateID = 1,
                            isAvailable = false,
                            time = "10:00am"
                        },
                        new
                        {
                            TimeID = 2,
                            DateID = 1,
                            isAvailable = false,
                            time = "11:00am"
                        },
                        new
                        {
                            TimeID = 3,
                            DateID = 1,
                            isAvailable = false,
                            time = "12:00pm"
                        },
                        new
                        {
                            TimeID = 4,
                            DateID = 1,
                            isAvailable = false,
                            time = "01:00pm"
                        },
                        new
                        {
                            TimeID = 5,
                            DateID = 1,
                            isAvailable = false,
                            time = "02:00pm"
                        },
                        new
                        {
                            TimeID = 6,
                            DateID = 1,
                            isAvailable = false,
                            time = "03:00pm"
                        },
                        new
                        {
                            TimeID = 7,
                            DateID = 1,
                            isAvailable = false,
                            time = "04:00pm"
                        },
                        new
                        {
                            TimeID = 8,
                            DateID = 1,
                            isAvailable = false,
                            time = "05:00pm"
                        },
                        new
                        {
                            TimeID = 9,
                            DateID = 1,
                            isAvailable = false,
                            time = "06:00pm"
                        },
                        new
                        {
                            TimeID = 10,
                            DateID = 1,
                            isAvailable = false,
                            time = "07:00pm"
                        },
                        new
                        {
                            TimeID = 11,
                            DateID = 1,
                            isAvailable = false,
                            time = "08:00pm"
                        },
                        new
                        {
                            TimeID = 12,
                            DateID = 1,
                            isAvailable = false,
                            time = "09:00pm"
                        });
                });

            modelBuilder.Entity("Labs.infrastructure.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("LabID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(null);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleID")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.HasKey("ID");

                    b.HasIndex("LabID");

                    b.HasIndex("RoleID");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "testxy.mailxy@gmail.com",
                            Name = "Samer Saad",
                            Password = "Admin123",
                            Phone = "07712365899",
                            RoleID = 1,
                            UserName = "Admin",
                            isDeleted = false
                        },
                        new
                        {
                            ID = 2,
                            Email = "testxy.mailxy@gmail.com",
                            Name = "Mohammed Ali",
                            Password = "User123",
                            Phone = "07712365899",
                            RoleID = 2,
                            UserName = "User",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("Labs.infrastructure.Dates", b =>
                {
                    b.HasOne("Labs.infrastructure.Lab", "lab")
                        .WithMany()
                        .HasForeignKey("LabID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labs.infrastructure.LDT", b =>
                {
                    b.HasOne("Labs.infrastructure.Lab", "lab")
                        .WithMany()
                        .HasForeignKey("LabID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labs.infrastructure.Time", "Time")
                        .WithMany("lDTs")
                        .HasForeignKey("TimeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Labs.infrastructure.LT", b =>
                {
                    b.HasOne("Labs.infrastructure.Lab", "lab")
                        .WithMany("Lt")
                        .HasForeignKey("LabID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labs.infrastructure.Test", "test")
                        .WithMany()
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labs.infrastructure.Test", b =>
                {
                    b.HasOne("Labs.infrastructure.Lab", "lab")
                        .WithMany()
                        .HasForeignKey("LabID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labs.infrastructure.Time", b =>
                {
                    b.HasOne("Labs.infrastructure.Dates", "dates")
                        .WithMany()
                        .HasForeignKey("datesID");
                });

            modelBuilder.Entity("Labs.infrastructure.User", b =>
                {
                    b.HasOne("Labs.infrastructure.Lab", "lab")
                        .WithMany("Users")
                        .HasForeignKey("LabID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Labs.infrastructure.Role", "role")
                        .WithMany("users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
