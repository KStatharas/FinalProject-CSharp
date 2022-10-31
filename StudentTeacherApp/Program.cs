using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.DAO;
using StudentTeacherApp.Data;
using StudentTeacherApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IGenericDAO, GenericDAOImpl>();
builder.Services.AddScoped<IGenericService, GenericServiceImpl>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication("LoginCredAuth").AddCookie("LoginCredAuth", options =>
{
    options.Cookie.Name = "LoginCredAuth";
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/ForbiddenAccess";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccessibility",
        policy => policy.RequireClaim("Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
