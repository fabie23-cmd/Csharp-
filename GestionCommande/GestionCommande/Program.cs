using GestionCommande.Data;
using GestionCommande.Repositories;
using GestionCommande.Services;
using GestionCommande.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); 

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICommandeRepository, CommandeRepository>();
builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddScoped<IFactureRepository, FactureRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICommandeService, CommandeService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();
builder.Services.AddScoped<IFactureService, FactureService>();

builder.Services.AddScoped<ClientFixtures>();
builder.Services.AddScoped<ProduitFixtures>();
builder.Services.AddScoped<CommandeFixtures>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var seederClient = scope.ServiceProvider.GetRequiredService<ClientFixtures>();
    var seederProduit = scope.ServiceProvider.GetRequiredService<ProduitFixtures>();
    var seederCommande = scope.ServiceProvider.GetRequiredService<CommandeFixtures>();
    
    seederClient.Load();  
    seederProduit.Load(); 
    seederCommande.Load(); 
}

app.Run();
