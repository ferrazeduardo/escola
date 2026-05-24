using System;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Create;

public record CreatePessoaInput(string nome,string cpf,DateTime dataNascimento,int rg  ) : IRequest<CreatePessoaOutput>
{

}
