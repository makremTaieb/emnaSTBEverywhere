using System.ComponentModel.DataAnnotations;

namespace clientprospet.models.Dto
{
    public class ClientProspetStep3UpdateDTO
    {
        [Required]
        public int Id_client { get; set; }
        public string NationalitéPrincipale { get; set; }


        public string AutreNationalité { get; set; }


        public string EtatCivil { get; set; }


        public string BénéficiaireEffectif { get; set; }
    }
}
