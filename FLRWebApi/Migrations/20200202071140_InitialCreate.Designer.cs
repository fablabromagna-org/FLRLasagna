﻿// <auto-generated />
using System;
using FLRWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FLRWebApi.Migrations
{
    [DbContext(typeof(Meteo))]
    [Migration("20200202071140_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("FLRWebApi.Campione", b =>
                {
                    b.Property<int>("MeteoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Previsione")
                        .HasColumnType("TEXT");

                    b.Property<int>("Temperatura")
                        .HasColumnType("INTEGER");

                    b.HasKey("MeteoId");

                    b.ToTable("Campioni");
                });
#pragma warning restore 612, 618
        }
    }
}