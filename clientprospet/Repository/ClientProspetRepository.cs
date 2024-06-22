using clientprospet.Data;
using clientprospet.Models;
using clientprospet.Repository.IRepository;
using clientprospet.Repository;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
using clientprospet.models;

namespace clientprospet.Repository
{
    public class ClientProspetRepository : Repository<ClientProspet>, IClientProspetRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ApplicationDbContext _context;


        public ClientProspetRepository(ApplicationDbContext db, ApplicationDbContext context) : base(db)
        {
            _context = context;

            _db = db;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddAsync(Adresse adresse)
        {
            _context.Adresses.Add(adresse);
            return await _context.SaveChangesAsync();
        }
        public async Task<ClientProspet> GetByIdAsync(int id)
        {
            return await _context.ClientProspets.FindAsync(id);
        }

        public async Task<ClientProspet> GetByEmailAsync(string email)
        {
            return await _db.ClientProspets.FirstOrDefaultAsync(cp => cp.Email == email);
        }

        public async Task AddAdresseToClientProspect(int clientId, Adresse adresse)
        {
            var clientProspect = await _context.ClientProspets
               .Include(cp => cp.Adresses) // Assurez-vous d'inclure les adresses pour éviter les problèmes de N+1
               .FirstOrDefaultAsync(cp => cp.Id_client == clientId);

            if (clientProspect != null)
            {
                clientProspect.Adresses.Add(adresse);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Client prospect with ID {clientId} not found.");
            }
        }
        public async Task AddMobileClientToClientProspect(int clientId, MobileClient mobileclient)
        {
            var clientProspect = await _context.ClientProspets
               .Include(cp => cp.MobileClient) // Assurez-vous d'inclure les adresses pour éviter les problèmes de N+1
               .FirstOrDefaultAsync(cp => cp.Id_client == clientId);

            if (clientProspect != null)
            {
                clientProspect.MobileClient.Add(mobileclient);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Client prospect with ID {clientId} not found.");
            }
        }
        public async Task AddDocumentsToClientProspect(int clientId, Documents documents)
        {
            var clientProspect = await _context.ClientProspets
               .Include(cp => cp.Documents) // Assurez-vous d'inclure les adresses pour éviter les problèmes de N+1
               .FirstOrDefaultAsync(cp => cp.Id_client == clientId);

            if (clientProspect != null)
            {
                clientProspect.Documents.Add(documents);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Client prospect with ID {clientId} not found.");
            }
        }
       
        public async Task AddMailClientToClientProspect(int clientId, MailClient mailclient)
        {
            var clientProspect = await _context.ClientProspets
               .Include(cp => cp.MailClient) // Assurez-vous d'inclure les adresses pour éviter les problèmes de N+1
               .FirstOrDefaultAsync(cp => cp.Id_client == clientId);

            if (clientProspect != null)
            {
                clientProspect.MailClient.Add(mailclient);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Client prospect with ID {clientId} not found.");
            }
        }
        public async Task AddFATCAToClientProspect(int clientId, FATCA fatca)
        {
            var clientProspect = await _context.ClientProspets
               .Include(cp => cp.FATCA) // Assurez-vous d'inclure les adresses pour éviter les problèmes de N+1
               .FirstOrDefaultAsync(cp => cp.Id_client == clientId);

            if (clientProspect != null)
            {
                clientProspect.FATCA.Add(fatca);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Client prospect with ID {clientId} not found.");
            }
        }
        public async Task AddCINToClientProspect(int clientId, CIN cin)
        {
            var clientProspect = await _context.ClientProspets
               .Include(cp => cp.CIN) // Assurez-vous d'inclure les adresses pour éviter les problèmes de N+1
               .FirstOrDefaultAsync(cp => cp.Id_client == clientId);

            if (clientProspect != null)
            {
                clientProspect.CIN.Add(cin);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Client prospect with ID {clientId} not found.");
            }
        }
        public async Task AddchoixagenceToClientProspect(int clientId, choixagence CHOIXAGENCE)
        {
            var clientProspect = await _context.ClientProspets
               .Include(cp => cp.Choixagence) // Assurez-vous d'inclure les adresses pour éviter les problèmes de N+1
               .FirstOrDefaultAsync(cp => cp.Id_client == clientId);

            if (clientProspect != null)
            {
                clientProspect.Choixagence.Add(CHOIXAGENCE);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Client prospect with ID {clientId} not found.");
            }
        }

        public async Task<ClientProspet> UpdateAsync(ClientProspet entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.ClientProspets.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}


