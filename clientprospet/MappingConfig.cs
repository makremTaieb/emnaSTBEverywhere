using AutoMapper;
using clientprospet.models;
using clientprospet.models.Dto;
using clientprospet.Models;

namespace clientprospet
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<ClientProspet, ClientProspetDTO>();
            CreateMap<ClientProspetDTO, ClientProspet>();

            CreateMap<ClientProspet, ClientProspetCreateDTO>().ReverseMap();
            CreateMap<ClientProspet, ClientProspetStep1CreateDTO>().ReverseMap();
            CreateMap<ClientProspet, ClientProspetUpdateDTO>().ReverseMap();
            CreateMap<Adresse, AdresseDTO>().ReverseMap();
            CreateMap<MobileClient, MobileClientDTO>().ReverseMap();
            CreateMap<Documents, DocumentDTO>().ReverseMap();
            
            CreateMap<MailClient, MailClientDTO>().ReverseMap();
            CreateMap<FATCA, FATCADTO>().ReverseMap();
            CreateMap<CIN, CINDTO>().ReverseMap();
            CreateMap<choixagence, choixagenceDTO>().ReverseMap();
        }
    }
}
