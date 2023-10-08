using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.AutoMapper
{
    public class DietaMapper : Profile
    {
        public DietaMapper()
        {
            CreateMap<DietaCreateDTO, DietaModel>().ReverseMap();//usar ReverseMap(),  não precisa criar  mapeamento separado no sentido oposto.
            CreateMap<DietaUpdateDTO, DietaModel>().ReverseMap();
            CreateMap<DietaModel, DietaGetDTO>().ReverseMap();
        }
    }
}
