using IdeaPitcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Interface
{
    public interface ISuperAdminRepository
    {
        void Createteam(TeamModel teamdata);
        public TeamModel CreateDrop();
    }
}
