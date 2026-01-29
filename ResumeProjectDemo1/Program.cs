using ResumeProjectDemo1.Context;
using Microsoft.AspNetCore.Authentication.Cookies; // Bu satýrý ekle

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný Context Kaydý
builder.Services.AddDbContext<ResumeContext>();

// 2. Kimlik Doðrulama (Cookie Authentication) Ayarlarý
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Giriþ yapmayanlar buraya yönlenir
        options.LogoutPath = "/Login/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // 30 dk iþlem yapýlmazsa atar
    });

// 3. Oturum (Session) Desteði
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware Sýralamasý Önemlidir!
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 4. Kimlik Doðrulama ve Yetkilendirmeyi Aktif Et
app.UseAuthentication(); // Bu satýr UseAuthorization'dan ÖNCE gelmeli
app.UseAuthorization();
app.UseSession();

// 5. Baþlangýç Sayfasýný Login Yap (Opsiyonel)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();