using MediatR;

namespace Academico.Application.UseCases.Serie.AddMateriaRede;

public record  AddMateriaRedeInput(int serieId, int redeId, List<int> materiaId) : IRequest<AddMateriaRedeOutput>;