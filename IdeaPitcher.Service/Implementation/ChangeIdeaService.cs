using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Models;
using IdeaPitcher.Service.Interface;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Implementation
{
    public class OwnerChange: IChangeIdeaService

    {
        private readonly IChangeIdeaRepository repository;
        public OwnerChange(IChangeIdeaRepository changeIdeaRepository)
        {
            repository = changeIdeaRepository;
        }
        public void ownerChanges(string name,int id)
        {
            repository.change_ideas(name,id);
        }

        public ContentModel? CheckIdea(int Id)
        {
           return repository.Check_Idea(Id);
        }
    }
}

