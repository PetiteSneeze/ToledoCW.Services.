using ToledoCW.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

await app.UseWebApplication(builder.Configuration);

app.Run();