using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comanda_Eletronica.Entities;

namespace Comanda_Eletronica.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Funcionario GetLogin(string usuario, string senha);
    }
}
