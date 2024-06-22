using clientprospetweb.models.Dto;
using clientprospetweb.Models;
using clientprospetweb.Services.IServices;
using ClientProspetWeb_utility;

namespace clientprospetweb.Services
{
    public class ClientProspetService : BaseService, IClientProspetService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string clientprospetUrl;
        public ClientProspetService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            clientprospetUrl = configuration.GetValue<string>("ServiceUrls:ClientProspetAPI");
        }

        public Task<T> CreateAsync<T>(clientprospetCreateDTO dto)

        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = clientprospetUrl + "/api/clientprospet"

            });
        }
        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = clientprospetUrl + "/api/clientprospet/"+id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = clientprospetUrl + "/api/clientprospet"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = clientprospetUrl + "/api/clientprospet/" + id

            });
        }

        public Task<T> UpdateAsync<T>(clientprospetUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = clientprospetUrl + "/api/clientprospet/" + dto.Id_client

            });
        }
    }
}
