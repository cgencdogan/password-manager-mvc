using AutoMapper;
using Common.DataTransferObjects;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper;
public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<SavedPassword, SavedPasswordDto>().ReverseMap();
    }
}
