using FluentValidation;
using FluentValidation.AspNetCore;
using RecipeApiControllers.Validators; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 

builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddValidatorsFromAssemblyContaining<RecipeValidator>(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();