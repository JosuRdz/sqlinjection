using Microsoft.EntityFrameworkCore;
using Spark_Project.Data;
using Spark_Project.Repositories;
using Spark_Project.Repositories.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Configure connection to SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")); });

// Add Repositories

builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.AllowAnyOrigin().WithMethods(
    HttpMethod.Get.Method,
    HttpMethod.Post.Method,
    HttpMethod.Delete.Method,
    HttpMethod.Patch.Method
    ).AllowAnyHeader();

    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
