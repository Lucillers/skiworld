
using SkiWorld.Data.Infrastructure;
using SkiWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiWorld.Data.Repositories;

namespace SkiWorld.Services
{
    public class MatchServices : IMatchServices
    {
        IDatabaseFactory dbfactory = null;
        UnitOfWorkk uow = null;
        private List<competition> match = null;
        
        public MatchServices()
        {
            dbfactory = new DatabaseFactory();
            uow = new UnitOfWorkk(dbfactory);

        }

        public void Commit()
        {
            uow.Commit();
        }

        public void create(match c)
        {
            uow.MatchRepository.Add(c);
            uow.Commit();
        }

        public void delete(match match)
        {
            uow.MatchRepository.Delete(match);
            uow.Commit();
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public IEnumerable<match> GetAll()
        {
            return uow.MatchRepository.GetAll().ToList();
        }

        public match GetById(int id)
        {
            return uow.MatchRepository.GetById(id);
        }

        public IEnumerable<match> GetByName(int id)
        {
            return uow.MatchRepository.GetMany(x => x.competition.idComp == id);
        }

       // public int GetIdByName(string name)
       // {
        //    return MatchRepository.GetByName(name).SubCategoryId;
       // }

        public void update(match match)
        {
            uow.MatchRepository.Update(match);
            uow.Commit();
        }
    }
}
