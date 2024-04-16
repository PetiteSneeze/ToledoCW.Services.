using Microsoft.EntityFrameworkCore;
using ToledoCW.Services.Infraestructure.Entidades;

namespace ToledoCW.Services.Infraestructure.Repositorios;

public class AtendenteRepositorio : RepositorioBase<Atendente>
{
    public AtendenteRepositorio(DbContext dbContext) : base(dbContext)
    {
    }
}