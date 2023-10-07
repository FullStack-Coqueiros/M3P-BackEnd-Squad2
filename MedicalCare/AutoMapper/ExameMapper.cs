
using AutoMapper;
using MedicalCare.Models;
using MedicalCare.DTO;

namespace MedicalCare.AutoMapper
{
    public class ExameMapper : Profile
    {
        public ExameMapper()
        {
            CreateMap<ExameDTO, ExameModel>();
            CreateMap<ExameModel, ExameDTO>();
        }
    }
}