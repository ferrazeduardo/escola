using System;
using Academico.Application.UseCases.Pessoa.Common;
using Academico.Domain.Entity;
using Academico.Domain.Exception;
using Academico.Domain.Interface;
using Academico.Domain.Interface.Repository;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.LancarFrequencia;

public class LancarFrequencia : IRequestHandler<LancarFrequenciaInput, LancarFrequenciaOutput>
{
    private IUnitOfWork _unitOfWork;
    private IPessoaRepository _pessoaRepository;

    public LancarFrequencia(IUnitOfWork unitOfWork, IPessoaRepository pessoaRepository)
    {
        _unitOfWork = unitOfWork;
        _pessoaRepository = pessoaRepository;
    }
    public async Task<LancarFrequenciaOutput> Handle(LancarFrequenciaInput request, CancellationToken cancellationToken)
    {
       IDictionary<int, List<LancarFrequenciaModelInput>> pessoaFrequenciaModelOutput = request.frequencias.GroupBy(f => f.pessoaId).ToDictionary(f => f.Key, f => f.ToList());

       foreach(var pessoaFrequencia in pessoaFrequenciaModelOutput)
        {
            var pessoa = await _pessoaRepository.Get(x => x.Id == pessoaFrequencia.Key) ?? throw new NotFoundException("Alguma pessoa da lista não foi encontrada");

            List<Frequencia> frequencias = pessoaFrequencia.Value.Select(f => new Frequencia
            {
                ID_HISTORICO = f.historicoId,
                ST_FREQUENCIA = f.presenca
            }).ToList();

            pessoa.AddFrequencia(frequencias);
        }

        await _unitOfWork.Commit(cancellationToken);

        return new LancarFrequenciaOutput();
    }
}
