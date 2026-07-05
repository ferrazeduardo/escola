using MediatR;

namespace Academico.Application.UseCases.Materia.UpdateStatus;

public record  UpdateStatusInput(int id, bool status) : IRequest<UpdateStatusOutput>
{

}
