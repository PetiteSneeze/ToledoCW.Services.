using Microsoft.EntityFrameworkCore;
using ToledoCW.Services.Infraestructure;
using ToledoCW.Services.Infraestructure.Repositorios;
using ToledoCW.Services.Services;

namespace ToledoCW.Services.Configurations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("Padrao",
                x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<INotificationService, NotificationService>();

        services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();

        services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));

        services.AddDbContext<ToledoCWContext>(options => options.UseMySQL("Mysql"));

        services.AddAutoMapper(typeof(Program).Assembly);


        return services;
    }
}