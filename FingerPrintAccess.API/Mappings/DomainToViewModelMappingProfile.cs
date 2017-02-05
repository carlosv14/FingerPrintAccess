using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FingerPrintAccess.API.Models;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.API.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserFormViewModel>();
        }
    }
}