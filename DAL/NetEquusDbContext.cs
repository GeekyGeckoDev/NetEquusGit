using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Reflection.Emit;
using Domain.Models.Competitions;
using Domain.Models.EquineEstates;
using Domain.Models.Horses;
using Domain.Models.Horses.Breeds;
using Domain.Models.Horses.HorseStats;
using Domain.Models.Horses.Relations;
using Domain.Models.Sales;
using Domain.Models.Shared;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public class NetEquusDbContext : DbContext
{
    public NetEquusDbContext(DbContextOptions<NetEquusDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestEntity> TestEntities { get; set; }

    #region [DbSet Competitions]

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<CompetitionEntry> CompetitionEntries { get; set; }

    public virtual DbSet<CompetitionLevel> CompetitionLevels { get; set; }

    public virtual DbSet<CompetitionResult> CompetitionResults { get; set; }

    public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }

    public virtual DbSet<DisciplineGroup> DisciplineGroups { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    #endregion

    #region [DbSet EquineEstate]

    public virtual DbSet<EquineEstate> EquineEstates { get; set; }


    public virtual DbSet<EquineEstatesOwner> EquineEstatesOwners { get; set; }

    public virtual DbSet<EquineEstateMergeRequest> EquineEstateMergeRequests { get; set; }


    public virtual DbSet<Facility> Facilities { get; set; }

    #endregion

    #region [DbSet Horses]

    public virtual DbSet<CompetitionProgression> CompetitionProgressions { get; set; }
    public virtual DbSet<Foaling> Foalings { get; set; }

    public virtual DbSet<Horse> Horses { get; set; }

    public virtual DbSet<HorseOwnership> HorseOwnerships { get; set; }
    public virtual DbSet<HorseBoarding> HorseBoardings { get; set; }

    public virtual DbSet<HorseTrophy> HorseTrophies { get; set; }

    public virtual DbSet<LastBreedRegistry> LastBreedRegistries { get; set; }


    #region[DbSet Breeds]

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<BreedCrossGroup> BreedCrossGroups { get; set; }

    public virtual DbSet<BreedGroup> BreedGroups { get; set; }


    public virtual DbSet<CrossGroup> CrossGroups { get; set; }


    public virtual DbSet<FoundationPair> FoundationPairs { get; set; }

    #endregion

    #region [DbSet HorseStats]

    public virtual DbSet<ConformationAttributes> ConformationAttributes { get; set; }

    public virtual DbSet<HorsePurposeStat> HorsePurposeStats { get; set; }

    public virtual DbSet<TemperamentInformation> TemperamentInformation { get; set; }

    public virtual DbSet<PerformanceAttributes> PerformanceAttributes { get; set; }

    #endregion

    #region [DbSet HorseTypes]

    public virtual DbSet<HorseArtistsApproval> HorseArtistSApprovals { get; set; }

    public virtual DbSet<HorseType> HorseTypes { get; set; }

    public virtual DbSet<HorseTypeSubmission> HorseTypeSubmissions { get; set; }


    public virtual DbSet<HorseTypeSubmissionArtist> HorseTypeSubmissionArtists { get; set; }

    #endregion

    #region [DbSet QualityScore]

    public virtual DbSet<BreedQualityScore> BreedQualityScores { get; set; }

    public virtual DbSet<PerformanceQualityScore> PerformanceQualityScores { get; set; }

    public virtual DbSet<ScorePotential> ScorePotentials { get; set; }

    #endregion

    #endregion

    #region [DbSet Sales]

    public virtual DbSet<AuctionBid> AuctionBids { get; set; }

    public virtual DbSet<AuctionSale> AuctionSales { get; set; }

    public virtual DbSet<PrivateSale> PrivateSales { get; set; }

    public virtual DbSet<SaleEventType> SaleEventTypes { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    #endregion

    #region [Shared]

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<SeasonWeatherAllowed> SeasonWeatherAlloweds { get; set; }


    #endregion

    #region [DbSet Users]


    public virtual DbSet<HorseArtist> HorseArtists { get; set; }

    public virtual DbSet<PlayerTrophy> PlayerTrophies { get; set; }

    public virtual DbSet<Role> Roles { get; set; }


    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }



    #endregion

    public static class SystemConstants
    {
        public static readonly Guid SystemUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public static readonly Guid SystemEstateId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    }

    #region [OnModelCreating]

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>().HasData(new User
        {
            UserId = SystemConstants.SystemUserId,
            UserName = "SystemBot",
            UserEmail = "system@horsenet.com",
            IsSystemUser = true,
            // ...other required properties
        });

        modelBuilder.Entity<EquineEstate>().HasData(new EquineEstate
        {
            EquineEstateId = SystemConstants.SystemEstateId,
            EstateName = "System Holding",
            IsSystemEstate = true
        });

        // Seed the join table (assuming it's EquineEstateOwner with UserId and EstateId as FKs)
        modelBuilder.Entity<EquineEstatesOwner>().HasData(new EquineEstatesOwner
        {
            UserId = SystemConstants.SystemUserId,
            EquineEstateId = SystemConstants.SystemEstateId,
        });


        modelBuilder.Entity<BreedCrossGroup>(entity =>
        {
            entity.HasKey(e => new { e.BreedId, e.CrossGroupId });

            entity.HasOne(e => e.Breed)
                .WithMany(b => b.BreedCrossGroups)
                .HasForeignKey(e => e.BreedId);

            entity.HasOne(e => e.CrossGroup)
                .WithMany(c => c.BreedCrossGroups)
                .HasForeignKey(e => e.CrossGroupId);

            entity.ToTable("BreedCrossGroup");
        });


        modelBuilder.Entity<CompetitionProgression>(entity =>
        {
            // Configure GuidHorseId as the primary key
            entity.HasKey(cp => cp.GuidHorseId);

            // Configure the foreign key relationship with Horse
            entity.HasOne(cp => cp.Horse)
                  .WithMany(h => h.CompetitionProgressions) // assuming Horse has ICollection<CompetitionProgression> CompetitionProgressions
                  .HasForeignKey(cp => cp.GuidHorseId)
                  .OnDelete(DeleteBehavior.Cascade); // or whatever delete behavior fits your logic
        });

        modelBuilder.Entity<DisciplineGroupAllowedDiscipline>()
        .HasKey(d => new { d.DisciplineGroupId, d.Discipline });

        // Also configure relationships:
        modelBuilder.Entity<DisciplineGroupAllowedDiscipline>()
            .HasOne(d => d.DisciplineGroup)
            .WithMany(g => g.AllowedDisciplines)
            .HasForeignKey(d => d.DisciplineGroupId);

        modelBuilder.Entity<Foaling>(entity =>
        {
            entity.HasOne(d => d.Dam).WithMany(p => p.FoalingDams)
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Sire).WithMany(p => p.FoalingSires)
            .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FoundationPair>(entity =>
        {
            entity.HasOne(d => d.ParentBreedDam)
            .WithMany(p => p.FoundationPairParentBreedDams)
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ParentBreedSire)
            .WithMany(p => p.FoundationPairParentBreedSires)
            .OnDelete(DeleteBehavior.ClientSetNull);
        });


        // Configure ConfPerfTempAttributes
        modelBuilder.Entity<ConfPerfTempAttributes>(entity =>
        {
            entity.HasKey(e => e.CPTId);

            entity.HasOne(e => e.Horse)
             .WithOne(h => h.ConfPerfTempAttributes)  // Assuming Horse has this nav property
             .HasForeignKey<ConfPerfTempAttributes>(e => e.GuidHorseId);

            // Owned types: ConformationAttributes and PerformanceAttributes are embedded value objects
            entity.OwnsOne(e => e.ConformationAttributes, conf =>
            {
                conf.Property(c => c.Legs);
                conf.Property(c => c.Shoulders);
                conf.Property(c => c.Hindquarters);
                conf.Property(c => c.Pasterns);
                conf.Property(c => c.BackAndLoin);
                conf.Property(c => c.Head);
                conf.Property(c => c.Neck);
                conf.Property(c => c.ChestAndBarrel);
                conf.Property(c => c.BackAndTopline);
                conf.Property(c => c.OverallProportions);

                // NotMapped properties are automatically ignored
            });

            entity.OwnsOne(e => e.PerformanceAttributes, perf =>
            {
                perf.Property(p => p.Gaits);
                perf.Property(p => p.Jumping);
                perf.Property(p => p.Speed);
                perf.Property(p => p.Agility);
                perf.Property(p => p.Endurance);
                perf.Property(p => p.Stride);
                perf.Property(p => p.Rideability);
                perf.Property(p => p.Temperament);
            });


        });

        modelBuilder.Entity<TemperamentInformation>()
    .HasOne<ConfPerfTempAttributes>() // no nav back
    .WithOne()
    .HasForeignKey<TemperamentInformation>(t => t.TemperamentId); // FK = PK

        // Configure TemperamentInformation entity
        modelBuilder.Entity<TemperamentInformation>(entity =>
        {
            entity.HasKey(t => t.TemperamentId);
            entity.Property(t => t.AffectedBy).IsRequired();
            entity.Property(t => t.EffectOnPerformance).IsRequired();
            entity.Property(t => t.PerformsWellIn).IsRequired();
            entity.Property(t => t.PerformsPoorlyIn).IsRequired();
            entity.Property(t => t.PreferredGroundTypes).IsRequired();

            entity.Property(t => t.Temperament)
          .HasConversion<string>() // or .HasConversion<int>() depending on how you want to store it
          .IsRequired();

        });

        modelBuilder.Entity<SeasonWeatherAllowed>()
    .HasKey(swa => new { swa.SeasonsId, swa.WeatherId });

        modelBuilder.Entity<AuctionBid>()
            .HasOne(b => b.AuctionSale)
            .WithMany(a => a.Bids)
            .HasForeignKey(b => b.AuctionSaleId);


        modelBuilder.Entity<ScorePotential>(entity =>
        {
            entity.Property(e => e.HorseId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TrophyBase>(entity =>
        {
            entity.HasKey(t => t.TrophyId); // make sure the PK is here in the base class
            entity.HasDiscriminator<string>("TrophyType")
                .HasValue<PlayerTrophy>("PlayerTrophy")
                .HasValue<BreedingTrophy>("CompetitionPlayer")
                .HasValue<HorseTrophy>("HorseTrophy")
                .HasValue<BreedingHorseTrophy>("BreedingHorse");
        });

        modelBuilder.Entity<Facility>()
    .HasDiscriminator<string>("FacilityType")
    .HasValue<Personnel>(nameof(Personnel))
    .HasValue<Arena>(nameof(Arena))
    .HasValue<Pasture>(nameof(Pasture));

        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<Competition>()
            .HasOne(c => c.Season)
            .WithMany() // Or .WithMany(s => s.Competitions) if Season has a nav
            .HasForeignKey(c => c.SeasonId);

        modelBuilder.Entity<HorseType>()
    .HasOne(ht => ht.HorseTypeSubmission)
    .WithMany() // or .WithMany(hs => hs.HorseTypes) if you have a collection navigation
    .HasForeignKey(ht => ht.HorseTypeSubmissionId)
    .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction to prevent cascade delete

        modelBuilder.Entity<EquineEstateMergeRequest>()
    .HasOne(e => e.ToEquineEstate)
    .WithMany()
    .HasForeignKey(e => e.ToEquineEstateId)
    .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<SeasonWeatherAllowed>()
            .HasKey(swa => new { swa.SeasonsId, swa.WeatherId });

        modelBuilder.Entity<SeasonWeatherAllowed>()
            .HasOne(swa => swa.Season)
            .WithMany(s => s.AllowedWeathers)
            .HasForeignKey(swa => swa.SeasonsId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HorseSaleBase>()
      .HasOne(h => h.SellerEquineEstate)
      .WithMany()
      .HasForeignKey(h => h.EquineEstateId)
      .OnDelete(DeleteBehavior.Restrict); // or NoAction()

        modelBuilder.Entity<PrivateSale>()
            .HasOne(p => p.BuyerEquineEstate)
            .WithMany()
            .HasForeignKey(p => p.BuyerEquineEstateId)
            .OnDelete(DeleteBehavior.Restrict); // or NoAction()





    }

    #endregion
}
