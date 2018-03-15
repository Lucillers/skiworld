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
    public class RestoService : Service<restaurant>
    {

        public static DatabaseFactory dbFactory = new DatabaseFactory();
        public static UnitOfWork utwk = new UnitOfWork(dbFactory);
        public RestoService() : base(utwk)
        {
        }
    }
}
