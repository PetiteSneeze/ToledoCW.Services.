namespace ToledoCW.Services.Model.Request;

public class ApiRequestNovoAtendente
{
    public string Nome { get; set; }
}

public class ApiRequestAtualizarAtendente
{
    public long Id { get; set; }
    public string Nome { get; set; }
}