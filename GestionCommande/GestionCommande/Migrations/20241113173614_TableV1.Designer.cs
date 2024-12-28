﻿// <auto-generated />
using System;
using GestionCommande.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionCommande.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241113173614_TableV1")]
    partial class TableV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GestionCommande.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surnom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("GestionCommande.Models.Commandes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<float>("Montant")
                        .HasColumnType("float");

                    b.Property<float>("MontantVerser")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("GestionCommande.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GestionCommande.Models.Client", b =>
                {
                    b.HasOne("GestionCommande.Models.User", "User")
                        .WithOne("Client")
                        .HasForeignKey("Cours.Models.Client", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("GestionCommande.Models.Dette", b =>
                {
                    b.HasOne("Cours.Models.Client", "Client")
                        .WithMany("Dettes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("GestionCommande.Models.Client", b =>
                {
                    b.Navigation("Commandes");
                });

            modelBuilder.Entity("GestionCommande.Models.User", b =>
                {
                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
