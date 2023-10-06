using AutoMapper;
using MedicalCare.Models;
using MedicalCare.DTOs;

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
