﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ordos.DataService.Data;

namespace Ordos.DataService.Migrations
{
    [DbContext(typeof(SystemContext))]
    [Migration("20181010193318_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ordos.Core.Models.ConfigurationValue", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("ConfigurationValues");
                });

            modelBuilder.Entity("Ordos.Core.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bay")
                        .IsRequired();

                    b.Property<string>("DeviceType");

                    b.Property<bool>("HasPing");

                    b.Property<string>("IPAddress")
                        .IsRequired();

                    b.Property<bool>("IsConnected");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Station")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Ordos.Core.Models.DisturbanceRecording", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("TriggerChannel");

                    b.Property<double>("TriggerLength");

                    b.Property<DateTime>("TriggerTime");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("DisturbanceRecordings");
                });

            modelBuilder.Entity("Ordos.Core.Models.DRFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("DisturbanceRecordingId");

                    b.Property<byte[]>("FileData");

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<long>("FileSize");

                    b.HasKey("Id");

                    b.HasIndex("DisturbanceRecordingId");

                    b.ToTable("DRFiles");
                });

            modelBuilder.Entity("Ordos.Core.Models.DisturbanceRecording", b =>
                {
                    b.HasOne("Ordos.Core.Models.Device", "Device")
                        .WithMany("DisturbanceRecordings")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ordos.Core.Models.DRFile", b =>
                {
                    b.HasOne("Ordos.Core.Models.DisturbanceRecording", "DisturbanceRecording")
                        .WithMany("DRFiles")
                        .HasForeignKey("DisturbanceRecordingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
