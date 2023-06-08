using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Implementation
{
    public class EnableDisableUserRepository : IEnableDisableUserRepository
    {
        private readonly SignInManager<IdeaPitcherUser> _SignInManager;
        private readonly ApplicationDbContext _db;
        public EnableDisableUserRepository(SignInManager<IdeaPitcherUser> SignInManager, ApplicationDbContext db)
        {
            _SignInManager = SignInManager;
            _db = db;
        }
        public void Disable(string Id)
        {
             //_SignInManager.LockedOut(Name);

            var lmt = _db.Users.SingleOrDefault(u => u.Id == Id);

            if (lmt!=null)
            {
                lmt.LockoutEnd= DateTime.Now.AddDays(10);
                _db.Users.Update(lmt);
                _db.SaveChanges();
            }


        }
        public void Enable(string Id)
        {
            var lmtE = _db.Users.SingleOrDefault(u => u.Id == Id);

            if (lmtE != null)
            {
                lmtE.LockoutEnd = DateTime.Now;
                _db.Users.Update(lmtE);
                _db.SaveChanges();
            }
        }
    }
}

