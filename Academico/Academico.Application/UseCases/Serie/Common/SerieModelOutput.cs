using System;

namespace Academico.Application.UseCases.Serie.Common;

public class SerieModelOutput
{
    public SerieModelOutput(int id, int numero)
    {
        this.id = id;
        this.numero = numero;
    }

    public int id { get; set; }
    public int numero { get; set; }
};

