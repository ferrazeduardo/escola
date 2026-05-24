using System;
using System.Linq.Expressions;
using Academico.Domain.Interface.Repository;
using MediatR;
using app = Academico.Domain.Entity;

namespace Academico.Application.UseCases.Pessoa.Get;

public class GetPessoa : IRequestHandler<GetPessoaInput, GetPessoaOutput>
{
    private IPessoaRepository _pessoaRepository;

    public GetPessoa(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<GetPessoaOutput> Handle(GetPessoaInput request, CancellationToken cancellationToken)
    {
        IDictionary<bool, Expression<Func<app.Pessoa, bool>>> dict = new Dictionary<bool, Expression<Func<app.Pessoa, bool>>>()
        {
            {request.id is not null , x => x.IdGuid == request.id},
            {string.IsNullOrEmpty(request.cpf) is false, x => x.NR_CPF == request.cpf },
            {request.rg > 0 , x => x.NR_RG == request.rg}
        };

        var func = dict.FirstOrDefault(x => x.Key).Value ?? throw new ArgumentException("É necessário enviar uma argumento válido.");
        var pessoa = await _pessoaRepository.Get(func, false);
        var output = new GetPessoaOutput();
        output.pessoa.From(pessoa);

        return output;

    }
}
