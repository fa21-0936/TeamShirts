using TeamShirts.Components;
using TeamShirts.Services;

var builder = WebApplication.CreateBuilder(args);

//Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5000/")
    });

// Servicios
builder.Services.AddScoped<ICamisetaService, CamisetaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();