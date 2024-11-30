using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasEntity1.Model
{
    [Table("Vendas")]
    internal class Vendas
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVenda { get; set; }
        public Decimal Valor { get; set; }
           
    }
}
