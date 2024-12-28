using System.Collections.Generic;

namespace GestionCommande.Repositories
{
    public interface ICommandeRepository : IRepository<Commande>
    {
        IEnumerable<Commande> GetByStatus(string status);

        IEnumerable<Commande> GetByClientId(int clientId);
    }
}