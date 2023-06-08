using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Implementation
{
    public class FactorAuthRepository : IFactorAuthRepository
    {
        private readonly ApplicationDbContext _db;

        public FactorAuthRepository(ApplicationDbContext db)

        {
            _db = db;
        }
        public void FactorAuthenticate(IdeaPitcherUser obj)
        {
            var Factor = _db.Users.FirstOrDefault(u => u.Id== obj.Id);
            if (Factor != null)
            {
                Factor.TwoFactorEnabled = obj.TwoFactorEnabled;
                _db.Users.Update(Factor);
                _db.SaveChanges();

            }
            
        }

        public IdeaPitcherUser? Check_User(string id)
        {
            var checks = _db.Users.Find(id);

            return checks;
        }

        public IEnumerable<IdeaPitcherUser> find_all()
        {
            IEnumerable<IdeaPitcherUser> objUserList = _db.Users;
            //IEnumerable<ContentModel> objUserList = _db.Posts.Where(Id =>) // If not wont to use permisssions then use linq
            return objUserList;
        }
    }
}
