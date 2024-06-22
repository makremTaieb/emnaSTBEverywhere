using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class PPE
    {
        [Key]
        public int Id_client { get; set; }
        public string ÊtesVousPPE { get; set; }
        public string Fonction { get; set; }
    }
}
