using Software_Foundations_Learning_Programme_.DbContexts;
using Microsoft.EntityFrameworkCore;
using Software_Foundations_Learning_Programme_.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EvGrantApplicationContext>(dbContextOptions
    => dbContextOptions.UseSqlite("Data Source=EvGrantApplication.db"));

builder.Services.AddScoped<IEvGrantRepository, EvGrantRepository>();

builder.WebHost.UseUrls("http://0.0.0.0:80");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()                     
              .AllowAnyMethod();                   
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EvGrantApplicationContext>();
    context.Database.Migrate(); // Automatically apply migrations
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowLocalhost3000");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = app.MapControllers();
});

app.Run();