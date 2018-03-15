

using ServicesPattern;
using SkiWorld.Data.Infrastructure;
using SkiWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiWorld.Services
{
  public  class CategoryService  : Service<category>
    {
        public static IDatabaseFactory dbf = new DatabaseFactory();
    public static IUnitOfWork ut = new UnitOfWork(dbf);




    public CategoryService()  :base(ut)
        {

        }
        public List<category> getCategories()
        {
            return ut.getRepository<category>().GetMany(x => x.name == "Category").ToList();
        }

        public int countByCategory(int id)
        {
            return ut.getRepository<product>().GetMany(a => a.idCategory == id).ToList().Count<product>();
        }


    }

}
