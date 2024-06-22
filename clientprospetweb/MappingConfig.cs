using AutoMapper;
using clientprospetweb.models.Dto;


namespace clientprospetweb
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<clientprospetDTO, clientprospetCreateDTO>().ReverseMap();
            CreateMap<clientprospetDTO, clientprospetUpdateDTO>().ReverseMap();
        }
    }
}
