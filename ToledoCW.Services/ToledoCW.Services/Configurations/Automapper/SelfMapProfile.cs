using AutoMapper;
using AutoMapper.Internal;
using ToledoCW.Services.Extensions;
using ToledoCW.Services.Infraestructure.Entidades;

namespace ToledoCW.Services.Configurations.Automapper;

public class SelfMapProfile : Profile
{
    public SelfMapProfile() : base("SelfMapProfile")
    {
        AllowNullCollections = true;

        ((IProfileExpressionInternal) this).ForAllMaps((_, cnfg) =>
            cnfg.ForAllMembers(opts => opts.IgnoreSourceAndDefault()));
        ((IProfileExpressionInternal) this).ForAllMaps((_, e) =>
            e.AfterMap(MemberConfigurationExpressionExtensions.SetNullFromNullableDefault));

        CreateMap<Atendente, Atendente>();
    }
}