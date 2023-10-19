using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalCare.DTO;

namespace MedicalCare.Interfaces
{
    public interface ILoginService
    {
        bool Login(TentativaLoginDto login);
        int GeraTokenJWT(TentativaLoginDto login);

        string GeraNovaSenha(TentativaTrocaDeSenhaDto tentativa);
    }
}