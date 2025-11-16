using System;

namespace Serie.Domain.Entity;

public class MateriaRede
{
   public int ID_MATERIA { get; set; }
   public Materia Materia { get; set; }
   public int ID_REDE { get; set; }

   public Rede Rede { get; set; }
}
