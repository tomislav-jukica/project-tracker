using Microsoft.EntityFrameworkCore;
using ProjectTracker.Application.Projects.Commands.CreateProject;
using ProjectTracker.Application.Projects.Interfaces;
using ProjectTracker.Infrastructure.Persistence;
using ProjectTracker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AssetDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

//Mediator
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(CreateProjectHandler).Assembly);
});

//Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

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