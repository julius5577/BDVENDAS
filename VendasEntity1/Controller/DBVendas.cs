using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasEntity1.Model;

namespace VendasEntity1.Controller
{
    internal class DBVendas : DbContext
    {
        public DBVendas()  : base(@"Sever=JUN0675621W10-1\BDSENAC;database=BDVendas;
                                    user id=senaclivre; password = senaclivre")
        
        
        
        {
        
        }

        public DbSet<Vendas> vendas { get; set; }   
    }
}
