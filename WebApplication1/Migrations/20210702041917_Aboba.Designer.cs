﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(RedBookContext))]
    [Migration("20210702041917_Aboba")]
    partial class Aboba
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Descc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WebApplication1.Models.ClassA", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClassID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KingdomId")
                        .HasColumnName("KingdomID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ClassId");

                    b.HasIndex("KingdomId");

                    b.ToTable("ClassA");
                });

            modelBuilder.Entity("WebApplication1.Models.Kingdoms", b =>
                {
                    b.Property<int>("KingdomId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("KingdomId");

                    b.ToTable("Kingdoms");
                });

            modelBuilder.Entity("WebApplication1.Models.SubClass", b =>
                {
                    b.Property<int>("SubClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("subClassID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassId")
                        .HasColumnName("ClassID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("SubClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("SubClass");
                });

            modelBuilder.Entity("WebApplication1.Models.Thiss", b =>
                {
                    b.Property<int>("ThisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ThisID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Descc")
                        .HasColumnName("descc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnName("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("SubClassId")
                        .HasColumnName("SubClassID")
                        .HasColumnType("int");

                    b.HasKey("ThisId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubClassId");

                    b.ToTable("Thiss");
                });

            modelBuilder.Entity("WebApplication1.Models.ClassA", b =>
                {
                    b.HasOne("WebApplication1.Models.Kingdoms", "Kingdom")
                        .WithMany("ClassA")
                        .HasForeignKey("KingdomId")
                        .HasConstraintName("FK_ClassA_Kingdoms")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.SubClass", b =>
                {
                    b.HasOne("WebApplication1.Models.ClassA", "Class")
                        .WithMany("SubClass")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_SubClass_ClassA");
                });

            modelBuilder.Entity("WebApplication1.Models.Thiss", b =>
                {
                    b.HasOne("WebApplication1.Models.Category", "Category")
                        .WithMany("Thiss")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Thiss_Category");

                    b.HasOne("WebApplication1.Models.SubClass", "SubClass")
                        .WithMany("Thiss")
                        .HasForeignKey("SubClassId")
                        .HasConstraintName("FK_Thiss_SubClass");
                });
#pragma warning restore 612, 618
        }
    }
}
