using Comanda_Eletronica.Data;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            int id = PegarUltimoId();

            for (int i = 0; i < quantidade; i ++)
            {
                var mesa = Context.Mesa.Find(id);
                mesa.id_status_fk = Enum.Parse<MesaStatus>("Livre");
                mesa.status = Enum.Parse<Status>("Ativo");
                Context.Mesa.Update(mesa);
                id++;
            }
            Context.SaveChanges();
        }
        public void RemoveMesa(MesaRequest mesaRequest)
        {
            var mesa = Context.Mesa.Find(mesaRequest.IdMesa);

            mesa.status = Enum.Parse<Status>("Inativo");
            
            Context.SaveChanges();
        }
        public List<Mesa> BuscaMesas()
        {
            return Context.Mesa.Where(m => m.status.Equals(Status.Ativo)).ToList();
        }

        public int PegarUltimoId()
        {
            return Context.Mesa.Where(x => x.status.Equals(Enum.Parse<Status>("Inativo")))
                .OrderBy(x => x.id_mesa_pk).FirstOrDefault().id_mesa_pk;   
        }
    }
}