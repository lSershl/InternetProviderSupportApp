using Blazored.LocalStorage;
using IPSA.Shared.Contracts;
using IPSA.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IAbonentService, AbonentService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IStreetService, StreetService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IAbonPageCommentService, AbonPageCommentService>();
builder.Services.AddScoped<ITariffService, TariffService>();
builder.Services.AddScoped<IConnectedTariffService, ConnectedTariffService>();
builder.Services.AddScoped<IAbonentRequestService, AbonentRequestService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
