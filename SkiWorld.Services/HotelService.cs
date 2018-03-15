
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
    public class HotelService : Service<hotel>
    {
        public static DatabaseFactory dbf = new DatabaseFactory();
        public static UnitOfWork utw = new UnitOfWork(dbf);
        public HotelService() : base(utw)
        {

        }
        public List<user> getUsers(int id)
        {
            RoomService rs = new RoomService();
            List<user> users = new List<user>();
            IEnumerable<room> roms = new List<room>();
            ICollection<roomreservation> rss = new List<roomreservation>();
            skiworldContext sc = new skiworldContext();
        //  roms = rs.getByHotel(id);
            roms = rs.GetAll();

              foreach (room r in roms)
              {
                   rss= r.roomreservations ;
                  foreach (roomreservation rr in rss)
                  {
                      users.Add(rr.user);

                  }

              }
           /* var query = from c in sc.roomreservation
                       
                        where c.id_room == id
                        select c;
            query.ToList();
            foreach (roomreservation r in query)
            {
                
                    users.Add(r.user);

               

            }*/
            
            return users;
        }
    }
}

