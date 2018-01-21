using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATMSData.Migrations
{
    public partial class Iwillalwaysloveu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryAndAccident_AccidentRecords_AccidentRecordId",
                table: "FactoryAndAccident");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryAndAccident_Factories_FactoryId",
                table: "FactoryAndAccident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactoryAndAccident",
                table: "FactoryAndAccident");

            migrationBuilder.RenameTable(
                name: "FactoryAndAccident",
                newName: "Factors");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryAndAccident_FactoryId",
                table: "Factors",
                newName: "IX_Factors_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factors",
                table: "Factors",
                columns: new[] { "AccidentRecordId", "FactoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Factors_AccidentRecords_AccidentRecordId",
                table: "Factors",
                column: "AccidentRecordId",
                principalTable: "AccidentRecords",
                principalColumn: "AccidentRecordID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Factors_Factories_FactoryId",
                table: "Factors",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "FactorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factors_AccidentRecords_AccidentRecordId",
                table: "Factors");

            migrationBuilder.DropForeignKey(
                name: "FK_Factors_Factories_FactoryId",
                table: "Factors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factors",
                table: "Factors");

            migrationBuilder.RenameTable(
                name: "Factors",
                newName: "FactoryAndAccident");

            migrationBuilder.RenameIndex(
                name: "IX_Factors_FactoryId",
                table: "FactoryAndAccident",
                newName: "IX_FactoryAndAccident_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactoryAndAccident",
                table: "FactoryAndAccident",
                columns: new[] { "AccidentRecordId", "FactoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryAndAccident_AccidentRecords_AccidentRecordId",
                table: "FactoryAndAccident",
                column: "AccidentRecordId",
                principalTable: "AccidentRecords",
                principalColumn: "AccidentRecordID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryAndAccident_Factories_FactoryId",
                table: "FactoryAndAccident",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "FactorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
