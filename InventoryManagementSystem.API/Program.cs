using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Infrastructure;
using InventoryManagementSystem.Infrastructure.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//register config
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IMDbContext>(
    op=>op.UseNpgsql(
        configuration.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly(typeof(IMDbContext).Assembly.GetName().Name)));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<ISaleRepository,SaleRepository>();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(IProductRepository).Assembly));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();