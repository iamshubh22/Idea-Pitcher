
using IdeaPitcher.DAL.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaPitcher.DAL.Models
{
    public class TeamModel
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }


        public string TeamLeaderId { get; set; } // foreign key to User

        public IdeaPitcherUser TeamLeader { get; set; } // navigation property to User

        [NotMapped]
        public IEnumerable<SelectListItem> UserSelectList { get; set; }


    }
}
