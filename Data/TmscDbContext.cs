using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TyphoonTaskingTool.Models;

namespace TyphoonTaskingTool.Data;

public partial class TmscDbContext : DbContext
{
    //public TmscDbContext()
    //{
    //}

    public TmscDbContext(DbContextOptions<TmscDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LookupRank> LookupRanks { get; set; }

    public virtual DbSet<LookupStatus> LookupStatuses { get; set; }

    public virtual DbSet<LookupTeam> LookupTeams { get; set; }

    public virtual DbSet<LookupUnit> LookupUnits { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestUpdate> RequestUpdates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=AzurePubConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LookupRank>(entity =>
        {
            entity.HasKey(e => e.RankId).HasName("PK__LOOKUP_R__25BE3A45C8792EA9");

            entity.ToTable("LOOKUP_Rank");

            entity.Property(e => e.RankId).HasColumnName("Rank_Id");
            entity.Property(e => e.RankNameLong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rank_NameLong");
            entity.Property(e => e.RankNameShort)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rank_NameShort");
            entity.Property(e => e.RankNatoequiv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rank_NATOEquiv");
        });

        modelBuilder.Entity<LookupStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__LOOKUP_S__5190094C594F5F23");

            entity.ToTable("LOOKUP_Status");

            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Status_Description");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Status_Name");
        });

        modelBuilder.Entity<LookupTeam>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__LOOKUP_T__02215C6AEBF1AF51");

            entity.ToTable("LOOKUP_Team");

            entity.Property(e => e.TeamId).HasColumnName("Team_Id");
            entity.Property(e => e.TeamNameLong)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Team_NameLong");
            entity.Property(e => e.TeamNameShort)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Team_NameShort");
        });

        modelBuilder.Entity<LookupUnit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__LOOKUP_U__27556B78AA3A02A9");

            entity.ToTable("LOOKUP_Unit");

            entity.Property(e => e.UnitId).HasColumnName("Unit_Id");
            entity.Property(e => e.UnitNameLong)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Unit_NameLong");
            entity.Property(e => e.UnitNameShort)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Unit_NameShort");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestTaskId).HasName("PK__Requests__369BD5A545908220");

            entity.Property(e => e.RequestTaskId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Request_TaskId");
            entity.Property(e => e.RankId).HasColumnName("Rank_Id");
            entity.Property(e => e.RequestArchive).HasColumnName("Request_Archive");
            entity.Property(e => e.RequestContactPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Request_ContactPhone");
            entity.Property(e => e.RequestCreated)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Request_Created");
            entity.Property(e => e.RequestEmailAdd)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Request_EmailAdd");
            entity.Property(e => e.RequestFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_FirstName");
            entity.Property(e => e.RequestLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_LastName");
            entity.Property(e => e.RequestShortId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Request_ShortId");
            entity.Property(e => e.RequestTaskDescription)
                .IsUnicode(false)
                .HasColumnName("Request_TaskDescription");
            entity.Property(e => e.RequestTitle)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Request_Title");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.TeamId).HasColumnName("Team_Id");
            entity.Property(e => e.UnitId).HasColumnName("Unit_Id");

            entity.HasOne(d => d.Rank).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RankId)
                .HasConstraintName("FK_Request_Rank");

            entity.HasOne(d => d.Status).WithMany(p => p.Requests)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Request_Status");

            entity.HasOne(d => d.Team).WithMany(p => p.Requests)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_Request_Team");

            entity.HasOne(d => d.Unit).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_Request_Unit");
        });

        modelBuilder.Entity<RequestUpdate>(entity =>
        {
            entity.HasKey(e => e.UpdateId).HasName("PK__RequestU__C11655E4EB5F5284");

            entity.Property(e => e.UpdateId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Update_Id");
            entity.Property(e => e.RequestTaskId).HasColumnName("Request_TaskId");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Update_By");
            entity.Property(e => e.UpdateDescription)
                .IsUnicode(false)
                .HasColumnName("Update_Description");
            entity.Property(e => e.UpdateTimeStamp)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Update_TimeStamp");

            entity.HasOne(d => d.RequestTask).WithMany(p => p.RequestUpdates)
                .HasForeignKey(d => d.RequestTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UpdateRequest");

            entity.HasOne(d => d.Status).WithMany(p => p.RequestUpdates)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_UpdateStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
