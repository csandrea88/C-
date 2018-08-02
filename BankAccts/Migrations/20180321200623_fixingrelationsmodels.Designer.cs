﻿// <auto-generated />
using BankAccts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BankAccts.Migrations
{
    [DbContext(typeof(BankAcctsContext))]
    [Migration("20180321200623_fixingrelationsmodels")]
    partial class fixingrelationsmodels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("BankAccts.Models.BAcc", b =>
                {
                    b.Property<int>("BAccId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Created_At");

                    b.Property<DateTime>("Updated_At");

                    b.Property<int>("UserId");

                    b.HasKey("BAccId");

                    b.HasIndex("UserId");

                    b.ToTable("BAccs");
                });

            modelBuilder.Entity("BankAccts.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Balance");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FName");

                    b.Property<string>("LName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankAccts.Models.BAcc", b =>
                {
                    b.HasOne("BankAccts.Models.User", "User")
                        .WithMany("Trans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
