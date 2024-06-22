using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class CINDTO
    {
        public int idCIN { get; set; }
        public int NuméroCIN { get; set; }
        public string? Nom { get; set; }
        public string? Prénom { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateDeNaissance { get; set; }
        public string? LieuDeNaissance { get; set; }
        public string? NomEtPrénomDeMére { get; set; }
        public string? Emploi { get; set; }
        public string? Adresse { get; set; }
        public string? DateDeDélivrance { get; set; }
        public string? Image { get; set; }
    }
}
