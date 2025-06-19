using AutoMapper;
using ForkliftDirectory.Application.DTOs.ForkliftDowntimeDTOs;
using ForkliftDirectory.Domain.Entities;

namespace ForkliftDirectory.Application.Mapper
{
    public class ForkliftDowntimeMappingProfile : Profile
    {
        public ForkliftDowntimeMappingProfile()
        {
            CreateMap<ForkliftDowntime, ForkliftDowntimeDto>()
                .ForMember(dest => dest.DowntimeDuration, opt => opt.MapFrom(src =>
                    (src.EndTime == null ? DateTime.UtcNow : src.EndTime) - src.StartTime));

            CreateMap<CreateForkliftDowntimeDto, ForkliftDowntime>();
            CreateMap<UpdateForkliftDowntimeDto, ForkliftDowntime>();
        }
    }

}
