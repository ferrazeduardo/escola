using System;

namespace Academico.Application.UseCases.Pessoa.Common;

public class LancarNotaModelInput
{
    public int pessoaId { get; set; }
    public int historicoId { get; set; }
    public decimal valor { get; set; }
}
