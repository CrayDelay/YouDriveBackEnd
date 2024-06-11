﻿// <auto-generated />
using System;
using CargoOrderingService.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CargoOrderingService.Migrations
{
    [DbContext(typeof(OrderingContext))]
    partial class OrderingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CargoOrderingService.Domain.Deliveries.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_on");

                    b.Property<string>("DeliveryDate")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("delivery_date");

                    b.Property<string>("DeliveryStatus")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("delivery_status");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("destination_address");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("driver_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("PackageDetails")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("package_details");

                    b.Property<string>("PickupAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pickup_address");

                    b.HasKey("Id")
                        .HasName("pk_deliveries");

                    b.HasIndex("DriverId")
                        .HasDatabaseName("ix_deliveries_driver_id");

                    b.ToTable("deliveries", (string)null);
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Drivers.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_on");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("driver_name");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("LicenseNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("license_number");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_drivers");

                    b.ToTable("drivers", (string)null);
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_on");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("customer_name");

                    b.Property<string>("DeliveryDate")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("delivery_date");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("driver_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("order_number");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<string>("TotalAmount")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("total_amount");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("DriverId")
                        .HasDatabaseName("ix_orders_driver_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("CargoOrderingService.Domain.RolePermissions.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_on");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("Permission")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("permission");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("pk_role_permissions");

                    b.ToTable("role_permissions", (string)null);
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("identifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Users.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_on");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_roles");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_roles_user_id");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Deliveries.Delivery", b =>
                {
                    b.HasOne("CargoOrderingService.Domain.Drivers.Driver", "Driver")
                        .WithMany("Deliveries")
                        .HasForeignKey("DriverId")
                        .HasConstraintName("fk_deliveries_drivers_driver_id");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Orders.Order", b =>
                {
                    b.HasOne("CargoOrderingService.Domain.Drivers.Driver", "Driver")
                        .WithMany("Orders")
                        .HasForeignKey("DriverId")
                        .HasConstraintName("fk_orders_drivers_driver_id");

                    b.HasOne("CargoOrderingService.Domain.Deliveries.Delivery", "Delivery")
                        .WithOne("Order")
                        .HasForeignKey("CargoOrderingService.Domain.Orders.Order", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_deliveries_id");

                    b.Navigation("Delivery");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Users.UserRole", b =>
                {
                    b.HasOne("CargoOrderingService.Domain.Users.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_roles_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Deliveries.Delivery", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Drivers.Driver", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CargoOrderingService.Domain.Users.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
