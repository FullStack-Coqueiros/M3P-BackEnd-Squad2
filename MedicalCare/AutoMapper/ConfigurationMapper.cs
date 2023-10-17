using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {

            //mapper usuario
            CreateMap<UsuarioCreateDto, UsuarioModel>().ReverseMap();//usar ReverseMap(),  não precisa criar  mapeamento separado no sentido oposto.
            CreateMap<UsuarioUpdateDto, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioGetDto, UsuarioModel>();
            CreateMap<UsuarioModel, UsuarioGetDto>()
                .ForMember(dest => dest.Cpf, act => act.Ignore());


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

            //mapper Paciente
            CreateMap<PacienteCreateDto, PacienteModel>().ReverseMap();
            CreateMap<PacienteGetDto, PacienteModel>().ReverseMap();
            CreateMap<PacienteUpdateDto, PacienteModel>()
                .ForMember(dest => dest.Cpf, act => act.Ignore())
                .ForMember(dest => dest.Rg, act => act.Ignore());


            //mapper Exercicio
            CreateMap<ExercicioCreateDto, ExercicioModel>().ReverseMap();
            CreateMap<ExercicioGetDto, ExercicioModel>().ReverseMap();
            CreateMap<ExercicioUpdateDto, ExercicioModel>().ReverseMap();

            //mapper Medicamento
            CreateMap<MedicamentoCreateDTO, MedicamentoModel>().ReverseMap();
            CreateMap<MedicamentoGetDTO, MedicamentoModel>().ReverseMap();
            CreateMap<MedicamentoUpdateDTO, MedicamentoModel>().ReverseMap(); 


        }

    }
}
