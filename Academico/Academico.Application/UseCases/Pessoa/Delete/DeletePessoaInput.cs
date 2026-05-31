using System;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Delete;

public class DeletePessoaInput : IRequest<DeletePessoaOutput>
{
    public int id { get; set; }
}
