﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Salmpled.Models;

namespace Salmpled.Migrations
{
    [DbContext(typeof(SalmpledContext))]
    [Migration("20211106065655_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Salmpled.Models.Follow", b =>
                {
                    b.Property<string>("FollowerId")
                        .HasColumnType("text");

                    b.Property<string>("FolloweeId")
                        .HasColumnType("text");

                    b.HasKey("FollowerId", "FolloweeId");

                    b.HasIndex("FolloweeId");

                    b.ToTable("Follow");
                });

            modelBuilder.Entity("Salmpled.Models.Sample", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bucket")
                        .HasColumnType("text");

                    b.Property<string>("CompressedSampleKey")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OrginalFileName")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<string>("RenamedFileName")
                        .HasColumnType("text");

                    b.Property<Guid>("SamplePackId")
                        .HasColumnType("uuid");

                    b.Property<string>("UncompressedSampleKey")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SamplePackId");

                    b.HasIndex("UserId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("Salmpled.Models.SampleLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("SampleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId1")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SampleId");

                    b.HasIndex("UserId1");

                    b.ToTable("SampleLike");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Published")
                        .HasColumnType("boolean");

                    b.Property<string>("SamplePackImageBucket")
                        .HasColumnType("text");

                    b.Property<string>("SamplePackImageKey")
                        .HasColumnType("text");

                    b.Property<string>("SamplePackImageRegion")
                        .HasColumnType("text");

                    b.Property<string>("SamplePackName")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SamplePack");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePackGenre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("GenreName")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SamplePackGenre");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePackLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("SamplePackId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SamplePackId");

                    b.HasIndex("UserId");

                    b.ToTable("SamplePackLike");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePackSamplePackGenre", b =>
                {
                    b.Property<Guid>("SamplePackId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SamplePackGenreId")
                        .HasColumnType("uuid");

                    b.HasKey("SamplePackId", "SamplePackGenreId");

                    b.HasIndex("SamplePackGenreId");

                    b.ToTable("SamplePackSamplePackGenre");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePlaylist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Published")
                        .HasColumnType("boolean");

                    b.Property<string>("SamplePlaylistImageBucket")
                        .HasColumnType("text");

                    b.Property<string>("SamplePlaylistImageKey")
                        .HasColumnType("text");

                    b.Property<string>("SamplePlaylistImageRegion")
                        .HasColumnType("text");

                    b.Property<string>("SamplePlaylistName")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SamplePlaylist");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePlaylistLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("SamplePackId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SamplePackId");

                    b.HasIndex("UserId");

                    b.ToTable("SamplePlaylistLike");
                });

            modelBuilder.Entity("Salmpled.Models.SampleSamplePlaylist", b =>
                {
                    b.Property<Guid>("SampleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SamplePlaylistId")
                        .HasColumnType("uuid");

                    b.HasKey("SampleId", "SamplePlaylistId");

                    b.HasIndex("SamplePlaylistId");

                    b.ToTable("SampleSamplePlaylist");
                });

            modelBuilder.Entity("Salmpled.Models.SampleSampleTag", b =>
                {
                    b.Property<Guid>("SampleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SampleTagId")
                        .HasColumnType("uuid");

                    b.HasKey("SampleId", "SampleTagId");

                    b.HasIndex("SampleTagId");

                    b.ToTable("SampleSampleTag");
                });

            modelBuilder.Entity("Salmpled.Models.SampleTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SampleTagName")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("SampleTag");
                });

            modelBuilder.Entity("Salmpled.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AuthProvider")
                        .HasColumnType("text");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Headline")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Salmpled.Models.UserImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("UserImageBucket")
                        .HasColumnType("text");

                    b.Property<string>("UserImageKey")
                        .HasColumnType("text");

                    b.Property<string>("UserImageRegion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserImage");
                });

            modelBuilder.Entity("Salmpled.Models.Follow", b =>
                {
                    b.HasOne("Salmpled.Models.User", "Follower")
                        .WithMany("Followee")
                        .HasForeignKey("FolloweeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Salmpled.Models.User", "Followee")
                        .WithMany("Follower")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Salmpled.Models.Sample", b =>
                {
                    b.HasOne("Salmpled.Models.SamplePack", "SamplePack")
                        .WithMany("Samples")
                        .HasForeignKey("SamplePackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salmpled.Models.User", "User")
                        .WithMany("Samples")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Salmpled.Models.SampleLike", b =>
                {
                    b.HasOne("Salmpled.Models.Sample", "Sample")
                        .WithMany()
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salmpled.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePack", b =>
                {
                    b.HasOne("Salmpled.Models.User", null)
                        .WithMany("SamplePacks")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePackLike", b =>
                {
                    b.HasOne("Salmpled.Models.SamplePack", "SamplePack")
                        .WithMany()
                        .HasForeignKey("SamplePackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salmpled.Models.User", "User")
                        .WithMany("SamplePackLikes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePackSamplePackGenre", b =>
                {
                    b.HasOne("Salmpled.Models.SamplePackGenre", "SamplePackGenre")
                        .WithMany("SamplePackSamplePackGenres")
                        .HasForeignKey("SamplePackGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salmpled.Models.SamplePack", "SamplePack")
                        .WithMany("SamplePackSamplePackGenres")
                        .HasForeignKey("SamplePackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Salmpled.Models.SamplePlaylist", b =>
                {
                    b.HasOne("Salmpled.Models.User", "User")
                        .WithMany("SamplePlaylists")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Salmpled.Models.SamplePlaylistLike", b =>
                {
                    b.HasOne("Salmpled.Models.SamplePack", "SamplePack")
                        .WithMany()
                        .HasForeignKey("SamplePackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salmpled.Models.User", "User")
                        .WithMany("SamplePlaylistLikes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Salmpled.Models.SampleSamplePlaylist", b =>
                {
                    b.HasOne("Salmpled.Models.Sample", "Sample")
                        .WithMany("SampleSamplePlaylists")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salmpled.Models.SamplePlaylist", "SamplePlaylist")
                        .WithMany("SampleSamplePlaylists")
                        .HasForeignKey("SamplePlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Salmpled.Models.SampleSampleTag", b =>
                {
                    b.HasOne("Salmpled.Models.Sample", "Sample")
                        .WithMany("SampleSampleTags")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Salmpled.Models.SampleTag", "SampleTag")
                        .WithMany("SampleSampleTags")
                        .HasForeignKey("SampleTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Salmpled.Models.UserImage", b =>
                {
                    b.HasOne("Salmpled.Models.User", "User")
                        .WithOne("UserImage")
                        .HasForeignKey("Salmpled.Models.UserImage", "UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
