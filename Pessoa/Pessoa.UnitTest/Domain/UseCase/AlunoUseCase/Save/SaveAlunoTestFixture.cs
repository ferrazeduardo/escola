using System.Text.RegularExpressions;
using Pessoa.Application.Interface.Repository;
using Pessoa.Application.UseCase.AlunoUseCase.Save;
using Pessoa.Domain.DataTransferObject;
using Pessoa.Domain.Entity;
using Pessoa.UnitTest.Base;

namespace Pessoa.UnitTest.Domain.UseCase.AlunoUseCase.Save;


public class SaveAlunoTestFixture : BaseFixture
{

    public SaveAlunoInput GetExemploSaveAlunoInput()
    {
        SaveAlunoInput saveAlunoInput = new();
        saveAlunoInput.id_rede = Guid.NewGuid();
        saveAlunoInput.aluno = new PessoaDto();
        saveAlunoInput.aluno.telefones = new();
        saveAlunoInput.aluno.telefones.Add(Faker.Phone.PhoneNumber());
        saveAlunoInput.aluno.rg = "5678987634";
        saveAlunoInput.aluno.endereco = Faker.Address.FullAddress();
        saveAlunoInput.aluno.dataNascimento = Faker.Date.Past();
        saveAlunoInput.aluno.cpf = "35893663039";
        saveAlunoInput.aluno.cep = Faker.Address.ZipCode();
        saveAlunoInput.aluno.nome = Faker.Name.FullName();
        saveAlunoInput.aluno.numero = Faker.Address.BuildingNumber();
        saveAlunoInput.aluno.uf = "PA";
        saveAlunoInput.pai = new PessoaDto();
        saveAlunoInput.pai.telefones = new();
        saveAlunoInput.pai.telefones.Add(Faker.Phone.PhoneNumber());
        saveAlunoInput.pai.rg = "5678987666";
        saveAlunoInput.pai.endereco = Faker.Address.FullAddress();
        saveAlunoInput.pai.dataNascimento = Faker.Date.Past().AddYears(-20);
        saveAlunoInput.pai.cpf = "81707641064";
        saveAlunoInput.pai.cep = Faker.Address.ZipCode();
        saveAlunoInput.pai.nome = Faker.Name.FullName();
        saveAlunoInput.pai.numero = Faker.Address.BuildingNumber();
        saveAlunoInput.pai.uf = "PA";
        saveAlunoInput.mae = new PessoaDto();
        saveAlunoInput.mae.telefones = new();
        saveAlunoInput.mae.telefones.Add(Faker.Phone.PhoneNumber());
        saveAlunoInput.mae.rg = "5678987644";
        saveAlunoInput.mae.endereco = Faker.Address.FullAddress();
        saveAlunoInput.mae.dataNascimento = Faker.Date.Past().AddYears(-20);
        saveAlunoInput.mae.cpf = "09003307083";
        saveAlunoInput.mae.cep = Faker.Address.ZipCode();
        saveAlunoInput.mae.nome = Faker.Name.FullName();
        saveAlunoInput.mae.numero = Faker.Address.BuildingNumber();
        saveAlunoInput.mae.uf = "PA";
        
        return saveAlunoInput;
    }

    public Rede GetRede(Guid idRede)
    {
        Rede rede = new();
        rede.DS_REDE = Faker.Name.FullName();
        rede.Id = idRede;
        return rede;
    }

    public Mae getMae(SaveAlunoInput alunoMae)
    {
        return new Mae(alunoMae.mae.nome, alunoMae.mae.cpf, alunoMae.mae.rg, alunoMae.mae.endereco, alunoMae.mae.numero,
            alunoMae.mae.uf, alunoMae.mae.dataNascimento);
    }

    public Pai GetPai(SaveAlunoInput alunoPai)
    {
        return new Pai(alunoPai.pai.nome, alunoPai.pai.cpf, alunoPai.pai.rg, alunoPai.pai.endereco, alunoPai.pai.numero,
            alunoPai.pai.uf, alunoPai.pai.dataNascimento);
    }
}

[CollectionDefinition((nameof(SaveAlunoTestFixture)))]
public class SaveAlunoTestCollection : ICollectionFixture<SaveAlunoTestFixture>
{
    
} 