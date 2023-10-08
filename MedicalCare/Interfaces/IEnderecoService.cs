using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface IEnderecoService
    {
        IEnumerable<EnderecoModel> GetAllEnderecos();
        EnderecoModel CreateEndereco(EnderecoModel endereco);

    }
}