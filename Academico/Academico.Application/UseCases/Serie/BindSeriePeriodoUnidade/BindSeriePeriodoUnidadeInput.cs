using MediatR;

namespace Academico.Application.UseCases.Serie.BindSeriePeriodoUnidade;

public record BindSeriePeriodoUnidadeInput(int serieId,int unidadeId,int periodo,string numeroSala) : IRequest<BindSeriePeriodoUnidadeOutput>;