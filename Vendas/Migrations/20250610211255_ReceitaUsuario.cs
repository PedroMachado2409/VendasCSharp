﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vendas.Migrations
{
    /// <inheritdoc />
    public partial class ReceitaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Receitas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_UsuarioId",
                table: "Receitas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Usuarios_UsuarioId",
                table: "Receitas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Usuarios_UsuarioId",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Receitas_UsuarioId",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Receitas");
        }
    }
}
