using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToledoCW.Services.Infraestructure;
using ToledoCW.Services.Infraestructure.Entidades;
using ToledoCW.Services.Infraestructure.Repositorios;
using ToledoCW.Services.Model;
using ToledoCW.Services.Model.Request;
using ToledoCW.Services.Model.Response;

namespace ToledoCW.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class AtendenteController : ApiBaseController
{
    private readonly IRepositorioBase<Atendente> _Repositorio;
    private readonly IMapper _Mapper;

    public AtendenteController(IRepositorioBase<Atendente> repositorio, IMapper mapper)
    {
        _Repositorio = repositorio;
        _Mapper = mapper;
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
        return Response(_Mapper.Map<ApiResponseAtendente>(_obj));
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
        return Response(_Mapper.Map<ApiResponseAtendente>(_obj));
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
            Nome = request.Nome,
            Estabelecimento = request.Estabelecimento
        }); ;

        return Response(_Mapper.Map<ApiResponseAtendente>(_obj));
        {

        };
    }

    
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

        return Response(_Mapper.Map<ApiResponseAtendente>(_obj));
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

        return Response(_Mapper.Map<ApiResponseAtendente>(_obj));
    }
}