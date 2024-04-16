using Microsoft.AspNetCore.Mvc;
using ToledoCW.Services.Infraestructure;
using ToledoCW.Services.Infraestructure.Entidades;
using ToledoCW.Services.Infraestructure.Repositorios;
using ToledoCW.Services.Model;
using ToledoCW.Services.Model.Request;

namespace ToledoCW.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class AtendenteController : ApiBaseController
{
    private readonly AtendenteRepositorio _Repositorio;
    
    public AtendenteController()
    {
        _Repositorio = new AtendenteRepositorio(new ToledoCWContext());
    }
    
    /// <summary>
    /// Obter todos atendentes.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet]
    public async Task<IActionResult> ObterTodosAtendente()
    {
        var _obj = await _Repositorio.GetAll();
        return Response(_obj);
    }
    
    /// <summary>
    /// Obter atendente por id.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpGet("{id:long}")]
    public async Task<IActionResult> ObterAtendente([FromRoute] long id)
    {
        var _obj = await _Repositorio.Get(x => x.Id == id);
        return Response(_obj);
    }

    /// <summary>
    /// Obter atendente por id.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost]
    public async Task<IActionResult> CriarAtendente(ApiRequestNovoAtendente request)
    {
        var _obj = await _Repositorio.Create(new Atendente
        {
            Nome = request.Nome
        });
        
        return Response(_obj);
    }

    /// <summary>
    /// Atualizar informações de atendente.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut]
    public async Task<IActionResult> AtualizarAtendente(ApiRequestAtualizarAtendente request)
    {
        var _obj = await _Repositorio.Update(new Atendente
        {
            Id = request.Id,
            Nome = request.Nome
        });
        
        return Response(_obj);
    }

    /// <summary>
    /// Excluir atendente.
    /// </summary>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> ExcluirAtendente(long id)
    {
        var _obj = await _Repositorio.Get(x => x.Id == id); 
        
        if(_obj is null)
            return Response(new ApiResponseError("Atendente não encontrado.", "id"));
        
        await _Repositorio.Delete(_obj);
        
        return Response(_obj);
    }
}