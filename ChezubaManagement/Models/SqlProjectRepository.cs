using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChezubaManagement.Models
{
    public class SqlProjectRepository : IProjectRepository
    {
        private readonly UseDbContext context;

        public SqlProjectRepository(UseDbContext context)
        {
            this.context = context;
        }
        public Project Add(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return project;
        }

      

        public IEnumerable<Project> GetAllProjects()
        {
            return context.Projects;
        }

        public Project GetProject(int Id)
        {
           return context.Projects.Find(Id);
        }

        public Project Update(Project projectChanges)
        {
            var project = context.Projects.Attach(projectChanges);
            project.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return projectChanges;
        }
    }
}
