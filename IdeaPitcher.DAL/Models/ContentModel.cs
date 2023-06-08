
using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaPitcher.Models
{
    public class ContentModel
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Idea { get; set; }
        
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }
        [Required]
        
        public string? IdeaImage { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        //public byte[] ImageBytes { get; set; }

        [Required]
        
        public string createdby { get; set; }
        
        public IEnumerable<CommentModel> Comments { get; set; }
        
        public Boolean Drafted { get; set; }

        public Boolean isVisible { get; set; }

        public int Tid { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> UserSelectList { get; set; }

    }
}
