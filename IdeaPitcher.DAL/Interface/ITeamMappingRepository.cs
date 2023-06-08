using IdeaPitcher.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Interface
{
    public interface ITeamMappingRepository
    {
        public IEnumerable<IdeaPitcherUser> getusers();
        public void SetTeam(IEnumerable<IdeaPitcherUser> users);
    }
}
