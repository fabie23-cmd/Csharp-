using System.ComponentModel.DataAnnotations;
using GestionCommande.Services;

namespace GestionCommande.Validator;

public class UniqueNomAttribute : ValidationAttribute
{

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var clientService = (IClientService)validationContext.GetService(typeof(IClientService));
        var nom = (string)value;

        if (clientService.GetClientsAsync().Result.Any(c => c.Nom == Nom))
        {
            return new ValidationResult("Ce nom est déjà utilisé.");
        }
       
        return ValidationResult.Success;
    }
}
