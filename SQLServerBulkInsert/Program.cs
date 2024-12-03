using BusinessLayer;
using DataAccessLayer;
using OfficeOpenXml;

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
var builder = WebApplication.CreateBuilder(args);
// Enable CORS for all origins, or you can specify a particular origin.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add services to the container.
builder.Services.AddSingleton<DbConfiguration>();
builder.Services.AddScoped<DatabaseService, DatabaseService>();
builder.Services.AddScoped<Isavebulkdata, BulkInsertData>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();


// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Orders API",
        Version = "v1",
        Description = "API for bulk orders insertion"
    });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger in development environment
    app.UseSwaggerUI(); // Add the Swagger UI for visual documentation
}
// Enable CORS
app.UseCors("AllowAll");
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
