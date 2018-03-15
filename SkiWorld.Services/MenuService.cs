
using ServicesPattern;
using SkiWorld.Data.Infrastructure;
using SkiWorld.Data.Models;
using SkiWorld.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiWorld.Services
{
    public class MenuService : Service<menu>
    {
        public static DatabaseFactory dbFactory = new DatabaseFactory();
        public static UnitOfWork utwk = new UnitOfWork(dbFactory);

        public MenuService() : base(utwk)
        {
        }
        //public List<menu> getmenuByrestaurant(int id)
        //{
        //    return utwk.MenuRepository.GetAll().Where(i => i.restaurant_idRestaurant == id && i.restaurant_idRestaurant == i.Restaurant.idRestaurant).ToList();
        //}
    }
}
