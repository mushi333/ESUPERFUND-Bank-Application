﻿// <auto-generated />
using System;
using HTTP_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HTTP_API.Migrations
{
    [DbContext(typeof(TransactionContext))]
    [Migration("20231103102232_Initialization")]
    partial class Initialization
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HTTP_API.Models.BankTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("Balance")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Narration")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankTransactions");
                });

            modelBuilder.Entity("HTTP_API.Models.RawBankTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("Balance")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Narration")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RawBankTransactions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f1070e88-8811-4967-bd56-c4a9faff6c91"),
                            AccountNumber = 10001,
                            Amount = 100,
                            Balance = 100,
                            Date = new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Credit 1"
                        },
                        new
                        {
                            Id = new Guid("b3bf7220-f371-40b4-8116-2887336d5fab"),
                            AccountNumber = 10002,
                            Amount = 200,
                            Balance = 200,
                            Date = new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("c994cea0-1479-4f56-9cbe-e1b45ba5b7f1"),
                            AccountNumber = 10003,
                            Amount = 300,
                            Balance = 300,
                            Date = new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Credit 3"
                        },
                        new
                        {
                            Id = new Guid("9b734fe7-d136-4485-a67d-f21825d666c4"),
                            AccountNumber = 10001,
                            Amount = 200,
                            Balance = 300,
                            Date = new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Credit 4"
                        },
                        new
                        {
                            Id = new Guid("96cc4266-c174-4f6f-b276-4627800161e0"),
                            AccountNumber = 10002,
                            Amount = 100,
                            Balance = 200,
                            Date = new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Credit 5"
                        },
                        new
                        {
                            Id = new Guid("0f30ed8c-1adf-44c3-b580-f5fbb7a712cc"),
                            AccountNumber = 10003,
                            Amount = 100,
                            Balance = 400,
                            Date = new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Credit 6"
                        },
                        new
                        {
                            Id = new Guid("68826199-8f58-4dcf-833c-5f5ee426da2c"),
                            AccountNumber = 10001,
                            Amount = -50,
                            Balance = 250,
                            Date = new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Debit 1"
                        },
                        new
                        {
                            Id = new Guid("9a962f5c-19ae-48e5-a379-10187d9bd471"),
                            AccountNumber = 10002,
                            Amount = -20,
                            Balance = 200,
                            Date = new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Debit 2"
                        },
                        new
                        {
                            Id = new Guid("86b567c2-8a05-41cc-b82f-d74002f3f211"),
                            AccountNumber = 10003,
                            Date = new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Debit 3"
                        },
                        new
                        {
                            Id = new Guid("6f512e21-041e-4feb-ae2b-fc147393fd93"),
                            AccountNumber = 10001,
                            Amount = -100,
                            Balance = 150,
                            Date = new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Debit 4"
                        },
                        new
                        {
                            Id = new Guid("2325fa7b-4601-4c36-aa13-71c2bf47f3fb"),
                            AccountNumber = 10002,
                            Amount = -100,
                            Balance = 200,
                            Date = new DateTime(2022, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Debit 5"
                        },
                        new
                        {
                            Id = new Guid("580784a2-803e-48f1-b773-69864658f9ad"),
                            AccountNumber = 10003,
                            Date = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Debit 6"
                        },
                        new
                        {
                            Id = new Guid("2621b142-c472-4cc8-ac28-90e7293eb810"),
                            Amount = -50,
                            Balance = 200,
                            Date = new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Narration = "Debit 7"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
