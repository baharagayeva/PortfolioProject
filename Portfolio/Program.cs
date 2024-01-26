using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PortfolioDbContext>().AddIdentity<User, Role>().AddEntityFrameworkStores<PortfolioDbContext>();


builder.Services.AddScoped<IPositionService, PositionManager>();
builder.Services.AddScoped<IPositionDAL, PositionEFDal>();
builder.Services.AddScoped<IPersonService, PersonManager>();
builder.Services.AddScoped<IPersonDAL, PersonEFDal>();
builder.Services.AddScoped<IExperienceService, ExperienceManager>();
builder.Services.AddScoped<IExperienceDAL, ExperienceEFDal>();
builder.Services.AddScoped<ISkillService, SkillManager>();
builder.Services.AddScoped<ISkillDAL, SkillEFDal>();
builder.Services.AddScoped<ISkillDetailService, SkillDetailManager>();
builder.Services.AddScoped<ISkillDetailDAL, SkillDetailEFDal>();
builder.Services.AddScoped<IWorkCategoryService, WorkCategoryManager>();
builder.Services.AddScoped<IWorkCategoryDAL, WorkCategoryEFDal>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();
builder.Services.AddScoped<IPortfolioDAL, PortfolioEFDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();  
builder.Services.AddScoped<IServiceDAL, ServiceEFDal>();
builder.Services.AddScoped<IValidator<Person>, PersonValidator>();
builder.Services.AddScoped<IValidator<Experience>, ExperienceValidator>();
builder.Services.AddScoped<IValidator<Portfoli>, PortfolioValidator>();

var app = builder.Build();

//builder.Services.AddDbContext<PortfolioDbContext>(options =>
//options.UseSqlServer());


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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
     name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
     name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"
        );

});



app.Run();
