using Microsoft.EntityFrameworkCore;
using Projekt_2._1.Data;

var builder = WebApplication.CreateBuilder(args);

// Dodaj usługę DbContext i połączenie z bazą danych
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodaj usługi MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Skonfiguruj pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Skonfiguruj autoryzację
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Apartments}/{action=Index}/{id?}");


app.Run();