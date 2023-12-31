﻿// <auto-generated />
using System;
using LMS_System.LMSSystym.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMS_System.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230703134601_fixthis")]
    partial class fixthis
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LMS_System.LMSSystem.Model.Models.Anwser", b =>
                {
                    b.Property<int>("AnwserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnwserId"));

                    b.Property<string>("AnwserDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnwserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("AnwserId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Anwsers");
                });

            modelBuilder.Entity("LMS_System.LMSSystem.Model.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("DescriptionClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("LMS_System.LMSSystem.Model.Models.User_Class", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("User_Classes");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Avarta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("NotificationId");

                    b.HasIndex("RolesId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Courses", b =>
                {
                    b.Property<int>("CoursesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoursesId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoursesDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoursesName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoursesId");

                    b.HasIndex("AccountId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("DocumentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Exam", b =>
                {
                    b.Property<int>("EmxamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmxamId"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("EmxamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("EmxamId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetailsAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.PersionalDocument", b =>
                {
                    b.Property<int>("PerDocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PerDocId"));

                    b.Property<DateTime?>("PerDocCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PerDocLastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PerDocName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PerDocId");

                    b.ToTable("PersionalDocuments");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("QuesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuesTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.HasIndex("ExamId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Roles", b =>
                {
                    b.Property<int>("RolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolesId"));

                    b.Property<string>("Descrepsion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolesId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RefreshTokenExpries")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResetTokenExpries")
                        .HasColumnType("datetime2");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<string>("Specialized")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifyAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("RolesId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LMS_System.LMSSystem.Model.Models.Anwser", b =>
                {
                    b.HasOne("LMS_System.LMSSystym.Models.Models.Question", "Question")
                        .WithMany("Anwsers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("LMS_System.LMSSystem.Model.Models.User_Class", b =>
                {
                    b.HasOne("LMS_System.LMSSystem.Model.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS_System.LMSSystym.Models.Models.User", "User")
                        .WithMany("User_Class")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Account", b =>
                {
                    b.HasOne("LMS_System.LMSSystym.Models.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS_System.LMSSystym.Models.Models.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS_System.LMSSystym.Models.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMS_System.LMSSystym.Models.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Notification");

                    b.Navigation("Roles");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Courses", b =>
                {
                    b.HasOne("LMS_System.LMSSystym.Models.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Exam", b =>
                {
                    b.HasOne("LMS_System.LMSSystym.Models.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Question", b =>
                {
                    b.HasOne("LMS_System.LMSSystym.Models.Models.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.User", b =>
                {
                    b.HasOne("LMS_System.LMSSystym.Models.Models.Roles", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Exam", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Question", b =>
                {
                    b.Navigation("Anwsers");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.Roles", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LMS_System.LMSSystym.Models.Models.User", b =>
                {
                    b.Navigation("User_Class");
                });
#pragma warning restore 612, 618
        }
    }
}
