using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; options.JsonSerializerOptions.PropertyNameCaseInsensitive = false; });
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
builder.Services.AddSwaggerGenNewtonsoftSupport();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
