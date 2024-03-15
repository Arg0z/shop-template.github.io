using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StickerShop.Controllers;
using StickerShop.Models;
using StickerShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        builder => builder.WithOrigins("https://stickershop-template-front-github-io.vercel.app")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.Configure<StickerShopDatabaseSettings>(
                 builder.Configuration.GetSection(nameof(StickerShopDatabaseSettings)));

builder.Services.AddSingleton<iStickerShopDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<StickerShopDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
                new MongoClient(builder.Configuration.GetValue<string>("StickerShopDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<iStickerService, StickerController>();

builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapRazorPages();

app.UseCors("ReactPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();