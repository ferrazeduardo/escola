using System;
using Academico.Application.UseCases.Pessoa.Common;
using Academico.Domain.Entity;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.LancarNota;

public class LancarNota : IRequestHandler<LancarNotaInput, LancarNotaOutput>
{
    private IPessoaRepository _pessoaRepository;
    private IUnitOfWork _unitOfWork;

    public LancarNota(IUnitOfWork unitOfWork, IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<LancarNotaOutput> Handle(LancarNotaInput request, CancellationToken cancellationToken)
    {

        IDictionary<int, List<LancarNotaModelInput>> pessoaNotaModelOutput = request.notas.GroupBy(n => n.pessoaId).ToDictionary(n => n.Key, n => n.ToList());

        foreach (var pessoaNota in pessoaNotaModelOutput)
        {
            var pessoa = await _pessoaRepository.Get(p => p.Id == pessoaNota.Key) ?? throw new NotFoundException("Alguma pessoa da lista não foi encontrada.");


            List<Nota> notas = pessoaNota.Value.Select(NewMethod()).ToList();

            pessoa.AddNota(notas);
        }

        return new LancarNotaOutput();
    }

    private Func<LancarNotaModelInput, Nota> NewMethod()
    {
        return v => new Nota
        {
            ID_HISTORICO = v.historicoId,
            VL_NOTA = v.valor
        };
    }
}
