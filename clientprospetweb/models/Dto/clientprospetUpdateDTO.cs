using System.ComponentModel.DataAnnotations;
namespace clientprospetweb.models.Dto
{
    public class clientprospetUpdateDTO
    {
        [Required]
        public int  Id_client { get; set; }
        [Required]
        public string Civilite { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PaysDeNaissance { get; set; }
        [Required]
        public string DateDeNaissance { get; set; }
        [Required]
        public string Motif { get; set; }
        [Required]
        public string Nationalite { get; set; }
        [Required]
        public int pk_ad { get; set; }
        [Required]
        public string Revenu { get; set; }
        [Required]
        public string Fonction { get; set; }
        
        public int NumeroDeLaBanque { get; set; }
        
        public int Etat { get; set; }
        
        public int NumeroDeCompte { get; set; }
        public string Gouvernorat { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string Numéro { get; set; }
        public string Rue { get; set; }
        public string Résidence { get; set; }

    }
}
