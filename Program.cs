using Microsoft.EntityFrameworkCore;
using ProdutosApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar o banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
app.UseMiddleware<GlobalExceptionHandler>();