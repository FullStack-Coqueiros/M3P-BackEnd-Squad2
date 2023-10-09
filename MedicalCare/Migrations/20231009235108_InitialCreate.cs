using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCare.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PontoDeReferencia = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dominio = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Naturalidade = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ContatoDeEmergencia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuidados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Convenio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDoConvenio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidadeDoConvenio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome_completo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_do_Sistema = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TELEFONE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    Nome_completo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_do_Sistema = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoDaConsulta = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    DataDaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioDaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoDoProblema = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: false),
                    MedicacaoReceitada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosagemEPrecaucoes = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    StatusDoSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteModel = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteModel",
                        column: x => x.PacienteModel,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dietas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaDieta = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    DescricaoDaDietaExecutada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDoSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteModel = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dietas_Pacientes_PacienteModel",
                        column: x => x.PacienteModel,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dietas_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoExame = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    DataDoExame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioDoExame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDoExame = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    Laboratorio = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    UrlDoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultados = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: false),
                    StatusDoSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteModel = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_Pacientes_PacienteModel",
                        column: x => x.PacienteModel,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exames_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaSerieDeExercicios = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    QuantidadePorSemana = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StatusNoSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteModel = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Pacientes_PacienteModel",
                        column: x => x.PacienteModel,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercicios_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomedoMedicamento = table.Column<string>(name: "Nome do Medicamento", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opções = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observações = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StatusdoSistema = table.Column<bool>(name: "Status do Sistema", type: "bit", nullable: false),
                    PacienteModel = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamentos_Pacientes_PacienteModel",
                        column: x => x.PacienteModel,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicamentos_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteModel",
                table: "Consultas",
                column: "PacienteModel");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_UsuarioId",
                table: "Consultas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dietas_PacienteModel",
                table: "Dietas",
                column: "PacienteModel");

            migrationBuilder.CreateIndex(
                name: "IX_Dietas_UsuarioId",
                table: "Dietas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteModel",
                table: "Exames",
                column: "PacienteModel");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_UsuarioId",
                table: "Exames",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_PacienteModel",
                table: "Exercicios",
                column: "PacienteModel");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_UsuarioId",
                table: "Exercicios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_PacienteModel",
                table: "Medicamentos",
                column: "PacienteModel");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_UsuarioId",
                table: "Medicamentos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Dietas");

            migrationBuilder.DropTable(
                name: "EnderecoModel");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
