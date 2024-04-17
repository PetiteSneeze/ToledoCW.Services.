using FluentValidation;





namespace ToledoCW.Services.Infraestructure.Entidades;

public class Atendente
{
    public long Id { get; set; }
    public string Nome { get; set; }

    public long? Estabelecimento { get; set; }
    
    public Estabelecimento EstabelecimentoObj { get; set; }

    public bool EhValido()
    {
        var _validator = new AtendenteValidator();
        var _result = _validator.Validate(this);
        return _result.IsValid;
    }

}

public class AtendenteValidator : AbstractValidator<Atendente>
{
    public AtendenteValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        RuleFor(x => x.Nome).MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");
        RuleFor(x => x.Estabelecimento).NotEmpty().WithMessage("Estabelecimento é obrigatório");
    }
}