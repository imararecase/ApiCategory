using APICategory.DbContexts;
using APICategory.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra la conexion a la BD SQL
var connectionString = builder.Configuration.GetConnectionString("CategoryDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//Inyeccion de dependencia para IProductRepository
builder.Services.AddScoped<ICategoryRepository, CategorySQLRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.ls
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowedOrigins"); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
