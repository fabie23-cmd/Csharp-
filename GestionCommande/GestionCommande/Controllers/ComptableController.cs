using System.Linq;
using System.Web.Mvc;
using GestionCommande.Models;  
using GestionCommande.Data;   

namespace GestionCommande.Controllers  
{
    public class ComptableController : Controller
    {
        private NSAContext db = new NSAContext();

        public ActionResult Index()
        {
            var commandes = db.Commandes.Where(c => c.Etat == "Livrée").ToList();
            return View(commandes);
        }

        public ActionResult Paiements()
        {
            var paiements = db.Paiements.Include("Commande").ToList();
            return View(paiements);
        }

        public ActionResult HistoriquePaiements()
        {
            var paiements = db.Paiements.ToList();
            return View(paiements);
        }

        public ActionResult RegulariserPaiement(int id)
        {
            var paiement = db.Paiements.Find(id);
            if (paiement != null)
            {
                var client = db.Clients.Find(paiement.Commande.ClientId);
                if (client != null)
                {
                    client.Solde -= paiement.Montant;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Paiements");
        }
    }
}
