using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Implementation
{
       
        public class EnableDisable : IEnableDisableUserService

        {
            private readonly IEnableDisableUserRepository repository;
            public EnableDisable(IEnableDisableUserRepository EnableDisableRepository)
            {
                repository = EnableDisableRepository;
            }
            public void Disables(string Id)
            {
                repository.Disable(Id);
            }

            public void Enable(string Id)
            {
                repository.Enable(Id);
            }


        }


}
