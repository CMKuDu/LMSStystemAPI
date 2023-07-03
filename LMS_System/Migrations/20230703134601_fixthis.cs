using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_System.Migrations
{
    /// <inheritdoc />
    public partial class fixthis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Anwsers_Question_QuesId",
                table: "Anwsers");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Classes_Users_UserId",
                table: "User_Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "QuesId",
                table: "Anwsers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Anwsers_QuesId",
                table: "Anwsers",
                newName: "IX_Anwsers_QuestionId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "User",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LocationId",
                table: "User",
                newName: "IX_User_RolesId");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenCreated",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpries",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpries",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifyAt",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExamId",
                table: "Question",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_User_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anwsers_Question_QuestionId",
                table: "Anwsers",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Exam_ExamId",
                table: "Question",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "EmxamId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_RolesId",
                table: "User",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "RolesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Classes_User_UserId",
                table: "User_Classes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_User_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Anwsers_Question_QuestionId",
                table: "Anwsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Exam_ExamId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_RolesId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Classes_User_UserId",
                table: "User_Classes");

            migrationBuilder.DropIndex(
                name: "IX_Question_ExamId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshTokenCreated",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpries",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpries",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VerifyAt",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Anwsers",
                newName: "QuesId");

            migrationBuilder.RenameIndex(
                name: "IX_Anwsers_QuestionId",
                table: "Anwsers",
                newName: "IX_Anwsers_QuesId");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "Users",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_User_RolesId",
                table: "Users",
                newName: "IX_Users_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anwsers_Question_QuesId",
                table: "Anwsers",
                column: "QuesId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Classes_Users_UserId",
                table: "User_Classes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
