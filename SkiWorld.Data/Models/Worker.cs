using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiWorld.Data.Models
{
    public class Worker : user
    {
        public string ExperienceWorker { get; set; }
        public string Speciality { get; set; }
        public string RegistrationNumber { get; set; }

    }
}
