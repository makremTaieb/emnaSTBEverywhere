using System.ComponentModel.DataAnnotations;

namespace clientprospet.models.Dto
{
    public class ClientProspetStep1CreateDTO
    {
       
        
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mobile { get; set; }
        [EmailAddress(ErrorMessage = "Adresse e-mail non valide.")]
        public string Email { get; set; }
        public string Civilite { get; set; }
        public string PaysDeNaissance { get; set; }
        [DataType(DataType.Date)]

        public DateTime? DateDeNaissance { get; set; }
    }
}
