using System.ComponentModel.DataAnnotations;
namespace clientprospet.models.Dto
{
    public class ClientProspetUpdateDTO
    {
        //[Required]
        public int  Id_client { get; set; }
        //[Required]
        public string Civilite { get; set; }
        //[Required]
        [MaxLength(30)]
        public string Nom { get; set; }
        //[Required]
        public string Prenom { get; set; }
       // [Required]
        public string Mobile { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        public string PaysDeNaissance { get; set; }
        //[Required]
        [DataType(DataType.Date)]

        public DateTime? DateDeNaissance { get; set; }
        [Required]
       
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
       
        public string? CodeDR { get; set; }
        public string? DR { get; set; }
        public int? Adresse_key { get; set; }
        public float? Lattitude { get; set; }
        public float? Longitude { get; set; }
        public string? Code_gov { get; set; }
        public int? Code_postal { get; set; }

        public string? Gouvernorat { get; set; }
        public string? Adresse_mail { get; set; }
        public string? Matricule_chefagence { get; set; }
        public int? Tel1 { get; set; }
        public int? Tel2 { get; set; }
        public int? Fax { get; set; }

        public int? GSM { get; set; }
        public string? Adresse { get; set; }
        public string? Localisation { get; set; }

        // public object Nom { get; internal set; }

    }
}
