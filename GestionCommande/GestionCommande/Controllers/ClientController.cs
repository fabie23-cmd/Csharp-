using System.Linq;
using System.Web.Mvc;
using GestionCommande.Models;  
using GestionCommande.Data;    

namespace GestionCommande.Controllers  
{
    public class ClientController : Controller
    {
        private NSAContext db = new NSAContext();

        public ActionResult Index()
        {
            var clients = db.Clients.ToList();
            return View(clients);
        }

        public ActionResult Creer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creer(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ActionResult Details(int id)
        {
            var client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult HistoriqueCommandes(int id)
        {
            var commandes = db.Commandes.Where(c => c.ClientId == id).ToList();
            return View(commandes);
        }

        public ActionResult Modifier(int id)
        {
            var client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }
    }
}
