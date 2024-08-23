using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TransferApi.Repositories;
using TransferApi.Services;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL veritabanı bağlantısını yapılandır.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository ve servislerin dependency injection ile eklenmesi.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITransferService, TransferService>();

// Swagger'ın eklenmesi.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transfer API", Version = "v1" });
});

// CORS ayarlarını ekleyin.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Controller'ların eklenmesi.
builder.Services.AddControllers();

var app = builder.Build();

// HTTP request pipeline'ı yapılandır.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer API v1"));
}

app.UseHttpsRedirection();

// CORS politikasını uygulayın.
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();