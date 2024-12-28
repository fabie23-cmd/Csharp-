namespace GestionCommande.ViewModels
{
    public class PaiementViewModel
    {
        public int Id { get; set; }
        public int CommandeId { get; set; }
        public decimal Montant { get; set; }
        public string TypePaiement { get; set; }  
        public string DatePaiement { get; set; } 

        public PaiementViewModel()
        {
        }

        public string FormaterDatePaiement
        {
            get
            {
                if (DateTime.TryParse(DatePaiement, out var date))
                {
                    return date.ToString("dd/MM/yyyy");
                }
                return DatePaiement;  
            }
        }
=
        public string StatutPaiement()
        {
            return Montant > 0 ? "Payé" : "Non payé";
        }

        public bool IsMontantValide()
        {
            return Montant > 0;
        }
    }
}
