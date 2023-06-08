using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Interface
{
    public interface IEnableDisableUserRepository
    {
        void Disable(string Id);

        void Enable(string Id);
    }
}
