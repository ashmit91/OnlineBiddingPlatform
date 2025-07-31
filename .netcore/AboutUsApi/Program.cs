using AboutUsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Register services
builder.Services.AddControllers();
builder.Services.AddScoped<EmailService>(); // Use AddScoped or AddTransient based on usage

// 🔧 Swagger for API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Enable CORS for React frontend (adjust origin in production)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 🔧 Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔒 Middleware pipeline
app.UseHttpsRedirection();
app.UseCors("AllowAll");       // 👈 Apply the defined CORS policy
app.UseAuthorization();        // No authentication used yet but keep this
app.MapControllers();          // Enable route mapping for controllers

app.Run();
