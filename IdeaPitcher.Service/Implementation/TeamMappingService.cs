using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Implementation
{
    public class TeamMappingService: ITeamMappingService

    {
        private readonly ITeamMappingRepository repository;
        public TeamMappingService(ITeamMappingRepository TeamMappingRepository)
        {
            repository = TeamMappingRepository;
        }
        public IEnumerable<IdeaPitcherUser> GetUsers()
        {
            return repository.getusers();
        }

        public void SetTeam(IEnumerable<IdeaPitcherUser> user)
        {
            repository.SetTeam(user);
        }
    }
}
