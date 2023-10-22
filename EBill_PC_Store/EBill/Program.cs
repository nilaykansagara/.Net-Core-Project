using Microsoft.EntityFrameworkCore;
using EBill.Models.Domain;
using EBill.Repositories.Abstract;
using EBill.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IWarrantyService, WarrantyService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IBillService, BillService>();

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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Model}/{action=Add}/{id?}");

app.Run();
