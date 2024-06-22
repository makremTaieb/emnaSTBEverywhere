namespace clientprospet.models
{
    public class DocumentDTO
    {
        public int id_doc { get; set; }
        public string Convention { get; set; }
        public string Contrat { get; set; }
        public string Type { get; set; }
        public int Numéro { get; set; }
        
        public string? Path { get; set; }
    }
}
