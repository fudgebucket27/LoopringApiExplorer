using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; options.JsonSerializerOptions.PropertyNameCaseInsensitive = false; options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "LoopringSharp API Explorer - V1",
            Description = "This is an API explorer for Loopring built using LoopringSharp",
            Contact = new OpenApiContact
            {
                Name = "LoopringSharp",
                Url = new Uri("https://github.com/taranasus/LoopringSharp")
            }            
        }
     );
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "LoopringApiExplorer.xml");
    c.IncludeXmlComments(filePath);
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
