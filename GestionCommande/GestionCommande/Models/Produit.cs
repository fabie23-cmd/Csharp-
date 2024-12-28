namespace GestionCommande.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int QuantiteEnStock { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int QuantiteSeuil { get; set; }

        public List<CommandeProduit> CommandesProduits { get; set; }

        // Constructeur
        public Produit()
        {
            CommandesProduits = new List<CommandeProduit>();
        }

        public bool EstDisponible(int quantiteDemandee)
        {
            return QuantiteEnStock >= quantiteDemandee;
        }

        public void MettreAJourStock(int quantiteVendue)
        {
            QuantiteEnStock -= quantiteVendue;
        }
    }
}
