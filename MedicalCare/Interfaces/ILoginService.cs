using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface ILoginService
    {
        bool Login(TentativaLoginDto login);
        string GeraTokenJWT(TentativaLoginDto login);
        string GeraNovaSenha(TentativaTrocaDeSenhaDto tentativa);
    }
}