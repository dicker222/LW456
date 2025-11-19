using RecipeApi.Repositories;
using RecipeApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіси
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Реєстрація наших класів
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ЗАКОМЕНТУЙ ЦЕ, ЯКЩО БУДУТЬ ПОМИЛКИ З ПОРТОМ
// app.UseHttpsRedirection(); 

app.UseAuthorization();
app.MapControllers();
app.Run();