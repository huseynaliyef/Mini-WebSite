using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    x =>
    {
        x.LoginPath = "/Home/Login";
        x.AccessDeniedPath = "/Account/AccessDenied";
    });


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});


var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();





app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Login}");

app.MapControllerRoute(
	name: "Login&RegisterPage",
	pattern: "Login&Register",
	defaults: new { Controller = "Home", Action = "Login" });


app.MapControllerRoute(
    name: "HomePage",
    pattern: "AnaSehife",
    defaults: new { Controller = "Home", Action = "Index" });

app.MapControllerRoute(
    name: "AddingPage",
    pattern: "AddUser",
    defaults: new { Controller = "Home", Action = "AddUsers" });

app.MapControllerRoute(
    name: "DtailsPage",
    pattern: "Details",
    defaults: new { Controller = "Home", Action = "ShowDetails" });

app.MapControllerRoute(
    name: "ADMIN_SIDE",
    pattern: "ADMIN",
    defaults: new { controller = "Admin", Action = "Login" });

app.Run();


