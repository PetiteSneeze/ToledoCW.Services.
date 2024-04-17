using Microsoft.AspNetCore.Mvc;
using ToledoCW.Services.Infraestructure;
using ToledoCW.Services.Infraestructure.Entidades;
using ToledoCW.Services.Infraestructure.Repositorios;
using ToledoCW.Services.Model;
using ToledoCW.Services.Model.Request;
using ToledoCW.Services.Services;

namespace ToledoCW.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class EstabelecimentoController : ApiBaseController
{
    private readonly IEstabelecimentoService _Service;
    
    public EstabelecimentoController(IEstabelecimentoService service)
    {
        _Service = service;
    }

    /// <summary>
    /// Obter todos atendentes.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet]
    public async Task<IActionResult> ObterTodosEstabelecimento()
    {
        var _obj = await _Service.GetList();
        
        return Response(_obj);
    }
}