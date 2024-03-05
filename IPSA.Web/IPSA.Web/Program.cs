using IPSA.Web.Client.Pages;
using IPSA.Web.Components;
using IPSA.Shared.Contracts;
using IPSA.Web.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using IPSA.Web.States;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped(http => new HttpClient 
{ 
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!) 
});
builder.Services.AddScoped<IAbonentService, AbonentService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IStreetService, StreetService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IAbonPageCommentService, AbonPageCommentService>();
builder.Services.AddScoped<ITariffService, TariffService>();
builder.Services.AddScoped<IConnectedTariffService, ConnectedTariffService>();
builder.Services.AddScoped<IAbonentRequestService, AbonentRequestService>();
builder.Services.AddScoped<IReportService, ReportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Abonents).Assembly);

app.Run();
