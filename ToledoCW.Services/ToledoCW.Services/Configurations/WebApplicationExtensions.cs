namespace ToledoCW.Services.Configurations;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> UseWebApplication(this WebApplication app, IConfiguration configuration)
    {
        var env = app.Environment;
        
        
        
        return app;
    }
}