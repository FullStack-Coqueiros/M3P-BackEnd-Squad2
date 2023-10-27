using MedicalCare.DTO;
using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IEnderecoService
    {
        IEnumerable<EnderecoModel> GetAllEnderecos();
        EnderecoGetDto CreateEndereco(EnderecoCreateDto endereco);
        EnderecoModel GetById(int id);
        EnderecoGetDto GetByRelationship(int id);
        EnderecoGetDto UpdateEndereco(EnderecoUpdateDto endereco, int id);
        bool DeleteEndereco(int id);

    }
}