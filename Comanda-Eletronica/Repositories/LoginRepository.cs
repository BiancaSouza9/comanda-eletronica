using Comanda_Eletronica.Data;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Comanda_Eletronica.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private ComandaEletronicaContext Context;
        public LoginRepository(ComandaEletronicaContext context)
        {
            Context = context;
        }
        public Funcionario GetLogin(string usuario, string senha)
        {
            return Context.Funcionario.Where(p => p.usuario.Equals (usuario) && p.senha.Equals(senha)).FirstOrDefault();
        }
    }
}
