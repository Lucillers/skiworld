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
    public class WorkerService : Service<Worker>
    {
        public static DatabaseFactory dbFactory = new DatabaseFactory();
        public static UnitOfWork utwk = new UnitOfWork(dbFactory);

        public WorkerService() : base(utwk)
        {
        }

    }
}