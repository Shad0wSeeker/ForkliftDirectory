using AutoMapper;
using ForkliftDirectory.Application.DTOs.ForkliftDTOs;
using ForkliftDirectory.Domain.Entities;


namespace ForkliftDirectory.Application.Mapper
{
    public class ForkliftMappingProfile : Profile
    {
        public ForkliftMappingProfile()
        {
            CreateMap<Forklift, ForkliftDto>().ReverseMap();
            CreateMap<CreateForkliftDto, Forklift>();
            CreateMap<UpdateForkliftDto, Forklift>();
        }
    }
}
