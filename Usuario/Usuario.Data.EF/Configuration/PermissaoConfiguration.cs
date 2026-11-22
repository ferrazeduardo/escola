using System;
using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Entity;

namespace Usuario.Data.EF.Configuration;

public class PermissaoConfiguration : IEntityTypeConfiguration<Permissao>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Permissao> builder)
    {
        builder.ToTable("Permissao");
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.PL_PERMISSAO).HasMaxLength(50).IsRequired();
        builder.Property(x => x.DS_PERMISSAO).HasMaxLength(100).IsRequired();
        builder.Property(x => x.DS_MODULO).HasMaxLength(50).IsRequired();

        builder.HasIndex(x => x.PL_PERMISSAO).IsUnique();

     
        builder.HasData(
            new { Id = 1,  PL_PERMISSAO = "aluno.listar",      DS_PERMISSAO = "Visualizar alunos",            DS_MODULO = Modulos.Academico },
            new { Id = 2,  PL_PERMISSAO = "aluno.criar",       DS_PERMISSAO = "Cadastrar aluno",              DS_MODULO = Modulos.Academico },
            new { Id = 3,  PL_PERMISSAO = "turma.gerenciar",   DS_PERMISSAO = "Gerenciar turmas",             DS_MODULO = Modulos.Academico },
            new { Id = 4,  PL_PERMISSAO = "nota.lancar",       DS_PERMISSAO = "Lançar notas",                 DS_MODULO = Modulos.Academico },
            new { Id = 5,  PL_PERMISSAO = "frequencia.lancar", DS_PERMISSAO = "Lançar frequência",            DS_MODULO = Modulos.Academico },
            new { Id = 6,  PL_PERMISSAO = "aluno.transferir",  DS_PERMISSAO = "Transferir aluno de turma",    DS_MODULO = Modulos.Academico },
            new { Id = 7,  PL_PERMISSAO = "rede.gerenciar",    DS_PERMISSAO = "Gerenciar dados da rede",      DS_MODULO = Modulos.Rede },
            new { Id = 8,  PL_PERMISSAO = "unidade.gerenciar", DS_PERMISSAO = "Gerenciar unidades escolares", DS_MODULO = Modulos.Rede },
            new { Id = 9,  PL_PERMISSAO = "serie.gerenciar",   DS_PERMISSAO = "Gerenciar séries",             DS_MODULO = Modulos.Rede },
            new { Id = 10, PL_PERMISSAO = "usuario.gerenciar", DS_PERMISSAO = "Gerenciar usuários",           DS_MODULO = Modulos.Sistema },
            new { Id = 11, PL_PERMISSAO = "perfil.gerenciar",  DS_PERMISSAO = "Gerenciar perfis",             DS_MODULO = Modulos.Sistema },
            new { Id = 12, PL_PERMISSAO = "aluno.matricular",  DS_PERMISSAO = "Matricular aluno em turma",    DS_MODULO = Modulos.Academico }
        );
    }

    public static class Modulos
    {
        public const string Academico = "Acadêmico";
        public const string Rede = "Rede";
        public const string Sistema = "Sistema";
    }

    public static readonly int[] TodosOsIds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
}
