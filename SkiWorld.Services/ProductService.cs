using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiWorld.Data.Models;
using SkiWorld.Data.Infrastructure;
using ServicesPattern;

namespace SkiWorld.Service
{
    public class ProductService : Service<product>
    {
        public static IDatabaseFactory dbf = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbf);
        
     


        public ProductService()  :base(ut)
        {

        }
        public List<product> GetByCategory(int cat)
        {
            return ut.getRepository<product>().GetMany(x => x.idCategory == cat).ToList();
        }


      
    }

}