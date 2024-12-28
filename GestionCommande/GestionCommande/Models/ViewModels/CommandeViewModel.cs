namespace GestionCommande.ViewModels
{
    public class CommandeViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientNom { get; set; }
        public string ClientPrenom { get; set; }
        public string ClientTelephone { get; set; }
        public string Etat { get; set; }  
        public decimal Montant { get; set; }
        public string DateCommande { get; set; }  

        public List<ProduitViewModel> Produits { get; set; } 

        // Constructeur
        public CommandeViewModel()
        {
            Produits = new List<ProduitViewModel>();
        }

        public decimal CalculerTotal()
        {
            return Produits.Sum(p => p.Quantite * p.PrixUnitaire);
        }

        public string FormaterDateCommande
        {
            get
            {
                if (DateTime.TryParse(DateCommande, out var date))
                {
                    return date.ToString("dd/MM/yyyy");
                }
                return DateCommande;  
            }
        }
    }

    public class ProduitViewModel
    {
        public int ProduitId { get; set; }
        public string Libelle { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }

        public decimal CalculerTotalProduit()
        {
            return Quantite * PrixUnitaire;
        }
    }
}
