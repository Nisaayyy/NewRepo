using Microsoft.EntityFrameworkCore;
using StockTrackingSystem.Business.User.Handlers;
using StockTrackingSystem.Data.EF;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<StockTrackingSystemDbContext>(options =>  
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
       
    )
);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AddUserHandler).Assembly);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
