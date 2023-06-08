using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Models;
using IdeaPitcher.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Implementation
{
   
        public class FactorAuthService: IFactorAuthService

        {
            private readonly IFactorAuthRepository repository;
            public FactorAuthService(IFactorAuthRepository  factorAuthRepository)
            {
                repository = factorAuthRepository;
            }
            public void FactorAuth(IdeaPitcherUser obj)
            {
                 repository.FactorAuthenticate(obj);
            }
            public IdeaPitcherUser? Check_User(string id)
            {
                return repository.Check_User(id);
            }

            public IEnumerable<IdeaPitcherUser> find_all()
            {
                return repository.find_all();
            }
    }
}

