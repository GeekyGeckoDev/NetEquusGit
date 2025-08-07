using UiNetEquus.Components;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using Domain.Models;
using Application.ServiceInterfaces;
using Application.Services;
using Application.ServiceInterfaces.IUserServices.IUserManagementServices;
using Application.Services.UserServices.UserManagementServices;
using Application.RepositoryInterfaces;
using DAL.Repositories.UserRepositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

//The start of depndency injection
static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<NetEquusDbContext>();

    //Services

    services.AddScoped<IAdminUserCrudService, AdminUserCrudService>();
    services.AddScoped<IUserUserCrudService, UserUserCrudService>();
    services.AddScoped<ISharedUserCrudService, SharedUserCrudService>();

    //Repositories

    services.AddScoped<IUserCrudRepository, UserCrudRepository>();
});