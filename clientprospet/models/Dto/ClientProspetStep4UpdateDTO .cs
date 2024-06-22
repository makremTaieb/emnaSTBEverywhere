using System.ComponentModel.DataAnnotations;

namespace clientprospet.models.Dto
{
    public class ClientProspetStep4UpdateDTO
    {
        [Required]
        public int Id_client { get; set; }
        public string StatutProfessionnel { get; set; }
        public int RevenuNetMensuel { get; set; }
        public string Vousétes { get; set; }
        public string NatureDeActivité { get; set; }

        public string Profession { get; set; }
        public int RNE { get; set; }
        public string AutreSourceRevenu { get; set; }

    }
}
