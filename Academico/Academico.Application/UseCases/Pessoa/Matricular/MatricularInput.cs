using MediatR;

namespace Academico.Application.UseCases.Pessoa.Matricular;

public record MatricularInput(int alunoId, int turmaId) : IRequest<MatricularOutput>;
