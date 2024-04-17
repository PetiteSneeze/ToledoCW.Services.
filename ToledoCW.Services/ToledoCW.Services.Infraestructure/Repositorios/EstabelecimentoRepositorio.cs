using Microsoft.EntityFrameworkCore;
using ToledoCW.Services.Infraestructure.Entidades;

namespace ToledoCW.Services.Infraestructure.Repositorios;

public class EstabelecimentoRepositorio : RepositorioBase<Estabelecimento>
{
    public EstabelecimentoRepositorio(DbContext dbContext) : base(dbContext)
    {
    }
}