using IdeaPitcher.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Interface
{
    public interface IChangeIdeaService
    {
        void ownerChanges(string name,int id);
        ContentModel? CheckIdea(int Id);
    }
}
