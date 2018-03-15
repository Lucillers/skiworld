
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
   public class RoomService:Service<room>
    {
        public static DatabaseFactory dbf = new DatabaseFactory();
        public static UnitOfWork utw = new UnitOfWork(dbf);
        public RoomService():base(utw)
        {

        }
        public IEnumerable<room> getByHotel(int id)
        {
            return utw.getRepository<room>().GetMany(x => x.hotel_idHotel == id);
        }
    }
}
