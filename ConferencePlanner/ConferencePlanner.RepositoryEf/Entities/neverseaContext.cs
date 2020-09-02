using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConferencePlanner.Repository.Ef.Entities
{

        public partial class neverseaContext : DbContext
        {
            public neverseaContext()
            {
            }

            public neverseaContext(DbContextOptions<neverseaContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Admin> Admin { get; set; }
            public virtual DbSet<Conference> Conference { get; set; }
            public virtual DbSet<ConferenceAttendance> ConferenceAttendance { get; set; }
            public virtual DbSet<ConferenceXspeaker> ConferenceXspeaker { get; set; }
            public virtual DbSet<Demo> Demo { get; set; }
            public virtual DbSet<DictionaryCity> DictionaryCity { get; set; }
            public virtual DbSet<DictionaryConferenceCategory> DictionaryConferenceCategory { get; set; }
            public virtual DbSet<DictionaryConferenceType> DictionaryConferenceType { get; set; }
            public virtual DbSet<DictionaryCountry> DictionaryCountry { get; set; }
            public virtual DbSet<DictionaryDistrict> DictionaryDistrict { get; set; }
            public virtual DbSet<DictionaryParticipantStatus> DictionaryParticipantStatus { get; set; }
            public virtual DbSet<DictionarySpeaker> DictionarySpeaker { get; set; }
            public virtual DbSet<Location> Location { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                    optionsBuilder.UseSqlServer("Server=ts-internship-2019.database.windows.net;Database=neversea;User Id=usr2020;Password=n39fn0n2_j32-(#;MultipleActiveResultSets=true;");
                }
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Admin>(entity =>
                {
                    entity.Property(e => e.AdminEmail)
                        .IsRequired()
                        .HasMaxLength(50);
                });

                modelBuilder.Entity<Conference>(entity =>
                {
                    entity.HasIndex(e => e.ConferenceName)
                        .HasName("UQ__Conferen__4DD858CF5E1FA340")
                        .IsUnique();

                    entity.Property(e => e.ConferenceName)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.EndDate).HasColumnType("datetime");

                    entity.Property(e => e.OrganiserEmail)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.StartDate).HasColumnType("datetime");

                    entity.HasOne(d => d.DictionaryConferenceCategory)
                        .WithMany(p => p.Conference)
                        .HasForeignKey(d => d.DictionaryConferenceCategoryId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Conferenc__Dicti__37703C52");

                    entity.HasOne(d => d.DictionaryConferenceType)
                        .WithMany(p => p.Conference)
                        .HasForeignKey(d => d.DictionaryConferenceTypeId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Conferenc__Dicti__367C1819");

                    entity.HasOne(d => d.Location)
                        .WithMany(p => p.Conference)
                        .HasForeignKey(d => d.LocationId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Conferenc__Locat__3587F3E0");
                });

                modelBuilder.Entity<ConferenceAttendance>(entity =>
                {
                    entity.HasKey(e => new { e.ConferenceId, e.ParticipantEmailAddress })
                        .HasName("PK__Conferen__D2AED4F162445BD6");

                    entity.Property(e => e.ParticipantEmailAddress).HasMaxLength(50);

                    entity.HasOne(d => d.Conference)
                        .WithMany(p => p.ConferenceAttendance)
                        .HasForeignKey(d => d.ConferenceId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Conferenc__Confe__3D2915A8");

                    entity.HasOne(d => d.DictionaryParticipantStatus)
                        .WithMany(p => p.ConferenceAttendance)
                        .HasForeignKey(d => d.DictionaryParticipantStatusId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Conferenc__Dicti__3E1D39E1");
                });

                modelBuilder.Entity<ConferenceXspeaker>(entity =>
                {
                    entity.HasKey(e => new { e.DictionarySpeakerId, e.ConferenceId })
                        .HasName("PK__Conferen__3D98D7D81B6B06E5");

                    entity.ToTable("ConferenceXSpeaker");

                    entity.HasOne(d => d.Conference)
                        .WithMany(p => p.ConferenceXspeaker)
                        .HasForeignKey(d => d.ConferenceId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Conferenc__Confe__41EDCAC5");

                    entity.HasOne(d => d.DictionarySpeaker)
                        .WithMany(p => p.ConferenceXspeaker)
                        .HasForeignKey(d => d.DictionarySpeakerId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Conferenc__Dicti__40F9A68C");
                });

                modelBuilder.Entity<Demo>(entity =>
                {
                    entity.Property(e => e.Name).IsRequired();
                });

                modelBuilder.Entity<DictionaryCity>(entity =>
                {
                    entity.Property(e => e.DictionaryCityId).ValueGeneratedNever();

                    entity.Property(e => e.DictionaryCityName)
                        .IsRequired()
                        .HasMaxLength(25);

                    entity.HasOne(d => d.DictionaryDistrict)
                        .WithMany(p => p.DictionaryCity)
                        .HasForeignKey(d => d.DictionaryDistrictId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Dictionar__Dicti__2739D489");
                });

                modelBuilder.Entity<DictionaryConferenceCategory>(entity =>
                {
                    entity.Property(e => e.DictionaryConferenceCategoryId).ValueGeneratedNever();

                    entity.Property(e => e.DictionaryConferenceCategoryName)
                        .IsRequired()
                        .HasMaxLength(25);
                });

                modelBuilder.Entity<DictionaryConferenceType>(entity =>
                {
                    entity.Property(e => e.DictionaryConferenceTypeId).ValueGeneratedNever();

                    entity.Property(e => e.DictionaryConferenceTypeName)
                        .IsRequired()
                        .HasMaxLength(25);
                });

                modelBuilder.Entity<DictionaryCountry>(entity =>
                {
                    entity.Property(e => e.DictionaryCountryId).ValueGeneratedNever();

                    entity.Property(e => e.DictionaryCountryCode)
                        .IsRequired()
                        .HasMaxLength(5);

                    entity.Property(e => e.DictionaryCountryName)
                        .IsRequired()
                        .HasMaxLength(25);

                    entity.Property(e => e.DictionaryCountryNationality)
                        .IsRequired()
                        .HasMaxLength(20);
                });

                modelBuilder.Entity<DictionaryDistrict>(entity =>
                {
                    entity.Property(e => e.DictionaryDistrictId).ValueGeneratedNever();

                    entity.Property(e => e.DictionaryDistrictCode)
                        .IsRequired()
                        .HasMaxLength(5);

                    entity.Property(e => e.DictionaryDistrictName)
                        .IsRequired()
                        .HasMaxLength(25);

                    entity.HasOne(d => d.DictionaryCountry)
                        .WithMany(p => p.DictionaryDistrict)
                        .HasForeignKey(d => d.DictionaryCountryId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Dictionar__Dicti__245D67DE");
                });

                modelBuilder.Entity<DictionaryParticipantStatus>(entity =>
                {
                    entity.Property(e => e.DictionaryParticipantStatusId).ValueGeneratedNever();

                    entity.Property(e => e.DictionaryParticipantStatusName)
                        .IsRequired()
                        .HasMaxLength(25);
                });

                modelBuilder.Entity<DictionarySpeaker>(entity =>
                {
                    entity.Property(e => e.DictionarySpeakerId).ValueGeneratedNever();

                    entity.Property(e => e.DictionarySpeakerImage).HasMaxLength(200);

                    entity.Property(e => e.DictionarySpeakerName)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.DictionarySpeakerNationality).HasMaxLength(25);

                    entity.HasOne(d => d.DictionaryCountry)
                        .WithMany(p => p.DictionarySpeaker)
                        .HasForeignKey(d => d.DictionaryCountryId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Dictionar__Dicti__2FCF1A8A");
                });

                modelBuilder.Entity<Location>(entity =>
                {
                    entity.Property(e => e.Latitude).HasColumnType("decimal(12, 9)");

                    entity.Property(e => e.LocationAddress)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.Longitude).HasColumnType("decimal(12, 9)");

                    entity.HasOne(d => d.DictionaryCity)
                        .WithMany(p => p.Location)
                        .HasForeignKey(d => d.DictionaryCityId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Location__Dictio__2BFE89A6");
                });

                OnModelCreatingPartial(modelBuilder);
            }

            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        }
    }
