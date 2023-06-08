using IdeaPitcher.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Interface
{
    public interface IChangeIdeaRepository 
    {
        void change_ideas(string name,int id);
        ContentModel? Check_Idea(int id);
    }
}
