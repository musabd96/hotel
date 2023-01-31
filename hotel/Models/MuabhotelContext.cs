using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hotel.Models;

public partial class MuabhotelContext : DbContext
{
    public MuabhotelContext()
    {
    }

    public MuabhotelContext(DbContextOptions<MuabhotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookedinfo> Bookedinfos { get; set; }

    public virtual DbSet<Bookedview> Bookedviews { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Dashboardview> Dashboardviews { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Reservationtype> Reservationtypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roomsview> Roomsviews { get; set; }

    public virtual DbSet<Use> Uses { get; set; }

    public virtual DbSet<Viewemployee> Viewemployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=muabhotel;user=root;password=0909;sslmode=None", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Bookedinfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("bookedinfo");

            entity.Property(e => e.BookingCheckin)
                .HasMaxLength(45)
                .HasColumnName("booking_checkin");
            entity.Property(e => e.BookingCheckout)
                .HasMaxLength(45)
                .HasColumnName("booking_checkout");
            entity.Property(e => e.BookingDays)
                .HasMaxLength(45)
                .HasColumnName("booking_days");
            entity.Property(e => e.BookingId)
                .HasMaxLength(5)
                .HasColumnName("booking_id");
            entity.Property(e => e.BookingPrice)
                .HasMaxLength(45)
                .HasColumnName("booking_price");
            entity.Property(e => e.EmployeeEmployeeId).HasColumnName("employee_employee_id");
            entity.Property(e => e.GuestsEmail)
                .HasMaxLength(45)
                .HasColumnName("guests_email");
            entity.Property(e => e.GuestsFirstname)
                .HasMaxLength(45)
                .HasColumnName("guests_firstname");
            entity.Property(e => e.GuestsGuestsId).HasColumnName("guests_guests_id");
            entity.Property(e => e.GuestsId).HasColumnName("guests_id");
            entity.Property(e => e.GuestsLastname)
                .HasMaxLength(45)
                .HasColumnName("guests_lastname");
            entity.Property(e => e.GuestsMobile)
                .HasMaxLength(45)
                .HasColumnName("guests_mobile");
            entity.Property(e => e.RoomsCapacity).HasColumnName("rooms_capacity");
            entity.Property(e => e.RoomsNr).HasColumnName("rooms_nr");
            entity.Property(e => e.RoomsPrice)
                .HasPrecision(10, 2)
                .HasColumnName("rooms_price");
            entity.Property(e => e.RoomsRoomsNr).HasColumnName("rooms_rooms_nr");
            entity.Property(e => e.RoomsStatus)
                .HasMaxLength(45)
                .HasColumnName("rooms_status");
            entity.Property(e => e.RoomsType)
                .HasMaxLength(45)
                .HasColumnName("rooms_type");
        });

        modelBuilder.Entity<Bookedview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("bookedview");

            entity.Property(e => e.BookId)
                .HasMaxLength(5)
                .HasColumnName("bookId");
            entity.Property(e => e.CheckIn)
                .HasMaxLength(45)
                .HasColumnName("check In");
            entity.Property(e => e.CheckOut)
                .HasMaxLength(45)
                .HasColumnName("check Out");
            entity.Property(e => e.Days).HasMaxLength(45);
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("lastName");
            entity.Property(e => e.Price).HasMaxLength(45);
            entity.Property(e => e.RoomNr).HasColumnName("roomNr");
            entity.Property(e => e.Status).HasMaxLength(45);
            entity.Property(e => e.Type).HasMaxLength(45);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PRIMARY");

            entity.ToTable("booking");

            entity.HasIndex(e => e.EmployeeEmployeeId, "fk_booking_employee1_idx");

            entity.HasIndex(e => e.GuestsGuestsId, "fk_booking_guests1_idx");

            entity.HasIndex(e => e.RoomsRoomsNr, "fk_booking_rooms_idx");

            entity.Property(e => e.BookingId)
                .HasMaxLength(5)
                .HasColumnName("booking_id");
            entity.Property(e => e.BookingCheckin)
                .HasMaxLength(45)
                .HasColumnName("booking_checkin");
            entity.Property(e => e.BookingCheckout)
                .HasMaxLength(45)
                .HasColumnName("booking_checkout");
            entity.Property(e => e.BookingDays)
                .HasMaxLength(45)
                .HasColumnName("booking_days");
            entity.Property(e => e.BookingPrice)
                .HasMaxLength(45)
                .HasColumnName("booking_price");
            entity.Property(e => e.EmployeeEmployeeId).HasColumnName("employee_employee_id");
            entity.Property(e => e.GuestsGuestsId).HasColumnName("guests_guests_id");
            entity.Property(e => e.RoomsRoomsNr).HasColumnName("rooms_rooms_nr");

            entity.HasOne(d => d.EmployeeEmployee).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EmployeeEmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_booking_employee");

            entity.HasOne(d => d.GuestsGuests).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.GuestsGuestsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_booking_guests");

            entity.HasOne(d => d.RoomsRoomsNrNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomsRoomsNr)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_booking_rooms");
        });

        modelBuilder.Entity<Dashboardview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("dashboardview");

            entity.Property(e => e.CheckIn)
                .HasMaxLength(45)
                .HasColumnName("Check In");
            entity.Property(e => e.CheckOut)
                .HasMaxLength(45)
                .HasColumnName("Check Out");
            entity.Property(e => e.Days).HasMaxLength(45);
            entity.Property(e => e.Status).HasMaxLength(45);
            entity.Property(e => e.Type).HasMaxLength(45);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.RoleRoleId, "fk_employee_role1_idx");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(45)
                .HasColumnName("employee_email");
            entity.Property(e => e.EmployeeFirstname)
                .HasMaxLength(45)
                .HasColumnName("employee_firstname");
            entity.Property(e => e.EmployeeLastname)
                .HasMaxLength(45)
                .HasColumnName("employee_lastname");
            entity.Property(e => e.EmployeeMobile)
                .HasMaxLength(45)
                .HasColumnName("employee_mobile");
            entity.Property(e => e.EmployeeSalary)
                .HasPrecision(10, 2)
                .HasColumnName("employee_salary");
            entity.Property(e => e.EmployeeStatus)
                .HasMaxLength(45)
                .HasColumnName("employee_status");
            entity.Property(e => e.RoleRoleId).HasColumnName("role_role_id");

            entity.HasOne(d => d.RoleRole).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleRoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_employee_role");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestsId).HasName("PRIMARY");

            entity.ToTable("guests");

            entity.Property(e => e.GuestsId).HasColumnName("guests_id");
            entity.Property(e => e.GuestsEmail)
                .HasMaxLength(45)
                .HasColumnName("guests_email");
            entity.Property(e => e.GuestsFirstname)
                .HasMaxLength(45)
                .HasColumnName("guests_firstname");
            entity.Property(e => e.GuestsLastname)
                .HasMaxLength(45)
                .HasColumnName("guests_lastname");
            entity.Property(e => e.GuestsMobile)
                .HasMaxLength(45)
                .HasColumnName("guests_mobile");
        });

        modelBuilder.Entity<Reservationtype>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("reservationtype");

            entity.Property(e => e.Booked).HasPrecision(23);
            entity.Property(e => e.RoomsType)
                .HasMaxLength(45)
                .HasColumnName("rooms_type");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(45)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomsNr).HasName("PRIMARY");

            entity.ToTable("rooms");

            entity.Property(e => e.RoomsNr).HasColumnName("rooms_nr");
            entity.Property(e => e.RoomsCapacity).HasColumnName("rooms_capacity");
            entity.Property(e => e.RoomsPrice)
                .HasPrecision(10, 2)
                .HasColumnName("rooms_price");
            entity.Property(e => e.RoomsStatus)
                .HasMaxLength(45)
                .HasColumnName("rooms_status");
            entity.Property(e => e.RoomsType)
                .HasMaxLength(45)
                .HasColumnName("rooms_type");
        });

        modelBuilder.Entity<Roomsview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("roomsview");

            entity.Property(e => e.Available).HasPrecision(23);
            entity.Property(e => e.Booked).HasPrecision(23);
            entity.Property(e => e.CheckIn).HasPrecision(23);
            entity.Property(e => e.CheckOut).HasPrecision(23);
            entity.Property(e => e.RoomService)
                .HasPrecision(23)
                .HasColumnName("Room Service");
            entity.Property(e => e.RoomsType)
                .HasMaxLength(45)
                .HasColumnName("Rooms Type");
        });

        modelBuilder.Entity<Use>(entity =>
        {
            entity.HasKey(e => e.UsesId).HasName("PRIMARY");

            entity.ToTable("uses");

            entity.HasIndex(e => e.EmployeeEmployeeId, "fk_uses_employee1_idx");

            entity.Property(e => e.UsesId).HasColumnName("uses_id");
            entity.Property(e => e.EmployeeEmployeeId).HasColumnName("employee_employee_id");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");

            entity.HasOne(d => d.EmployeeEmployee).WithMany(p => p.Uses)
                .HasForeignKey(d => d.EmployeeEmployeeId)
                .HasConstraintName("fk_uses_employee1");
        });

        modelBuilder.Entity<Viewemployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viewemployees");

            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.FirstName).HasMaxLength(45);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LastName).HasMaxLength(45);
            entity.Property(e => e.Mobile).HasMaxLength(45);
            entity.Property(e => e.Role).HasMaxLength(45);
            entity.Property(e => e.Salary).HasPrecision(10, 2);
            entity.Property(e => e.Status).HasMaxLength(45);
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
