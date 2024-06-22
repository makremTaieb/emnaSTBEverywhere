using clientprospet.Models;
using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class FATCA
    {
        [Key]
        public int idFATCA { get; set; }
        public string? PDPUSA { get; set; }
        public string? VPVCEtatsUnis { get; set; }
        public int? TelUS { get; set; }
        public int? GreenCard { get; set; }
        public string? AdresseUS { get; set; }
        public int ClientId { get; set; } // Clé étrangère vers Client
        public ClientProspet ClientProspet { get; set; } // Navigation property
    }
}
