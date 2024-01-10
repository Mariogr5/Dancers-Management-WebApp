﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ptt_api.Entities;

#nullable disable

namespace ptt_api.Migrations
{
    [DbContext(typeof(DancersDbContext))]
    partial class DancersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ptt_api.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ptt_api.Entities.DanceClub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("DanceClubs");
                });

            modelBuilder.Entity("ptt_api.Entities.DanceCompetitionCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryDanceClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DanceEventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DanceEventId");

                    b.ToTable("DanceCompetitionCategories");
                });

            modelBuilder.Entity("ptt_api.Entities.DanceEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompetition")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organizer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DanceEvents");
                });

            modelBuilder.Entity("ptt_api.Entities.DancePair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DanceCompetitionCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("DancePairClubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DancePartnerId")
                        .HasColumnType("int");

                    b.Property<string>("DancePartnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DancerId")
                        .HasColumnType("int");

                    b.Property<string>("DancerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PairDanceClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PairNumberofPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DanceCompetitionCategoryId");

                    b.ToTable("DancePairs");
                });

            modelBuilder.Entity("ptt_api.Entities.Dancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DanceClubId")
                        .HasColumnType("int");

                    b.Property<string>("DancePartnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Danceclass")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("H");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("NumberofPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DanceClubId");

                    b.ToTable("Dancers");
                });

            modelBuilder.Entity("ptt_api.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ptt_api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ptt_api.Entities.DanceClub", b =>
                {
                    b.HasOne("ptt_api.Entities.Address", "Address")
                        .WithOne("DanceClub")
                        .HasForeignKey("ptt_api.Entities.DanceClub", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ptt_api.Entities.DanceCompetitionCategory", b =>
                {
                    b.HasOne("ptt_api.Entities.DanceEvent", null)
                        .WithMany("DanceCompetitionCategories")
                        .HasForeignKey("DanceEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ptt_api.Entities.DancePair", b =>
                {
                    b.HasOne("ptt_api.Entities.DanceCompetitionCategory", "DanceCompetitionCategory")
                        .WithMany("ListofPairs")
                        .HasForeignKey("DanceCompetitionCategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DanceCompetitionCategory");
                });

            modelBuilder.Entity("ptt_api.Entities.Dancer", b =>
                {
                    b.HasOne("ptt_api.Entities.DanceClub", "DancerClub")
                        .WithMany("Dancers")
                        .HasForeignKey("DanceClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DancerClub");
                });

            modelBuilder.Entity("ptt_api.Entities.User", b =>
                {
                    b.HasOne("ptt_api.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ptt_api.Entities.Address", b =>
                {
                    b.Navigation("DanceClub")
                        .IsRequired();
                });

            modelBuilder.Entity("ptt_api.Entities.DanceClub", b =>
                {
                    b.Navigation("Dancers");
                });

            modelBuilder.Entity("ptt_api.Entities.DanceCompetitionCategory", b =>
                {
                    b.Navigation("ListofPairs");
                });

            modelBuilder.Entity("ptt_api.Entities.DanceEvent", b =>
                {
                    b.Navigation("DanceCompetitionCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
