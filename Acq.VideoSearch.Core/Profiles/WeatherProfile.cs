using Acq.VideoSearch.Core.Dto;
using Acq.VideoSearch.Core.Models;
using AutoMapper;

namespace Acq.VideoSearch.Core.Profiles
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<WeatherCreateDto, Weather>();
            CreateMap<WeatherUpdateDto, Weather>();
            CreateMap<Weather, WeatherReadDto>();
        }
    }
}
