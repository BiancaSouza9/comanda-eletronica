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
            int id = PegarUltimoId() + 1;

            for (int i = 0; i < quantidade; i ++)
            {                  
                var mesa = new Mesa()
                {
                    id_mesa_pk = id,
                    id_status_fk = Enum.Parse<MesaStatus>("Livre"),
                    status = Enum.Parse<Status>("Ativo")
                };
                Context.Mesa.Add(mesa);
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
            return Context.Mesa.ToList();
        }

        public int PegarUltimoId()
        {
            return Context.Mesa.OrderByDescending(x => x.id_mesa_pk).FirstOrDefault().id_mesa_pk;        
        }
    }
}