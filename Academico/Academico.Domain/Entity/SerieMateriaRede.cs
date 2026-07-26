using System;

namespace Academico.Domain.Entity;

public class SerieMateriaRede
{

    public SerieMateriaRede(int serieId, int redeId, int materiaId)
    {
        this.ID_SERIE = serieId;
        this.ID_REDE = redeId;
        this.ID_MATERIA = materiaId;
    }

    public int ID_REDE { get; set; }
    public int ID_SERIE { get; set; }
    public int ID_MATERIA { get; set; }
}
