using clientprospetweb.models;
using clientprospetweb.Models;

namespace clientprospetweb.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
