using System;

namespace Academico.Application.UseCases.Pessoa.Common;

public class LancarFrequenciaModelInput
{
    public int pessoaId { get; set; }
    public int historicoId { get; set; }
    public bool presenca { get; set; }
}
