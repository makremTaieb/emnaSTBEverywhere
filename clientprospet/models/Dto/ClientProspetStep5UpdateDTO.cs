using System.ComponentModel.DataAnnotations;

namespace clientprospet.models.Dto
{
    public class ClientProspetStep5UpdateDTO
    {
        [Required]
        public int Id_client { get; set; }
        public string PPE { get; set; }
        public string Fonction { get; set; }
        public string PDPUSA { get; set; }
        public string VPVCEtatsUnis { get; set; }
        public int TelUS { get; set; }
        public int GreenCard { get; set; }
        public string AdresseUS { get; set; }
        public string FATCA { get; set; }
    }
}
