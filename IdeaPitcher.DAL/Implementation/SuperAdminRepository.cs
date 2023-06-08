using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IdeaPitcher.DAL.Implementation
{
    public class SuperAdminRepository:ISuperAdminRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdeaPitcherUser> _usermanager;
        public SuperAdminRepository(ApplicationDbContext db, UserManager<IdeaPitcherUser> usermanager)

        {
            _db = db;
            _usermanager = usermanager;
        }

        public void Createteam(TeamModel teamdata)
        {

            var leaderUser = _db.Users.FirstOrDefault(u => u.Id == teamdata.TeamLeaderId);
            leaderUser.IsLeader = true;
            if (leaderUser.IsLeader)
            {
                _usermanager.AddToRoleAsync(leaderUser, "Leader");
            }
            if (teamdata != null)
            {   
                _db.Team.Add(teamdata);
                _db.SaveChanges();
            }
            if (leaderUser != null)
            {
                leaderUser.TeamId = teamdata.TeamId;


                _db.SaveChanges();
            }

        }

        public TeamModel CreateDrop()
        {   

            var users = _db.Users.ToList();
            var userSelectList = users.Select(u => new SelectListItem { Value = u.Id, Text = u.UserName });

            var model = new TeamModel
            {
                UserSelectList = userSelectList
            };

            return model;
        }

    }
}
