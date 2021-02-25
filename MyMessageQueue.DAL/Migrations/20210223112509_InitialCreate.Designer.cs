﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMessageQueue.DAL;

namespace MyMessageQueue.DAL.Migrations
{
    [DbContext(typeof(MyMessageQueueDBContext))]
    [Migration("20210223112509_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyMessageQueue.Model.QueueMessage", b =>
                {
                    b.Property<int>("QueueMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MessageTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("QueueMessageId");

                    b.ToTable("MyMessageQueue");
                });
#pragma warning restore 612, 618
        }
    }
}