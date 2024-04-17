using AutoMapper;

namespace ToledoCW.Services.Configurations.Automapper;

public static class ConfigMapProfile
{
    public static MapperConfiguration Register()
    {
        return new MapperConfiguration(ps =>
        {
            ps.AllowNullCollections = true;

            ps.AddProfile(new SelfMapProfile());
            ps.AddProfile(new MapProfile());
        });
    }
}