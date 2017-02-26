using AutoMapper;
using FingerPrintAccess.API.Models;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.API.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserFormViewModel, User>();
            CreateMap<RoomFormViewModel, Room>();
        }
    }
}