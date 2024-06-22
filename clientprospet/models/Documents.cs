using clientprospet.Models;
using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class Documents
    {
        [Key]
        public int id_doc { get; set; }
        public string Convention { get; set; }
        public string Contrat { get; set; }
        public string Type { get; set; }
        public int Numéro { get; set; }
        public int ClientId { get; set; } // Clé étrangère vers Client
        public string? Path { get; set; }


        
        public ClientProspet ClientProspet { get; set; } // Navigation property
    }
}
