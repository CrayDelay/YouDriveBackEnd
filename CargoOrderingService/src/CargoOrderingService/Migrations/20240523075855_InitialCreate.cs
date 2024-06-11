using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoOrderingService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    driver_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    license_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    last_modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    last_modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    last_modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    delivery_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pickup_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destination_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    package_details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delivery_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    driver_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    last_modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deliveries", x => x.id);
                    table.ForeignKey(
                        name: "fk_deliveries_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    last_modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delivery_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    driver_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified_on = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    last_modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_deliveries_id",
                        column: x => x.id,
                        principalTable: "deliveries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orders_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_deliveries_driver_id",
                table: "deliveries",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_driver_id",
                table: "orders",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id",
                table: "user_roles",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "deliveries");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "drivers");
        }
    }
}
