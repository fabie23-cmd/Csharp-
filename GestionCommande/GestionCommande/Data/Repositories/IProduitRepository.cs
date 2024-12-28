using System.Collections.Generic;

namespace GestionCommande.Repositories
{
    public interface IProduitRepository : IRepository<Produit>
    {
        
        Produit GetByLibelle(string libelle);

        IEnumerable<Produit> GetLowStockProducts();
    }
}