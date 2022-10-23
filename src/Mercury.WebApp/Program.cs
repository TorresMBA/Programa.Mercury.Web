using Mercury.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MercuryContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<MercuryContext>();

#region Configurando Servicio de Identity
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<MercuryContext>().AddDefaultTokenProviders();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region Ejecuci�n de Migraciones Pendientes
/*
 * Esta codigo a�adido nos ayudar� para acceder a nuestro context(MercuryContext)
 * el metodo MigrateAsync -> aplica de manera asincrona cualquier migracion pendiente 
 * para el contexto en al base de datos y creaba la db en caso no exista, este codigo
 * se ejecutara al inicio de nuestra aplicaci�n.
*/
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<MercuryContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurrio un error durante la migraci�n");
    }
}
#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Codigo para realizar mapeo de nuestras vistas de Identity
app.UseEndpoints(enpoints =>
{
    enpoints.MapRazorPages();
});
//

app.Run();
