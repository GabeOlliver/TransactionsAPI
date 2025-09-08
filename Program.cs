using APITransacitons.Data;
using APITransacitons.Services.SubjectService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SubjectInterface, SubjectService>();

builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Adiciona os serviços necessários para a exploração de endpoints de API
builder.Services.AddEndpointsApiExplorer();

// Adiciona e configura o gerador do Swagger
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Habilita o middleware para servir o JSON gerado pelo Swagger
    app.UseSwagger();
    // Habilita o middleware para servir a UI do Swagger
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
