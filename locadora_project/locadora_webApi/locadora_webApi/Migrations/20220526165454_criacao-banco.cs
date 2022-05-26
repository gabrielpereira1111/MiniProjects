using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace locadora_webApi.Migrations
{
    public partial class criacaobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    idEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.idEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    idMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.idMarca);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuario",
                columns: table => new
                {
                    idTiposUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.idTiposUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    idModelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(300)", nullable: false),
                    idMarca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.idModelo);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_idMarca",
                        column: x => x.idMarca,
                        principalTable: "Marcas",
                        principalColumn: "idMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "Varchar(200)", nullable: false),
                    Senha = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    IdTiposUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuario_IdTiposUsuario",
                        column: x => x.IdTiposUsuario,
                        principalTable: "TiposUsuario",
                        principalColumn: "idTiposUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    idVeiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEmpresa = table.Column<int>(type: "int", nullable: false),
                    idModelo = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "Char(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.idVeiculo);
                    table.ForeignKey(
                        name: "FK_Veiculos_Empresas_idEmpresa",
                        column: x => x.idEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "idEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculos_Modelos_idModelo",
                        column: x => x.idModelo,
                        principalTable: "Modelos",
                        principalColumn: "idModelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", nullable: false),
                    Cpf = table.Column<string>(type: "Char(11)", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alugueis",
                columns: table => new
                {
                    idAluguel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVeiculo = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "Date", nullable: false),
                    DataFim = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alugueis", x => x.idAluguel);
                    table.ForeignKey(
                        name: "FK_Alugueis_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alugueis_Veiculos_IdVeiculo",
                        column: x => x.IdVeiculo,
                        principalTable: "Veiculos",
                        principalColumn: "idVeiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "idEmpresa", "Nome" },
                values: new object[] { 1, "Locadora de Carros" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "idMarca", "Nome" },
                values: new object[,]
                {
                    { 1, "Chevrolet" },
                    { 2, "Fiat" }
                });

            migrationBuilder.InsertData(
                table: "TiposUsuario",
                columns: new[] { "idTiposUsuario", "Nome" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Comum" }
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "idModelo", "Descricao", "Nome", "idMarca" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.", "Argo", 2 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.", "Cronos", 2 },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.", "Camaro", 1 },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac hendrerit velit. In ultrices non justo at accumsan. Etiam vitae augue posuere turpis condimentum cursus.", "Cruzer", 1 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "Email", "IdTiposUsuario", "Senha" },
                values: new object[,]
                {
                    { 1, "admin@email.com", 1, "1234" },
                    { 2, "comum@email.com", 2, "1234" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "idCliente", "Cpf", "Nome", "idUsuario" },
                values: new object[,]
                {
                    { 1, "00000000000", "Administrador", 1 },
                    { 2, "47612984835", "Comum", 2 }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "idVeiculo", "Placa", "idEmpresa", "idModelo" },
                values: new object[,]
                {
                    { 1, "5679203", 1, 1 },
                    { 2, "6781314", 1, 2 },
                    { 3, "6570103", 1, 2 },
                    { 4, "7683029", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "idAluguel", "DataFim", "DataInicio", "IdCliente", "IdVeiculo" },
                values: new object[] { 1, new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "Alugueis",
                columns: new[] { "idAluguel", "DataFim", "DataInicio", "IdCliente", "IdVeiculo" },
                values: new object[] { 2, new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_IdCliente",
                table: "Alugueis",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alugueis_IdVeiculo",
                table: "Alugueis",
                column: "IdVeiculo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cpf",
                table: "Clientes",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_idUsuario",
                table: "Clientes",
                column: "idUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Nome",
                table: "Empresas",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_Nome",
                table: "Marcas",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_idMarca",
                table: "Modelos",
                column: "idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_TiposUsuario_Nome",
                table: "TiposUsuario",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTiposUsuario",
                table: "Usuarios",
                column: "IdTiposUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_idEmpresa",
                table: "Veiculos",
                column: "idEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_idModelo",
                table: "Veiculos",
                column: "idModelo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_Placa",
                table: "Veiculos",
                column: "Placa",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alugueis");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "TiposUsuario");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
