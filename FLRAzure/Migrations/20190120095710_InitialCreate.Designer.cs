﻿// <auto-generated />
using FLRAzure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FLRAzure.Migrations
{
    [DbContext(typeof(Ristorante))]
    [Migration("20190120095710_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("FLRAzure.Models.Lasagna", b =>
                {
                    b.Property<int>("LasagnaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MenuId");

                    b.Property<string>("Nome");

                    b.Property<string>("Peso");

                    b.Property<string>("UrlImmagine");

                    b.HasKey("LasagnaId");

                    b.HasIndex("MenuId");

                    b.ToTable("Lasagne");
                });

            modelBuilder.Entity("FLRAzure.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("UrlImmagine");

                    b.HasKey("MenuId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("FLRAzure.Models.Lasagna", b =>
                {
                    b.HasOne("FLRAzure.Models.Menu", "Menu")
                        .WithMany("Lasagne")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
