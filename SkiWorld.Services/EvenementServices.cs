
using ServicesPattern;
using SkiWorld.Data.Infrastructure;
using SkiWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiWorld.Service
{
    public class EvenementServices : Service<evenement>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public EvenementServices() : base(ut)
        {
        }

    }
}
