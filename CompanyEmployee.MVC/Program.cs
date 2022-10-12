using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs.DepartmentDTOs;
using EntityLayer.DTOs.EmployeeDTOs;
using EntityLayer.DTOs.SectorDTOs;
using ExamProject.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("Db");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options => {
    options.UseNpgsql(connection);

});
builder.Services.AddIdentity<AppUser, AppRole>(opts =>
{

    opts.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
builder.Services.AddScoped<IGenericRepository<Sector>, GenericRepository<Sector>>();
builder.Services.AddScoped<IGenericRepository<Department>, GenericRepository<Department>>();

builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<ISectorServices, SectorManager>();

builder.Services.AddAutoMapper(typeof(Automapper));


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                                       .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});
builder.Services.ConfigureApplicationCookie(options =>
{

    options.LoginPath = "/login/index";



});

builder.Services.AddScoped<IValidator<EmployeeToAddOrUpdateDTO>, EmployeeValidatior>();
builder.Services.AddScoped<IValidator<SectorToAddOrUpdateDTO>, SectorValidatior>();
builder.Services.AddScoped<IValidator<DepartmentToAddOrUpdateDTO>, DepartmentValidatior>();
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
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Sector}/{action=Index}/{id?}");

app.Run();
