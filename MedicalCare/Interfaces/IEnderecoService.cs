using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IEnderecoService
    {
        IEnumerable<EnderecoModel> GetAllEnderecos();
        EnderecoGetDto CreateEndereco(EnderecoCreateDto endereco);
        EnderecoModel GetById(int id);
        EnderecoGetDto GetByRelationship(PacienteModel relationship);
        EnderecoModel UpdateEndereco(EnderecoModel endereco);
        bool DeleteEndereco(int id);

    }
}