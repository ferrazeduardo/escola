using System;
using Academico.Application.UseCases.Pessoa.Common;

namespace Academico.Application.UseCases.Pessoa.Get;

public class GetPessoaOutput
{
    public PessoaModelOutput pessoa { get; set; } = new();
}
