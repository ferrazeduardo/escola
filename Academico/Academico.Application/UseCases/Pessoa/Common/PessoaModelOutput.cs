using System;
using app = Academico.Domain.Entity;

namespace Academico.Application.UseCases.Pessoa.Common;

public class PessoaModelOutput
{
    public Guid id { get; private set; }
    public int rg { get; private set; }
    public string cpf { get; private set; }
    public string nome { get; private set; }
    public DateTime dataNascimento { get; private set; }


    public void From(app.Pessoa pessoa)
    {
        id = pessoa.IdGuid;
        rg = pessoa.NR_RG;
        cpf = pessoa.NR_CPF;
        dataNascimento = pessoa.DH_NASCIMENTO;
    }
}
