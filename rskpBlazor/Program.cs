using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using rskpBlazor;
using rskpBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7169") });
builder.Services.AddScoped<IDoctorProvider, DoctorsProvider>();
builder.Services.AddScoped<IPatientProvider, PatientsProvider>();
builder.Services.AddScoped<IAppointmentProvider, AppointmentsProvider>();
builder.Services.AddScoped<IFacilityProvider, FacilitiesProvider>();
builder.Services.AddScoped<IMedicalFileProvider, MedicalFilesProvider>();

await builder.Build().RunAsync();
