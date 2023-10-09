using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IEnderecoService
    {
        IEnumerable<EnderecoModel> GetAllEnderecos();
        EnderecoModel CreateEndereco(EnderecoModel endereco);
        EnderecoModel GetById(int id);
        EnderecoModel UpdateEndereco(EnderecoModel endereco);
        bool DeleteEndereco(int id);

    }
}