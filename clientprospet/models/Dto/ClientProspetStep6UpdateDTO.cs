using System.ComponentModel.DataAnnotations;

namespace clientprospet.models.Dto
{
    public class ClientProspetStep6UpdateDTO
    {
        [Required]
        public int Id_client { get; set; }
        public int CIN { get; set; }
        public string DateDeDélivrance { get; set; }

        public string ImageCINVerso { get; set; }

        public string ImageCINRecto { get; set; }

        public string ImageSelfie { get; set; }



        public string TauxCorrespondance { get; set; }
    }
}
