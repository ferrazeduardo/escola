using System;
using MediatR;

namespace Academico.Application.UseCases.Pessoa.Update;

public class UpdatePessoaInput : IRequest<UpdatePessoaOutput>
{
    public Guid id { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public int rg { get; set; }
    public DateTime dataNascimento { get; set; }
}
