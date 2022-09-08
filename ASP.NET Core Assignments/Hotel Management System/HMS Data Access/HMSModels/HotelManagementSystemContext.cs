using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class HotelManagementSystemContext : DbContext
    {
        public HotelManagementSystemContext()
        {
        }

        public HotelManagementSystemContext(DbContextOptions<HotelManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<GuestDetails> GuestDetails { get; set; }
        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<RoomDetails> RoomDetails { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<StaffDetails> StaffDetails { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Hotel Management System;Integrated Security=True");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Bill>(entity =>
//            {
//                entity.Property(e => e.BillId)
//                    .HasColumnName("BillID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CreditCardDetails).HasColumnType("decimal(16, 0)");

//                entity.Property(e => e.GuestId).HasColumnName("GuestID");

//                entity.Property(e => e.IssueDate).HasColumnType("datetime");

//                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

//                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

//                entity.Property(e => e.Taxes).HasColumnType("decimal(10, 2)");

//                entity.HasOne(d => d.Guest)
//                    .WithMany(p => p.Bill)
//                    .HasForeignKey(d => d.GuestId)
//                    .HasConstraintName("FK_Bill_GuestDetails");

//                entity.HasOne(d => d.Service)
//                    .WithMany(p => p.Bill)
//                    .HasForeignKey(d => d.ServiceId)
//                    .HasConstraintName("FK_Bill_Services");
//            });

//            modelBuilder.Entity<Department>(entity =>
//            {
//                entity.Property(e => e.DepartmentId)
//                    .HasColumnName("DepartmentID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.DepartmentName)
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

//                entity.Property(e => e.ManagerName)
//                    .HasMaxLength(255)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<GuestDetails>(entity =>
//            {
//                entity.HasKey(e => e.GuestId)
//                    .HasName("PK__GuestDet__0C423C3296360325");

//                entity.Property(e => e.GuestId)
//                    .HasColumnName("GuestID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.Email).HasMaxLength(255);

//                entity.Property(e => e.Gender)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.GuestAddress).HasMaxLength(255);

//                entity.Property(e => e.GuestName)
//                    .IsRequired()
//                    .HasMaxLength(255);

//                entity.Property(e => e.PhoneNumber).HasColumnType("decimal(10, 0)");

//                entity.Property(e => e.RoomId).HasColumnName("RoomID");

//                entity.HasOne(d => d.Room)
//                    .WithMany(p => p.GuestDetails)
//                    .HasForeignKey(d => d.RoomId)
//                    .HasConstraintName("FK_GuestDetails_RoomDetails");
//            });

//            modelBuilder.Entity<Rates>(entity =>
//            {
//                entity.HasKey(e => e.RateId)
//                    .HasName("PK__Rates__58A7CCBCEDF47561");

//                entity.Property(e => e.RateId)
//                    .HasColumnName("RateID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.ExtensionPrice).HasColumnType("decimal(10, 2)");

//                entity.Property(e => e.FirstNightPrice).HasColumnType("decimal(10, 2)");
//            });

//            modelBuilder.Entity<Reservation>(entity =>
//            {
//                entity.Property(e => e.ReservationId)
//                    .HasColumnName("ReservationID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.GuestId).HasColumnName("GuestID");

//                entity.Property(e => e.Status).HasMaxLength(10);

//                entity.HasOne(d => d.Guest)
//                    .WithMany(p => p.Reservation)
//                    .HasForeignKey(d => d.GuestId)
//                    .HasConstraintName("FK_Reservation_GuestDetails");
//            });

//            modelBuilder.Entity<RoomDetails>(entity =>
//            {
//                entity.HasKey(e => e.RoomId)
//                    .HasName("PK__RoomDeta__32863919B0938417");

//                entity.Property(e => e.RoomId)
//                    .HasColumnName("RoomID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.CheckIn).HasColumnType("datetime");

//                entity.Property(e => e.CheckOut).HasColumnType("datetime");

//                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

//                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

//                entity.HasOne(d => d.Reservation)
//                    .WithMany(p => p.RoomDetails)
//                    .HasForeignKey(d => d.ReservationId)
//                    .HasConstraintName("FK_RoomDetails_Reservation");

//                entity.HasOne(d => d.Room)
//                    .WithOne(p => p.RoomDetails)
//                    .HasForeignKey<RoomDetails>(d => d.RoomId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_RoomDetails_Services");
//            });

//            modelBuilder.Entity<Services>(entity =>
//            {
//                entity.HasKey(e => e.ServiceId)
//                    .HasName("PK__Services__C51BB0EAC9A350DD");

//                entity.Property(e => e.ServiceId)
//                    .HasColumnName("ServiceID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.ServiceName)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.ServicePrice).HasColumnType("decimal(10, 0)");
//            });

//            modelBuilder.Entity<StaffDetails>(entity =>
//            {
//                entity.HasKey(e => e.StaffId)
//                    .HasName("PK__StaffDet__96D4AAF7D434C00F");

//                entity.Property(e => e.StaffId)
//                    .HasColumnName("StaffID")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

//                entity.Property(e => e.Email).HasMaxLength(255);

//                entity.Property(e => e.Nic)
//                    .HasColumnName("NIC")
//                    .HasColumnType("decimal(16, 0)");

//                entity.Property(e => e.Occupation)
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

//                entity.Property(e => e.StaffAddress).HasMaxLength(255);

//                entity.Property(e => e.StaffName)
//                    .HasMaxLength(255)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Department)
//                    .WithMany(p => p.StaffDetails)
//                    .HasForeignKey(d => d.DepartmentId)
//                    .HasConstraintName("FK_StaffDetails_Department");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
