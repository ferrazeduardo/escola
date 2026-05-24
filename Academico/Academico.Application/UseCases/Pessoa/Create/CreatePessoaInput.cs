using System;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Create;

public class CreatePessoaInput : IRequest<CreatePessoaOutput>
{
    public string nome { get; set; }
    public string cpf { get; set; }
    public DateTime dataNascimento { get; set; }
    public int rg { get; set; }
}
