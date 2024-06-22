using System.ComponentModel.DataAnnotations;
namespace clientprospetweb.models.Dto
{
    public class clientprospetDTO
    {
        public int  Id_client { get; set; }
        public string Civilite { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PaysDeNaissance { get; set; }
        public string DateDeNaissance { get; set; }
        public string Motif { get; set; }
        public string Nationalite { get; set; }
        public int pk_ad { get; set; }
        public string Revenu { get; set; }
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

        // public object Nom { get; internal set; }

    }
}
