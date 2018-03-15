using SkiWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiWorld.Services
{
    public interface IMatchServices
    {

        void create(match c);
        IEnumerable<match> GetByName(int id);
        IEnumerable<match> GetAll();
        match GetById(int id);
        void delete(match match);
        void update(match match);
        //int GetIdByName(string name);


        //liste des subCateg groupé by categ
        // IEnumerable<SubCategory> GetSubCategByCateg(SubCategory category);
        void Commit();
        void Dispose();

    }
}
