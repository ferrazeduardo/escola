using System;

namespace Academico.Domain.DataTransferObject;

public class UnidadeDto
{
    public int id { get; set; }
    public List<SalaDto> salas { get; set; }
}

public class SalaDto
{
    public string numeroSala { get; set; }
    public int qtdMaxima { get; set; }
}
