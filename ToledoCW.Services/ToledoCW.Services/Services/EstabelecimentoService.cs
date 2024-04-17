using ToledoCW.Services.Infraestructure.Entidades;
using ToledoCW.Services.Infraestructure.Repositorios;

namespace ToledoCW.Services.Services;

public class EstabelecimentoService : ServiceBase<Estabelecimento>, IEstabelecimentoService
{
    public EstabelecimentoService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}

public interface IEstabelecimentoService : IService<Estabelecimento>
{
}