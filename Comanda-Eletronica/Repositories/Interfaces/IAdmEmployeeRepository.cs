using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Repositories.Interfaces
{
    public interface IAdmEmployeeRepository
    {
        void CriaFuncionario(FuncionarioRequest funcionarioRequest);
        void RemoveFuncionario(FuncionarioRequest funcionarioRequest);
        void AlteraFuncionario(FuncionarioRequest funcionarioRequest);
        void ResetSenha(FuncionarioRequest funcionarioRequest);
        List<Funcionario> BuscaFuncionarios();
    }
}