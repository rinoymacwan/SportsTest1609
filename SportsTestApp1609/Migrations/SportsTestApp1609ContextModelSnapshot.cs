﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsTestApp1609.Models;

namespace SportsTestApp1609.Migrations
{
    [DbContext(typeof(SportsTestApp1609Context))]
    partial class SportsTestApp1609ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsTestApp1609.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("SportsTestApp1609.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SportsTestApp1609.Models.UserTestMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Distance");

                    b.Property<int>("TId");

                    b.Property<int>("Time");

                    b.Property<int>("UId");

                    b.HasKey("Id");

                    b.HasIndex("TId");

                    b.HasIndex("UId");

                    b.ToTable("UserTestMapping");
                });

            modelBuilder.Entity("SportsTestApp1609.Models.UserTestMapping", b =>
                {
                    b.HasOne("SportsTestApp1609.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsTestApp1609.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
