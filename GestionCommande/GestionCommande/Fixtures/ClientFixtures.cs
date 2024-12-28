using GestionCommande.Data;
using GestionCommande.Models;

namespace GestionCommande.Fixtures;

public class ClientFixtures
{
    private readonly ApplicationDbContext _context;

    public ClientFixtures(ApplicationDbContext context)
    {
        this._context = context;
    }

    public void Load()
    {
        if (!_context.Clients.Any())
        {
            _context.Clients.AddRange(
                new Client
               ] },
                ]
                }
            );
            _context.SaveChanges();
        }

    }
}
