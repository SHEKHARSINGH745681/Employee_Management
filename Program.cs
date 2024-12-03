using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.IRepo;
using EmployeeAdminPortal.Repository;
using EmployeeAdminPortal.Repository.CrudRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//this way application db context in the main file
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<EmpRepo, RepositoryImpl>();
builder.Services.AddScoped<IDepRepo, DepRepo>();
builder.Services.AddScoped<IDispatchRepo, DispatchRepoImpl>();

builder.Services.AddScoped<CrudRepo, CrudRepoImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
