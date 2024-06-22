//using clientprospet.models.Dto;
using clientprospet.models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clientprospet.Models
{
    public class ClientProspet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_client { get; set; }
        public string Civilite { get; set; }
        public ICollection<Adresse>? Adresses { get; set; } = new List<Adresse>();
         public ICollection<MobileClient>? MobileClient { get; set; } = new List<MobileClient>();
        public ICollection<Documents>? Documents { get; set; } = new List<Documents>();
        
        public ICollection<MailClient>? MailClient { get; set; } = new List<MailClient>();
        public ICollection<FATCA>? FATCA { get; set; } = new List<FATCA>();
        public ICollection<CIN>? CIN { get; set; } = new List<CIN>();
        public ICollection<choixagence>? Choixagence { get; set; } = new List<choixagence>();
        [Required]
        public string Nom { get; set; }
        public  string Prenom { get; set; }
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
        
        public string? NatureDeActivité { get; set; }

        public string? Profession { get; set; }
        public int? RNE { get; set; }
        public string? AutreSourceRevenu { get; set; }
       public string? Agence { get; set; }
        public string? CodeDR  { get; set; }
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



        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
