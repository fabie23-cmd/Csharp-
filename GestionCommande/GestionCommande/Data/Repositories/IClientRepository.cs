using System.Collections.Generic;

namespace GestionCommande.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetByPhone(string phone);

        IEnumerable<Client> GetClientsWithUnpaidOrders();
    }
}