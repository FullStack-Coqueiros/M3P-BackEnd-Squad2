using AutoMapper;
using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            //Source, Destination

            //mapper usuario
            CreateMap<UsuarioCreateDto, UsuarioModel>()
                .ForMember(dest => dest.Genero, act => act.Ignore())
                .ForMember(dest => dest.Tipo, act => act.Ignore());
            CreateMap<UsuarioUpdateDto, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioGetDto, UsuarioModel>();
            CreateMap<UsuarioModel, UsuarioGetDto>();


            //mapper exame
            CreateMap<ExameCreateDto, ExameModel>();
            CreateMap<ExameModel, ExameGetDto>();
            CreateMap<ExameUpdateDto, ExameModel>().ReverseMap();


            //mapper Dieta
            CreateMap<DietaCreateDto, DietaModel>()
                .ForMember(dest => dest.Tipo, act => act.Ignore());
            CreateMap<DietaGetDto, DietaModel>().ReverseMap();
            CreateMap<DietaUpdateDto, DietaModel>()
                .ForMember(dest => dest.Tipo, act => act.Ignore());

            //mapper Consulta
            CreateMap<ConsultaCreateDTO, ConsultaModel>().ReverseMap();
            CreateMap<ConsultaGetDto, ConsultaModel>().ReverseMap();
            CreateMap<ConsultaUpdateDTO, ConsultaModel>().ReverseMap();

            //mapper Paciente
            CreateMap<IQueryable<PacienteModel>, PacienteGetDto>();
            CreateMap<PacienteCreateDto, PacienteModel>()
                .ForMember(dest => dest.Endereco, act => act.Ignore());
            CreateMap<PacienteGetDto, PacienteModel>().ReverseMap();
            CreateMap<PacienteUpdateDto, PacienteModel>()
                .ForMember(dest => dest.Genero, act => act.Ignore())
                .ForMember(dest => dest.EstadoCivil, act => act.Ignore())
                .ForMember(dest => dest.Cpf, act => act.Ignore())
                .ForMember(dest => dest.Rg, act => act.Ignore());
            CreateMap<PacienteCreateDto, EnderecoModel>()
                .ForMember(dest => dest.Cep, map => map.MapFrom(map => map.Endereco.cep))
                .ForMember(dest => dest.Numero, map => map.MapFrom(map => map.Endereco.Numero))
                .ForMember(dest => dest.Bairro, map => map.MapFrom(map => map.Endereco.bairro))
                .ForMember(dest => dest.Logradouro, map => map.MapFrom(map => map.Endereco.logradouro))
                .ForMember(dest => dest.Cidade, map => map.MapFrom(map => map.Endereco.localidade))
                .ForMember(dest => dest.Complemento, map => map.MapFrom(map => map.Endereco.Complemento))
                .ForMember(dest => dest.PontoDeReferencia, map => map.MapFrom(map => map.Endereco.PontoDeReferencia))
                .ForMember(dest => dest.Estado, map => map.MapFrom(map => map.Endereco.uf));



            //mapper Exercicio
            CreateMap<ExercicioCreateDto, ExercicioModel>().ReverseMap();
            CreateMap<ExercicioGetDto, ExercicioModel>().ReverseMap();
            CreateMap<ExercicioUpdateDto, ExercicioModel>().ReverseMap();

            //mapper Medicamento
            CreateMap<MedicamentoCreateDTO, MedicamentoModel>()
                .ForMember(dest => dest.Tipo, act => act.Ignore())
                .ForMember(dest => dest.Unidade, act => act.Ignore());
            CreateMap<MedicamentoGetDTO, MedicamentoModel>().ReverseMap();
            CreateMap<MedicamentoUpdateDTO, MedicamentoModel>().ReverseMap();


            //mapper Endereco
            CreateMap<EnderecoModel, EnderecoGetDto>();
            CreateMap<EnderecoUpdateDto, EnderecoModel>()
                .ForMember(dest => dest.Cep, map => map.MapFrom(src => src.cep))
                .ForMember(dest => dest.Bairro, map => map.MapFrom(src => src.bairro))
                .ForMember(dest => dest.Logradouro, map => map.MapFrom(src => src.logradouro))
                .ForMember(dest => dest.Cidade, map => map.MapFrom(src => src.localidade))
                .ForMember(dest => dest.Estado, map => map.MapFrom(src => src.uf));
            CreateMap<EnderecoCreateDto, EnderecoModel>()
                .ForMember(dest => dest.Cep, map => map.MapFrom(src => src.cep))
                .ForMember(dest => dest.Bairro, map => map.MapFrom(src => src.bairro))
                .ForMember(dest => dest.Logradouro, map => map.MapFrom(src => src.logradouro))
                .ForMember(dest => dest.Cidade, map => map.MapFrom(src => src.localidade))
                .ForMember(dest => dest.Estado, map => map.MapFrom(src => src.uf));

        }

    }
}
