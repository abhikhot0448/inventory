using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dhanman.money.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class billHeaders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bill_headers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vendor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    coa_id = table.Column<Guid>(type: "uuid", nullable: false),
                    discount = table.Column<decimal>(type: "numeric", nullable: false),
                    bill_number = table.Column<string>(type: "text", nullable: false),
                    currency = table.Column<string>(type: "text", nullable: false),
                    bill_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    payment_term = table.Column<int>(type: "integer", nullable: true),
                    bill_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bill_payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    due_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    tax = table.Column<decimal>(type: "numeric", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on_utc = table.Column<DateTime>(type: "timestamp", nullable: false),
                    modified_on_utc = table.Column<DateTime>(type: "timestamp", nullable: true),
                    deleted_on_utc = table.Column<DateTime>(type: "timestamp", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bill_headers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bill_headers");
        }
    }
}
