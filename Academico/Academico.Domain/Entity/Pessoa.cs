using System;
using Academico.Domain.Exception;
using Academico.Domain.SeedWork;
using Academico.Domain.Validator;

namespace Academico.Domain.Entity;

public class Pessoa : AggregateRoot
{
    public Pessoa(string nome, string nR_CPF, int nR_RG, DateTime dH_NASCIMENTO)
    {
        Nome = nome;
        NR_CPF = nR_CPF;
        NR_RG = nR_RG;
        DH_NASCIMENTO = dH_NASCIMENTO;
        DH_CREATE = DateTime.UtcNow;
        Validator();
    }

    public Pessoa()
    {

    }

    public string Nome { get; set; }
    public string NR_CPF { get; set; }
    public int NR_RG { get; set; }
    public DateTime DH_NASCIMENTO { get; set; }
    public DateTime DH_CREATE { get; set; }

    public ICollection<Responsavel> Responsaveis { get; private set; } = [];

    public void AddResponsavel(Responsavel responsavel)
    {
        Responsaveis.Add(responsavel);
    }

    public void RemoveResponsavel(Responsavel responsavel)
    {
        Responsaveis.Remove(responsavel);
    }

    public void JaSalvoBanco(Pessoa pessoa)
    {
        ExcecaoDeDominio.HaError(pessoa is not null && this.Equals(pessoa), "Pessoa já estava cadastrada");
    }


    public void Validator()
    {
        ValidadorDeRegra.Novo()
            .Quando(string.IsNullOrEmpty(Nome), "Nome é obrigatorio")
            .Quando(string.IsNullOrEmpty(NR_CPF), "CPf é obrigatório")
            .Quando(NR_CPF.Count() != 11, "CPF tem que ter 11 digitos")
            .Quando(NR_RG <= 0, "RG não pode ser negativo ou zero")
            .Quando(DH_NASCIMENTO <= new DateTime(1910, 1, 1), "Data nascimento tem que ser maior 1/1/1910")
            .DispararExcecaoSeExistir();
    }

    public void Update(string cpf, string nome, int rg)
    {
        throw new NotImplementedException();
    }
}
