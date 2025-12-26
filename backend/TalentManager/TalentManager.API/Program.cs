using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using TalentManager.Common.Services;
using TalentManager.Common.Interfaces;
using TalentManager.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// DbContext

builder.Services.AddDbContext<AppDbContext>(options =>

    options.UseSqlServer(

        builder.Configuration.GetConnectionString("DefaultConnection")));

// Services

builder.Services.AddScoped<ICompaniesService, CompaniesService>();

// Controllers + Swagger

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

=======
using TalentManager.Common.Interfaces;
using TalentManager.Common.Services;
using TalentManager.Data;

var builder = WebApplication.CreateBuilder(args);


// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddScoped<IRolesService, RolesService>();

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
>>>>>>> 47e473f896f201d34d7c464997a29ac8d96aa3cd
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();
