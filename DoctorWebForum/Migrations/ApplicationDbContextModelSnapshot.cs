﻿// <auto-generated />
using System;
using DoctorWebForum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorWebForum.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoctorWebForum.Data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("DoctorWebForum.Data.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Messages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages", (string)null);
                });

            modelBuilder.Entity("DoctorWebForum.Data.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<string>("NotificationContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications", (string)null);
                });

            modelBuilder.Entity("DoctorWebForum.Data.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isHidden")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("DoctorWebForum.Data.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Doctor"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("DoctorWebForum.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("avatarPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 8, 25, 6, 32, 55, 795, DateTimeKind.Local).AddTicks(5802),
                            Email = "admin@gmail.com",
                            FirstName = "Toan",
                            HashedPassword = "$2a$11$GNcsJ9YkeLXpmw4VKxCQm.sf.LCclBCIg48PLADkKSv4rA9RVS5Ze",
                            LastName = "Le Nguyen",
                            RoleId = 1,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("DoctorWebForum.Data.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Intro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LiveAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudyAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WorkAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetails", (string)null);
                });

            modelBuilder.Entity("DoctorWebForum.Data.Comment", b =>
                {
                    b.HasOne("DoctorWebForum.Data.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.HasOne("DoctorWebForum.Data.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorWebForum.Data.Message", b =>
                {
                    b.HasOne("DoctorWebForum.Data.User", "User")
                        .WithMany("messages")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorWebForum.Data.Notification", b =>
                {
                    b.HasOne("DoctorWebForum.Data.User", "FromUser")
                        .WithMany("Notifications")
                        .HasForeignKey("FromUserId")
                        .IsRequired();

                    b.HasOne("DoctorWebForum.Data.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWebForum.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorWebForum.Data.Post", b =>
                {
                    b.HasOne("DoctorWebForum.Data.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorWebForum.Data.User", b =>
                {
                    b.HasOne("DoctorWebForum.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DoctorWebForum.Data.UserDetail", b =>
                {
                    b.HasOne("DoctorWebForum.Data.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("DoctorWebForum.Data.UserDetail", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorWebForum.Data.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("DoctorWebForum.Data.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Notifications");

                    b.Navigation("Posts");

                    b.Navigation("UserDetails")
                        .IsRequired();

                    b.Navigation("messages");
                });
#pragma warning restore 612, 618
        }
    }
}
