namespace GestionCommande.DTOs
{
    public class PaiementDto
    {
        public int Id { get; set; }
        public int CommandeId { get; set; }
        public decimal Montant { get; set; }
        public string TypePaiement { get; set; }  
        public string ReferencePaiement { get; set; }
        public string DatePaiement { get; set; } 

        public PaiementDto()
        {
        }

        public bool IsMontantValide()
        {
            return Montant > 0;
        }

        public string StatutPaiement()
        {
            return Montant > 0 ? "Payé" : "Non payé";
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
    }
}
