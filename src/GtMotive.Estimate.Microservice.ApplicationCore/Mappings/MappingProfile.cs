using AutoMapper;
using GtMotive.Estimate.Microservice.Domain.Models;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Mappings
{
    /// <summary>
    /// Mappings Profiles.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
        }
    }
}
