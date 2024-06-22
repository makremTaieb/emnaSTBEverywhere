using clientprospet.Models;
using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class MobileClient
    {
        [Key]
        public int id_MobileClient { get; set; }
        public int Numérotéléphone { get; set; }
        public int Default { get; set; }
        public string Qualification { get; set; }
        public int ClientId { get; set; } // Clé étrangère vers Client
        public int Statut { get; set; }
        public ClientProspet ClientProspet { get; set; } // Navigation property

    }
}
