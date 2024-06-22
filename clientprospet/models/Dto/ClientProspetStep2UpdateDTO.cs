using System.ComponentModel.DataAnnotations;

namespace clientprospet.models.Dto
{
    public class ClientProspetStep2UpdateDTO
    {
        [Required]
        public int Id_client { get; set; }
        
        public string Motif { get; set; }


        public string Résident { get; set; }



       
    }
}
