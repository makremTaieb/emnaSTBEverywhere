using clientprospet.Models;
using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class MailClientDTO
    {
       

        public int id_mailclient { get; set; }
        [EmailAddress(ErrorMessage = "Adresse e-mail non valide.")]
        public string Email { get; set; }
        public string Default { get; set; }
       
        public string Qualification { get; set; }
        public int Statut { get; set; }
        
    }
}
