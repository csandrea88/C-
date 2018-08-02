﻿// <auto-generated />
using Belt3CSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Belt3CSharp.Migrations
{
    [DbContext(typeof(Belt3CSharpContext))]
    [Migration("20180402152235_Belt3MtoMBid")]
    partial class Belt3MtoMBid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Belt3CSharp.Models.Belt3", b =>
                {
                    b.Property<int>("Belt3Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Belt3date");

                    b.Property<int>("Belt3int1");

                    b.Property<int>("Belt3int2");

                    b.Property<string>("Belt3stg1");

                    b.Property<string>("Belt3stg2");

                    b.Property<string>("Belt3stg3");

                    b.Property<string>("Belt3stg4");

                    b.Property<string>("Belt3stg5");

                    b.Property<DateTime>("Created_At");

                    b.Property<DateTime>("Updated_At");

                    b.Property<int>("UserId");

                    b.HasKey("Belt3Id");

                    b.HasIndex("UserId");

                    b.ToTable("Belt3s");
                });

            modelBuilder.Entity("Belt3CSharp.Models.MtoM", b =>
                {
                    b.Property<int>("MtoMId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Belt3Id");

                    b.Property<int>("BidAmt");

                    b.Property<DateTime>("Created_At");

                    b.Property<DateTime>("Updated_At");

                    b.Property<int>("Userid");

                    b.HasKey("MtoMId");

                    b.HasIndex("Belt3Id");

                    b.HasIndex("Userid");

                    b.ToTable("MtoMs");
                });

            modelBuilder.Entity("Belt3CSharp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FName");

                    b.Property<string>("LName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Userint1");

                    b.Property<string>("Userstrg1");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Belt3CSharp.Models.Belt3", b =>
                {
                    b.HasOne("Belt3CSharp.Models.User", "User")
                        .WithMany("Belt3s")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Belt3CSharp.Models.MtoM", b =>
                {
                    b.HasOne("Belt3CSharp.Models.Belt3", "Belt3")
                        .WithMany("MtoMs")
                        .HasForeignKey("Belt3Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Belt3CSharp.Models.User", "User")
                        .WithMany("MtoMs")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
