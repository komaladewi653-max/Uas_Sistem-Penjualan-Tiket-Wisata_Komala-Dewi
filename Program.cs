using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using WisataTicketApp.Data;
using WisataTicketApp.Services;
using QuestPDF.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )));

builder.Services.AddScoped<WisataService>();
builder.Services.AddScoped<PengunjungService>();
builder.Services.AddScoped<PemesananService>();
builder.Services.AddScoped<TicketPdfService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<LaporanService>();

QuestPDF.Settings.License =
    LicenseType.Community;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();