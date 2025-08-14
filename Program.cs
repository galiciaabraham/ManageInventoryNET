using ManageInventoryNET.Components;
using ManageInventoryNET.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services classic style
builder.Services.AddRazorPages();
builder.Services.AddControllers();
// services for authentication using cookies and allowing login and logout
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/AccessDenied";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(10);
        options.Cookie.Name = "ManageInventoryNET.Auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
        options.Cookie.SameSite = SameSiteMode.Lax;

    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
builder.Services.AddHttpContextAccessor();
// services for making HTTP requests to the API
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7101"); 
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    UseCookies = true,
    CookieContainer = new CookieContainer()
});


builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
// services for database access for product and user management
builder.Services.AddSqlite<ProductContext>("Data Source=products.db");
builder.Services.AddSqlite<AppDbContext>("Data Source=users.db");
//adding policy for admin role
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});


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
app.UseRouting();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapBlazorHub(); 
app.MapFallbackToPage("/_Host");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
    DbInitializer.Seed(scope.ServiceProvider); // seed user data
}
app.Run();
