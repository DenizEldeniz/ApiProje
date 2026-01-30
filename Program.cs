using ApiProjeKampi.WebApi.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
IServiceCollection serviceCollection = builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// .NET 10 ile gelen yerel OpenAPI desteği
builder.Services.AddOpenApi();
// Context klasörünün namespace'i

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // OpenAPI JSON dökümanını oluşturur (/openapi/v1.json)
    app.MapOpenApi();

    // Swagger UI arayüzünü etkinleştirir
    // Varsayılan adres: https://localhost:xxxx/swagger
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();