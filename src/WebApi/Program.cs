using Flywheel.Infrastructure;
using Microsoft.OpenApi;
using Flywheel.Application; // Eğer Application DI varsa (şu an manuel ekledik)

var builder = WebApplication.CreateBuilder(args);

// 1. KATMANLARI EKLE (Dependency Injection)
// Not: Application katmanı için de benzer bir DI dosyası oluşturmak best-practice'dir ama şimdilik manuel geçiyoruz.
// Infrastructure servisini çağırıyoruz (Postgres burada configure ediliyor)
builder.Services.AddInfrastructure(builder.Configuration);

// Application katmanını (MediatR) ekle
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Flywheel.Application.Common.Interfaces.IApplicationDbContext).Assembly));

// 2. API SERVİSLERİ
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger Konfigürasyonu
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Flywheel AI Generated API",
        Version = "v1",
        Description = "AI Ajanları tarafından geliştirilen Clean Architecture API'si"
    });
});

var app = builder.Build();

// 3. MIDDLEWARE PIPELINE
// Swagger her ortamda açık olsun ki Ajanlar görebilsin
app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();
app.MapControllers();

app.Run();