using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clientprospet.Migrations
{
    /// <inheritdoc />
    public partial class initial_create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientProspets",
                columns: table => new
                {
                    Id_client = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Civilite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaysDeNaissance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Résident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeSécurité = table.Column<int>(type: "int", nullable: true),
                    NationalitéPrincipale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutreNationalité = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EtatCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BénéficiaireEffectif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutProfessionnel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenuNetMensuel = table.Column<int>(type: "int", nullable: true),
                    NatureDeActivité = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RNE = table.Column<int>(type: "int", nullable: true),
                    AutreSourceRevenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_key = table.Column<int>(type: "int", nullable: true),
                    Lattitude = table.Column<float>(type: "real", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: true),
                    Code_gov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code_postal = table.Column<int>(type: "int", nullable: true),
                    Gouvernorat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule_chefagence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel1 = table.Column<int>(type: "int", nullable: true),
                    Tel2 = table.Column<int>(type: "int", nullable: true),
                    Fax = table.Column<int>(type: "int", nullable: true),
                    GSM = table.Column<int>(type: "int", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProspets", x => x.Id_client);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Pkad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gouvernorat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostal = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Numéro = table.Column<int>(type: "int", nullable: true),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Pkad);
                    table.ForeignKey(
                        name: "FK_Adresses_ClientProspets_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientProspets",
                        principalColumn: "Id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoixAgences",
                columns: table => new
                {
                    CodeAgence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_key = table.Column<int>(type: "int", nullable: false),
                    Lattitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Code_gov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code_postal = table.Column<int>(type: "int", nullable: false),
                    Gouvernorat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule_chefagence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel1 = table.Column<int>(type: "int", nullable: false),
                    Tel2 = table.Column<int>(type: "int", nullable: false),
                    Fax = table.Column<int>(type: "int", nullable: false),
                    GSM = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoixAgences", x => x.CodeAgence);
                    table.ForeignKey(
                        name: "FK_ChoixAgences_ClientProspets_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientProspets",
                        principalColumn: "Id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CIN",
                columns: table => new
                {
                    idCIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    NuméroCIN = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prénom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LieuDeNaissance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomEtPrénomDeMére = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emploi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeDélivrance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIN", x => x.idCIN);
                    table.ForeignKey(
                        name: "FK_CIN_ClientProspets_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientProspets",
                        principalColumn: "Id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    id_doc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Convention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numéro = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.id_doc);
                    table.ForeignKey(
                        name: "FK_Documents_ClientProspets_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientProspets",
                        principalColumn: "Id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FATCA",
                columns: table => new
                {
                    idFATCA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PDPUSA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VPVCEtatsUnis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelUS = table.Column<int>(type: "int", nullable: true),
                    GreenCard = table.Column<int>(type: "int", nullable: true),
                    AdresseUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FATCA", x => x.idFATCA);
                    table.ForeignKey(
                        name: "FK_FATCA_ClientProspets_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientProspets",
                        principalColumn: "Id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MailClient",
                columns: table => new
                {
                    id_mobileclient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Default = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailClient", x => x.id_mobileclient);
                    table.ForeignKey(
                        name: "FK_MailClient_ClientProspets_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientProspets",
                        principalColumn: "Id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mobiles",
                columns: table => new
                {
                    id_MobileClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numérotéléphone = table.Column<int>(type: "int", nullable: false),
                    Default = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Statut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mobiles", x => x.id_MobileClient);
                    table.ForeignKey(
                        name: "FK_mobiles_ClientProspets_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientProspets",
                        principalColumn: "Id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ClientId",
                table: "Adresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoixAgences_ClientId",
                table: "ChoixAgences",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CIN_ClientId",
                table: "CIN",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ClientId",
                table: "Documents",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_FATCA_ClientId",
                table: "FATCA",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MailClient_ClientId",
                table: "MailClient",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_mobiles_ClientId",
                table: "mobiles",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "ChoixAgences");

            migrationBuilder.DropTable(
                name: "CIN");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "FATCA");

            migrationBuilder.DropTable(
                name: "MailClient");

            migrationBuilder.DropTable(
                name: "mobiles");

            migrationBuilder.DropTable(
                name: "ClientProspets");
        }
    }
}
