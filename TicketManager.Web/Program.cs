using TicketManager.Web.Services;


var builder = WebApplication.CreateBuilder(args);


// ✅ Agregar servicios al contenedor
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // Necesario para HttpContext.Session

// ✅ Agregar cliente HTTP para consumir API
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/"); // URL de tu API
});

var app = builder.Build();

// ✅ Middleware del pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();       // <-- ¡Importante!
app.UseAuthorization();

// ✅ Ruta por defecto al login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();