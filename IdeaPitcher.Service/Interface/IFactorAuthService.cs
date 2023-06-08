using IdeaPitcher.DAL.Data;
using IdeaPitcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Interface
{
    public interface IFactorAuthService
    {
       void FactorAuth(IdeaPitcherUser obj);

        IdeaPitcherUser? Check_User(string id);

        IEnumerable<IdeaPitcherUser> find_all();
    }
}
