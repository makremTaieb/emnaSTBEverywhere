using static ClientProspetWeb_utility.SD;
namespace clientprospetweb.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public string Data { get; set; }
    }
}
