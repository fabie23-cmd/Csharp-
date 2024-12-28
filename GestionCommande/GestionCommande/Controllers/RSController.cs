using System.Linq;
using System.Web.Mvc;
using GestionCommande.Models;  
using GestionCommande.Data;    

namespace GestionCommande.Controllers 
{
    public class RSController : Controller
    {
        private NSAContext db = new NSAContext();

        public ActionResult Index()
        {
            var produits = db.Produits.ToList();
            return View(produits);
        }

        public ActionResult CreerProduit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreerProduit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Produits.Add(produit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produit);
        }

        public ActionResult ModifierProduit(int id)
        {
            var produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifierProduit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produit);
        }

        public ActionResult CommandesEnAttente()
        {
            var commandes = db.Commandes.Where(c => c.Etat == "En attente").ToList();
            return View(commandes);
        }

        public ActionResult LivrerCommande(int id)
        {
            var commande = db.Commandes.Find(id);
            if (commande != null)
            {
                if (commande.Produits.All(p => p.QuantiteEnStock >= p.QuantiteDemandee))
                {
                    commande.Etat = "Prête à livrer";
                    db.SaveChanges();
                }
                else
                {
                    commande.Etat = "En attente"; // Si les produits ne sont pas disponibles
                    db.SaveChanges();
                }
            }
            return RedirectToAction("CommandesEnAttente");
        }

        public ActionResult PlanifierLivraison(int id)
        {
            var commande = db.Commandes.Find(id);
            if (commande != null && commande.Etat == "Prête à livrer")
            {
                ViewBag.Livreurs = new SelectList(db.Livreurs, "Id", "Nom");
                return View(commande);
            }
            return RedirectToAction("CommandesEnAttente");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlanifierLivraison(int id, int livreurId)
        {
            var commande = db.Commandes.Find(id);
            if (commande != null)
            {
                commande.Etat = "Livraison planifiée";
                commande.LivreurId = livreurId;
                db.SaveChanges();
            }
            return RedirectToAction("CommandesEnAttente");
        }

        public ActionResult Livraisons()
        {
            var livraisons = db.Livraisons.Include("Commande").Include("Livreur").ToList();
            return View(livraisons);
        }

        public ActionResult CreerLivraison()
        {
            ViewBag.Commandes = new SelectList(db.Commandes.Where(c => c.Etat == "Livraison planifiée"), "Id", "Date");
            ViewBag.Livreurs = new SelectList(db.Livreurs, "Id", "Nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreerLivraison(Livraison livraison)
        {
            if (ModelState.IsValid)
            {
                db.Livraisons.Add(livraison);
                var commande = db.Commandes.Find(livraison.CommandeId);
                if (commande != null)
                {
                    commande.Etat = "Livrée";
                    db.SaveChanges();
                }
                return RedirectToAction("Livraisons");
            }
            return View(livraison);
        }

        public ActionResult GererStock(int id)
        {
            var produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GererStock(Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produit);
        }
    }
}
