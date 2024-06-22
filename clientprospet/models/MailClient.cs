using clientprospet.Models;
using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class MailClient
    {
        [Key]

        public int id_mobileclient { get; set; }
        [EmailAddress(ErrorMessage = "Adresse e-mail non valide.")]
        public string Email { get; set; }
        public string Default { get; set; }
        public int ClientId { get; set; } // Clé étrangère vers Client
        public string Qualification { get; set; }
        public int Statut { get; set; }
        public ClientProspet ClientProspet { get; set; } // Navigation property
    }
}
