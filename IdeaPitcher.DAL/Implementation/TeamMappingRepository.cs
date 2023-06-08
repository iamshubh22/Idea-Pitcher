using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Implementation
{
    public class TeamMappingRepository : ITeamMappingRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdeaPitcherUser> _usermanager;
        public TeamMappingRepository(ApplicationDbContext db, UserManager<IdeaPitcherUser> usermanager)
        {
            _db = db;
            _usermanager = usermanager;
        }

        public IEnumerable<IdeaPitcherUser> getusers()
        {
            var users = _db.Users.ToList();
            var teams = _db.Team.ToList();
           

            var teamSelectList = teams.Select(u => new SelectListItem { Value = u.TeamId.ToString(), Text = u.Name });
          
            foreach (var user in users)
            {
                user.UserSelectList = teamSelectList;
                
            }




            return users;
        }

        public void SetTeam(IEnumerable<IdeaPitcherUser> users)
        {
            foreach (var obj in users)
            {
                var oneuser = _db.Users.FirstOrDefault(u => u.Id == obj.Id);
                oneuser.IsLeader = obj.IsLeader;
                oneuser.TeamId = obj.TeamId;

                // Check if user is already in a role and remove it (except for "Super Admin")
                var roles = _usermanager.GetRolesAsync(oneuser).Result;
                if (roles.Count > 0 && !roles.Contains("SuperAdmin"))
                {
                    _usermanager.RemoveFromRolesAsync(oneuser, roles).Wait();
                }

                if (oneuser.IsLeader)
                {
                    _usermanager.AddToRoleAsync(oneuser, "Leader").Wait();
                }
                else
                {
                    _usermanager.AddToRoleAsync(oneuser, "Basic").Wait();
                }

                _db.Users.Update(oneuser);
            }
            _db.SaveChanges();
        }


    }
}
