using IdeaPitcher.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Interface
{
    public interface ITeamMappingService
    {
        public IEnumerable<IdeaPitcherUser> GetUsers();

        public void SetTeam(IEnumerable<IdeaPitcherUser> user);
    }
}
