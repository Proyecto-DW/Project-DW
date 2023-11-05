using appbeneficiencia.Models;
using appbeneficiencia.Servicios.Contrato;
using appbeneficiencia.Servicios.Implementacion;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BeneficiariosdbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSQL"));
});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
            new ResponseCacheAttribute
            {
                NoStore = true,
                Location = ResponseCacheLocation.None,
            }
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    //name: "default",
    //pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

    name: "default",
    //pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");
    //pattern: "{controller=Home}/{action=Index}/{id?}");
      pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();