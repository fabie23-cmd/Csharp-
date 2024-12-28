using System.ComponentModel.DataAnnotations;

namespace GestionCommande.Models;

public class Paiement
{


  public int Id { get; set; }
  public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
  [Range(1, float.MaxValue, ErrorMessage = "Seul un montant positif est autorisé")]
  public float Montant { get; set; }


  public Commande commande { get; set; }
  public int CommandeId { get; set; }









}
