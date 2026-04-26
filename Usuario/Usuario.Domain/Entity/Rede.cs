using System;
using Usuario.Domain.DataTransferObject;
using Usuario.Domain.SeedWork;

namespace Usuario.Domain.Entity;

public class Rede : AggregationRoot
{
    public int Id { get; set; }
    public string DS_REDE { get; set;}


    public Rede FromRedeDto(RedeDto redeDto)
    {
        Id = redeDto.id;
        DS_REDE = redeDto.razaoSocial;
        return this;
    }
}
