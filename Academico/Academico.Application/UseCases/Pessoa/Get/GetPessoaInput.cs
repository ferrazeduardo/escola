using System;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Get;

public record GetPessoaInput(string cpf,int rg,int? id) : IRequest<GetPessoaOutput>
{

}
