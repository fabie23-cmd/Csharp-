namespace GestionCommande.Models
{
    public class Livreur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }

        public List<Livraison> Livraisons { get; set; }

        public Livreur()
        {
            Livraisons = new List<Livraison>();
        }

        public void PlanifierLivraison(Livraison livraison)
        {
            Livraisons.Add(livraison);
        }
    }
}
