using clientprospet.Models;
using System.ComponentModel.DataAnnotations;

namespace clientprospet.models
{
    public class choixagence
    {
        [Key]

        public int CodeAgence { get; set; }
        public string Agence { get; set; }
        public string CodeDR { get; set; }
        public string DR { get; set; }
        public int Adresse_key { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public string Code_gov { get; set; }
        public int Code_postal { get; set; }

        public string Gouvernorat { get; set; }
        public string Adresse_mail { get; set; }
        public string Matricule_chefagence { get; set; }
        public int Tel1 { get; set; }
        public int Tel2 { get; set; }
        public int Fax { get; set; }

        public int GSM { get; set; }
        public string Adresse { get; set; }
        public string Localisation { get; set; }
        public ClientProspet ClientProspet { get; set; } // Navigation property
        public int ClientId { get; set; } // Clé étrangère vers Client
    }
}
