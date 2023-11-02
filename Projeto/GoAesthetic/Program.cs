using GoAestheticEntidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using GoAestheticComuns.Constantes;
using GoAestheticNegocio.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GoAestheticDbContext>(options =>
{
    options.UseSqlServer(EnvironmentHelper.BuscaStringConexaoDb().Result);
});


builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});


builder.Services.AddMvc();

builder.Services.AddControllers();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.LoginPath = "/Login";
        options.LogoutPath = "/Login";
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/AcessoNegado";
        options.Cookie.Name = "GoAestheticCookie";
    });

builder.Services.AddAuthorization(options =>
{
    string[] roles = new string[] { Roles.Usuario, Roles.Administrador };

    options.AddPolicy("RequirimentoMinimoAcesso",
    policy => policy.RequireRole(roles));
});

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
