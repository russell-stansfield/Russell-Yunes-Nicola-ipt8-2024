﻿// <auto-generated />
using DeerDiary_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeerDiary_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241024125750_CompleteDB")]
    partial class CompleteDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DeerDiary_Backend.Models.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("JournalId");

                    b.Property<string>("_date")
                        .HasColumnType("longtext")
                        .HasColumnName("JournalDate");

                    b.Property<string>("_text")
                        .HasColumnType("longtext")
                        .HasColumnName("JournalText");

                    b.Property<string>("_title")
                        .HasColumnType("longtext")
                        .HasColumnName("JournalTitle");

                    b.HasKey("Id");

                    b.ToTable("JournalEntries");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.RandomQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RandomQuestionId");

                    b.Property<string>("_text")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("RandomQuestionText");

                    b.HasKey("Id");

                    b.ToTable("RandomQuestions");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReplyId");

                    b.Property<string>("_generatedquestion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ReplyGeneratedQuestion");

                    b.Property<string>("_text")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ReplyText");

                    b.HasKey("Id");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("_usermail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("JournalId");

                    b.Property<string>("_username")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("UserName");

                    b.Property<string>("_userpassword")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("UserPassword");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
