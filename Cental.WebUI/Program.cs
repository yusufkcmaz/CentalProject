using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.BusinessLayer.Extensions;
using Cental.BusinessLayer.Validations;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//About Service gördüðün zaman aboutmanager sýnýfýndan bir nesne örneði al ve iþlemi onunla yap.
builder.Services.AddDbContext<CentalContext>();

//Identity Kullanýmý.
builder.Services.AddIdentity<AppUser, AppRole>(cfg=>
{
    cfg.User.RequireUniqueEmail = true;
    
})
    .AddEntityFrameworkStores<CentalContext>()
    .AddErrorDescriber<CustomErrorDescribar>();
    


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


//--> business taþýndý -Extensions  

builder.Services.AddServiceRegistrations();

//
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<BrandValidator>();


builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new AuthorizeFilter()); //-> 
});

builder.Services.ConfigureApplicationCookie(config =>
{
    //--> çýkýþ iþlemlerinde 
    config.LoginPath = "/Login/Index";
    config.LogoutPath = "/Login/Logout";
    config.AccessDeniedPath = "/ErrorPage/AccessDenied";


    
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
app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFound404");

app.UseRouting();
app.UseAuthentication(); // SÝSTEME --> KAYIT KONTROLÜ.
app.UseAuthorization(); // SÝSTEMDE --> YETKÝ KONTROLÜ.


app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );




app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
  );



app.MapControllerRoute(
    name: "defaultuý",
    pattern: "{controller=Defaultuý}/{action=Index}/{id?}");






app.Run();
