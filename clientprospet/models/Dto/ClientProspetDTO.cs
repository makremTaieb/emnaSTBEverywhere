using System.ComponentModel.DataAnnotations;
namespace clientprospet.models.Dto
{
    public class ClientProspetDTO
    {
        public int  Id_client { get; set; }
        public string Civilite { get; set; }
        [MaxLength(30)]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mobile { get; set; }
        [EmailAddress(ErrorMessage = "Adresse e-mail non valide.")]
        public string Email { get; set; }
        public string PaysDeNaissance { get; set; }
        [DataType(DataType.Date)]

        public DateTime? DateDeNaissance { get; set; }

        public string? Motif { get; set; }


        public string? Résident { get; set; }



        public int? CodeSécurité { get; set; }


        public string? NationalitéPrincipale { get; set; }


        public string? AutreNationalité { get; set; }


        public string? EtatCivil { get; set; }


        public string? BénéficiaireEffectif { get; set; }


        public string? StatutProfessionnel { get; set; }
        public int? RevenuNetMensuel { get; set; }
        public string? Vousétes { get; set; }
        public string? NatureDeActivité { get; set; }

        public string? Profession { get; set; }
        public int? RNE { get; set; }
        public string? AutreSourceRevenu { get; set; }

        public string? PPE { get; set; }
        public string? Fonction { get; set; }
        public string? PDPUSA { get; set; }
        public string? VPVCEtatsUnis { get; set; }
        public int? TelUS { get; set; }
        public int? GreenCard { get; set; }
        public string? AdresseUS { get; set; }
        public string? FATCA { get; set; }
        public int? CIN { get; set; }
        public string? DateDeDélivrance { get; set; }

        public string? ImageCINVerso { get; set; }

        public string? ImageCINRecto { get; set; }

        public string? ImageSelfie { get; set; }



        public string? TauxCorrespondance { get; set; }



        public string? GouvernoratAgence { get; set; }


        public string? Agence { get; set; }



        public string? TypeCompte { get; set; }

    }
}
