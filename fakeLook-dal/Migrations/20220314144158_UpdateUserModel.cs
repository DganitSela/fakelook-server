using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fakeLook_dal.Migrations
{
    public partial class UpdateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1788), 45.705712122117106, 38.622266450264256, 28.336899149219818 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1834), 39.023416258127924, 41.129544628942853, 28.695917167550043 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1837), 35.084934589738168, 14.162629815412735, 34.480150819152435 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1839), 29.457071865358099, 0.92772590207340633, 37.58119120199197 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1842), 8.5120322719778709, 10.658921742199279, 46.40667323190565 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 19, 3 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 15, 3 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 9, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 14, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 9, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 12, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CommentId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 18, 3 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CommentId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "-1024888312");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "-1024888312");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "-1024888312");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "-1024888312");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "-1024888312");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 35, 11, 777, DateTimeKind.Local).AddTicks(9243), 16.723500631838682, 19.736907173149298, 21.165524396780476 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 35, 11, 777, DateTimeKind.Local).AddTicks(9283), 48.361986170070921, 35.870076330127688, 7.1181706962457625 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 35, 11, 777, DateTimeKind.Local).AddTicks(9286), 35.106115464464033, 34.930456539947428, 47.148794905902562 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 35, 11, 777, DateTimeKind.Local).AddTicks(9288), 14.393341745927085, 44.417540703477556, 35.246293606270513 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "X_Position", "Y_Position", "Z_Position" },
                values: new object[] { new DateTime(2022, 3, 14, 16, 35, 11, 777, DateTimeKind.Local).AddTicks(9290), 11.951686612599993, 10.310676198267748, 4.7655154033649225 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 21, 4 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 22, 3 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 7, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 15, 5 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 22, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CommentId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CommentId", "UserId" },
                values: new object[] { 6, 1 });

            migrationBuilder.UpdateData(
                table: "UserTaggedComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CommentId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "-1756091313");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "-1756091313");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "-1756091313");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "-1756091313");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "-1756091313");
        }
    }
}
