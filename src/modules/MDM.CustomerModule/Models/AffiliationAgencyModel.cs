using AutoMapper;
using MDM.CustomerModule.Entity.PartyModel;

namespace MDM.CustomerModule.Models;


[AutoMap(typeof(PartyAffiliation))]
public class AffiliationAgencyModel
{
    public string Email { get; set; }

    public string CustomerDTCode { get; set; }

    public Guid AfiliationTypeId { get; set; }

    public int Action { get; set; }
}