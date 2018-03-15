
using SkiWorld.Data.Infrastructure;
using SkiWorld.Data.Models;
using SkiWorld.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiWorld.Data.Repositories;

namespace SkiWorld.Services
{
    public class CompetitionServices : ICompetitionServices
    {
        static public DatabaseFactory dbFactory = new DatabaseFactory();
        UnitOfWorkk utwk = new UnitOfWorkk(dbFactory);


        public void Add(competition e)
        {
            utwk.CompetitionRepository.Add(e);
            utwk.Commit();
        }
        public void Remove(competition e)
        {
            utwk.CompetitionRepository.Delete(e);
            utwk.Commit();
        }

        public competition Find(int i)
        {
            return utwk.CompetitionRepository.GetById(i);

        }
        public List<competition> getAll()
        {
            return utwk.CompetitionRepository.GetAll().ToList();

        }
        public int stat()
        {
            var c = getAll();
            return c.Count();
        }
        public void Edit(competition e)
        {

            utwk.CompetitionRepository.Update(e);
        }

        public competition GetById(int id)
        {
            return utwk.CompetitionRepository.GetById(id);
        }
    }

    public interface ICompetitionServices
    {
        void Add(competition e);
        List<competition> getAll();
        void Edit(competition e);
        void Remove(competition e);
        int stat();
        competition Find(int i);
        competition GetById(int id);
    }

}
