using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class MobileClientDTO
    {
        [Key]
        public int id_MobileClient { get; set; }
        public int Numérotéléphone { get; set; }
        public int Default { get; set; }
        public string Qualification { get; set; }
        
        public int Statut { get; set; }
    }
}
