﻿using ServicesPattern;
using SkiWorld.Data.Infrastructure;
using SkiWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiWorld.Services
{
  public  class ProfilService:Service<user>
    {
        public static DatabaseFactory dbf = new DatabaseFactory();
        public static UnitOfWork utw = new UnitOfWork(dbf);
        public ProfilService():base(utw)
        {

        }
    }
}