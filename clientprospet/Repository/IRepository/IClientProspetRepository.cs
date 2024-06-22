using clientprospet.models;
using clientprospet.Models;
using System.Linq.Expressions;

namespace clientprospet.Repository.IRepository
{
    public interface IClientProspetRepository : IRepository<ClientProspet>
    {
        Task<ClientProspet> GetByEmailAsync(string email);
        Task<int> SaveChangesAsync();
        Task<ClientProspet> UpdateAsync(ClientProspet entity);

       // Task<int> AddAsync(Adresse adresse);
        Task<ClientProspet> GetByIdAsync(int id);
        Task AddAdresseToClientProspect(int clientId, Adresse adresse);
        Task AddMobileClientToClientProspect(int clientId, MobileClient mobileclient);
        Task AddDocumentsToClientProspect(int clientId, Documents documents);
        
        Task AddMailClientToClientProspect(int clientId, MailClient mailclient);
        Task AddFATCAToClientProspect(int clientId, FATCA fatca);
        Task AddCINToClientProspect(int clientId, CIN cin);
        Task AddchoixagenceToClientProspect(int clientId, choixagence CHOIXAGENCE);



    }
}
