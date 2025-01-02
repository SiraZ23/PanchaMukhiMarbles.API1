using Microsoft.EntityFrameworkCore;
using PanchaMukhiMarbles.API1.Data;
using PanchaMukhiMarbles.API1.Mappings;
using PanchaMukhiMarbles.API1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//DB Context Injection
builder.Services.AddDbContext<PanchaMukhiMarblesDbContext>(options => options.UseSqlServer(builder.
    Configuration.GetConnectionString("Marble")));

//AutoMapper Injection
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

//Repository Injection
builder.Services.AddScoped<IAboutSectionRepository, SQLAboutSectionRepository>();
builder.Services.AddScoped<IExploreSectionRepository, SQLExploreSectionRepository>();
builder.Services.AddScoped<IHeroSectionRepository, SQLHeroSectionRepository>();
builder.Services.AddScoped<ILogoRepository, SQLLogorepository>();
builder.Services.AddScoped<IProductRepository,SQLProductRepository>();
builder.Services.AddScoped<IServiceSectionRepository, SQLServiceSectionRepository>();
builder.Services.AddScoped<ISocialMediaRepository, SQLSocialMediaRepository>();
builder.Services.AddScoped<IContactTableRepository, SQLContactTableRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
