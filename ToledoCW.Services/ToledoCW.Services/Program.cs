using ToledoCW.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
        
builder.Services.AddCors(options =>
{
    options.AddPolicy("Padrao",
        x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});
        
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Padrao");

app.MapControllers();
        
app.UseHttpsRedirection();

app.Run();