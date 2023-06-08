using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Interface
{
    public interface IEnableDisableUserService
    {
        void Disables(string Id);

        void Enable(string Id);
    }
}
