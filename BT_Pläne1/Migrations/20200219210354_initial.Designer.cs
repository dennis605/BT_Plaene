﻿// <auto-generated />
using System;
using BT_Pläne1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BT_Pläne1.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200219210354_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BT_Pläne1.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventBeschreibung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventOrt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventVorlauf")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BT_Pläne1.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nachname")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rolle")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PersonId");

                    b.HasIndex("Vorname", "Nachname", "Rolle");

                    b.ToTable("Personen");
                });

            modelBuilder.Entity("BT_Pläne1.PersonenEvent", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("PersonenEvent");
                });

            modelBuilder.Entity("BT_Pläne1.PersonenEvent", b =>
                {
                    b.HasOne("BT_Pläne1.Event", "Event")
                        .WithMany("PersonenEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BT_Pläne1.Person", "Person")
                        .WithMany("PersonenEvents")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
