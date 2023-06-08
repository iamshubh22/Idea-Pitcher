using IdeaPitcher.DAL.Data;
using IdeaPitcher.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Comment text cannot be empty")]

        public string CommentText { get; set; }

        public DateTime Datecreated { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public string Author { get; set; }

    }
}
