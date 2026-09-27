using System;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Delete;

public record DeletePessoaInput(int id) : IRequest<DeletePessoaOutput>
{
}
