using AutoMapper;
using AutoMapper.Internal;
using ToledoCW.Services.Extensions;
using ToledoCW.Services.Infraestructure.Entidades;
using ToledoCW.Services.Model.Request;
using ToledoCW.Services.Model.Response;

namespace ToledoCW.Services.Configurations.Automapper;

public class MapProfile : Profile
{
    public MapProfile() : base("MapProfile")
    {
        AllowNullCollections = true;
        ((IProfileExpressionInternal) this).ForAllMaps((_, cnfg) =>
            cnfg.ForAllMembers(opts => opts.IgnoreSourceWhenDefault()));
        CreateMap();
    }

    private void CreateMap()
    {
        RequestMaps();
        ResponseMaps();
    }
    
    private void RequestMaps()
    {
        CreateMap<ApiRequestNovoAtendente, Atendente>().ReverseMap();
        CreateMap<ApiRequestAtualizarAtendente, Atendente>().ReverseMap();
    }
    
    private void ResponseMaps()
    {
        CreateMap<ApiResponseAtendente, Atendente>().ReverseMap();
        CreateMap<ApiResponseEstabelecimento, Estabelecimento>().ReverseMap();
    }
}