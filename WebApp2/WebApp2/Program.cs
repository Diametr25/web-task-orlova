using Microsoft.EntityFrameworkCore;
using WebApp2.BLL.Services;
using WebApp2.DAL.Data;
using WebApp2.DAL.Interfaces;
using WebApp2.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AccountingDbContext>(options =>
    options.UseSqlServer(builder.Configuration
     .GetConnectionString("AccountingConnectionString")));
builder.Services.AddTransient<PostRepository>();
builder.Services.AddTransient<DepartmentRepository>();
builder.Services.AddTransient<EmployeeRepository>();
builder.Services.AddTransient<PostService>();
builder.Services.AddTransient<DepartmentService>();
builder.Services.AddTransient<EmployeeService>();
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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
