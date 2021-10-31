using Comanda_Eletronica.Data;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Repositories
{
    public class AdmTableRepository : IAdmTableRepository
    {
        private ComandaEletronicaContext Context;
        public AdmTableRepository(ComandaEletronicaContext context)
        {
            Context = context;
        }

        public void AdicionaMesa(int quantidade)
        {     

            for (int i = 0; i < quantidade; i ++)
            {
                var mesa = new Mesa()
                {
                    id_status_fk = Enum.Parse<MesaStatus>("Livre")
                };
                Context.Mesa.Add(mesa);
                Context.SaveChanges();
            }            
        }
        public void RemoveMesa(MesaRequest mesaRequest)
        {
            var mesa = Context.Mesa.Find(mesaRequest.IdMesa);
            Context.Mesa.Remove(mesa);
            Context.SaveChanges();
        }
    }
}
