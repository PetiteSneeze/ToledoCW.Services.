namespace ToledoCW.Services.Model.Request;

public class ApiRequestAtualizarAtendente
{
    public long Id { get; set; }
    
    public string Nome { get; set; }
    
    public long Estabelecimento { get; set; }

}