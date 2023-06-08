using IdeaPitcher.DAL.Interface;
using IdeaPitcher.DAL.Models;
using IdeaPitcher.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Implementation
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly ISuperAdminRepository repository;
        public SuperAdminService(ISuperAdminRepository superadminrepository)
        {
            repository = superadminrepository;
        }

        public TeamModel CreateDrop()
        {
            return repository.CreateDrop();
        }

        public void CreateTeam(TeamModel teamdata)
        {
           repository.Createteam(teamdata);
        }
    }
}
