﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using loja_chocolates.Models;

namespace loja_chocolates.Migrations
{
    [DbContext(typeof(ChocolateContext))]
    [Migration("20210424150539_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("loja_chocolates.Models.Chocolate", b =>
                {
                    b.Property<int>("ChocolateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PorcentagemCacau")
                        .HasColumnType("int");

                    b.Property<float>("Preco")
                        .HasColumnType("float");

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ChocolateId");

                    b.ToTable("Chocolates");
                });
#pragma warning restore 612, 618
        }
    }
}
