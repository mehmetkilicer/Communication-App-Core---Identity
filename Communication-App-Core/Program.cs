using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Communication_App_Core.Models;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProjeContext>();

//builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
//builder.Services.AddScoped<IAppUserService, AppUserManager>();

//builder.Services.AddScoped<IMessageService, MessageManager>();
//builder.Services.AddScoped<IMessageDal, EfMessageDal>();


builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ProjeContext>().AddErrorDescriber<CustomIdentityValidator>();



builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Index";

});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
