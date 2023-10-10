using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.AutoMapper
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioCreateDto, UsuarioModel>().ReverseMap();//usar ReverseMap(),  não precisa criar  mapeamento separado no sentido oposto.
            CreateMap<UsuarioUpdateDto, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioGetDto, UsuarioModel>();
            CreateMap<UsuarioModel, UsuarioGetDto>();
            

        }
    }
}
