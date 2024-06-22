using System.ComponentModel.DataAnnotations;

namespace clientprospet.Models
{
    public class Adresse

    {
        [Key]
        
        public int Pkad { get; set; }
        public string Gouvernorat { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public int CodePostal { get; set; }
        public int ClientId { get; set; } // Clé étrangère vers Client
        public int? Numéro { get; set; }
        public string? Rue { get; set; }
        public ClientProspet ClientProspet { get; set; } // Navigation property
    }
}
