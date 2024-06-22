using clientprospetweb.models.Dto;

namespace clientprospetweb.Services.IServices
{
    public interface IClientProspetService
    {
        Task<T>GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(clientprospetCreateDTO dto);
        Task<T> UpdateAsync<T>(clientprospetUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);

    }
}
