using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Models
{
    public class ProdutoResponse
    {
        public int id_produto_pk { get; set; }
        public string produto { get; set; }
        public Categoria id_categoria_fk { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal valor { get; set; }
        public Status status { get; set; }
    }
}
