using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using IdeaPitcher.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdeaPitcher.DAL.Data;

// Add profile data for application users by adding properties to the IdeaPitcherUser class
public class IdeaPitcherUser : IdentityUser
{
    public string? Name { get; set; }

    public int TeamId { get; set; } // foreign key to TeamModel

    [ForeignKey("TeamId")]

    public virtual TeamModel Teams { get; set; } // navigation property to Team

    [NotMapped]
    public IEnumerable<SelectListItem> UserSelectList { get; set; }

    public Boolean IsLeader { get; set; }

    public string? ProfileImagePath { get; set; }
    [NotMapped]
    public IFormFile ProfileImage { get; set; }


}

