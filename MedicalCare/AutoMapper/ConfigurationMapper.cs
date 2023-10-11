using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        protected ConfigurationMapper()
        {

            //mapper usuario
            CreateMap<UsuarioCreateDto, UsuarioModel>().ReverseMap();//usar ReverseMap(),  não precisa criar  mapeamento separado no sentido oposto.
            CreateMap<UsuarioUpdateDto, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioGetDto, UsuarioModel>();
            CreateMap<UsuarioModel, UsuarioGetDto>();


            //mapper exame
            CreateMap<ExameCreateDto, ExameModel>().ReverseMap();
            CreateMap<ExameGetDto, ExameModel>().ReverseMap();
            CreateMap<ExameUpdateDto, ExameModel>().ReverseMap();


            //mapper Dieta
            CreateMap<DietaCreateDto, DietaModel>().ReverseMap();
            CreateMap<DietaGetDto, DietaModel>().ReverseMap();
            CreateMap<DietaUpdateDto, DietaModel>().ReverseMap();

            //mapper Consulta
            CreateMap<ConsultaCreateDTO, ConsultaModel>().ReverseMap();
            CreateMap<ConsultaGetDto, ConsultaModel>().ReverseMap();
            CreateMap<ConsultaUpdateDTO, ConsultaModel>().ReverseMap();

        }

    }
}
