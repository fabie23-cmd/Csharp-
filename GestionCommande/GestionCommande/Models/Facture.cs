namespace GestionCommande.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public decimal MontantTotal { get; set; } 
        public DateTime DateEmission { get; set; } 
        public string Statut { get; set; }  

        public Facture()
        {
        }

        public void GenererFacture()
        {
            MontantTotal = Commande.CalculerMontantTotal();
            DateEmission = DateTime.Now;
            Statut = "En cours";  
        }

        public void MarquerCommePayee()
        {
            Statut = "Payée";
        }

        public void MarquerCommeImpayee()
        {
            Statut = "Impayée";
        }
    }
}
