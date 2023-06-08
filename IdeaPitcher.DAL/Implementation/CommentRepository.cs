using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Implementation
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void postComment(CommentModel comment)
        {
            if (comment != null)
            {

                //var Author = User
                _db.Comment.Add(comment);
                _db.SaveChanges();
            }

        }

        public IEnumerable<CommentModel> GetComments(int id)
        {
            

            IEnumerable<CommentModel> comments = _db.Comment.Where(c => c.AuthorId == id).ToList();
            return comments;


        }



    }
}