﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zadania.Data;

#nullable disable

namespace Zadania.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230622134303_secoundMigrationCD")]
    partial class secoundMigrationCD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("Zadania.Models.AccountNumbers", b =>
                {
                    b.Property<int>("AccountNumbersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numbers")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountNumbersId");

                    b.HasIndex("SubjectId");

                    b.ToTable("AccountNumbers");
                });

            modelBuilder.Entity("Zadania.Models.EntityPersonProkurent", b =>
                {
                    b.Property<int>("EntityPersonProkurentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("pesel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EntityPersonProkurentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("EntityPersonProkurents");
                });

            modelBuilder.Entity("Zadania.Models.EntityPersonWspolnik", b =>
                {
                    b.Property<int>("EntityPersonWspolnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("pesel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EntityPersonWspolnikId");

                    b.HasIndex("SubjectId");

                    b.ToTable("EntityPersonWspolniks");
                });

            modelBuilder.Entity("Zadania.Models.Representative", b =>
                {
                    b.Property<int>("RepresentativeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RepresentativeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Representatives");
                });

            modelBuilder.Entity("Zadania.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("requestDateTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("requestId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ResultId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Zadania.Models.Root", b =>
                {
                    b.Property<int>("RootId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResultId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RootId");

                    b.HasIndex("ResultId");

                    b.ToTable("Roots");
                });

            modelBuilder.Entity("Zadania.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("hasVirtualAccounts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("krs")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("pesel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("registrationDenialBasis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("registrationDenialDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("registrationLegalDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("regon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("removalBasis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("removalDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("residenceAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("restorationBasis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("restorationDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("statusVat")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("workingAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Zadania.Models.AccountNumbers", b =>
                {
                    b.HasOne("Zadania.Models.Subject", null)
                        .WithMany("accountNumbers")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Zadania.Models.EntityPersonProkurent", b =>
                {
                    b.HasOne("Zadania.Models.Subject", null)
                        .WithMany("authorizedClerks")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Zadania.Models.EntityPersonWspolnik", b =>
                {
                    b.HasOne("Zadania.Models.Subject", null)
                        .WithMany("partners")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Zadania.Models.Representative", b =>
                {
                    b.HasOne("Zadania.Models.Subject", null)
                        .WithMany("representatives")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("Zadania.Models.Result", b =>
                {
                    b.HasOne("Zadania.Models.Subject", "subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subject");
                });

            modelBuilder.Entity("Zadania.Models.Root", b =>
                {
                    b.HasOne("Zadania.Models.Result", "result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("result");
                });

            modelBuilder.Entity("Zadania.Models.Subject", b =>
                {
                    b.Navigation("accountNumbers");

                    b.Navigation("authorizedClerks");

                    b.Navigation("partners");

                    b.Navigation("representatives");
                });
#pragma warning restore 612, 618
        }
    }
}
