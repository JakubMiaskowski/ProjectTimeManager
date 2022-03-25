using ProjectTimeManager.Domain.Interfaces;
using ProjectTimeManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.Infrastructure.Repositories
{
    public class ProjectRepositoryMock : IProjectRepository
    {
        private List<Project> _projects;
        public ProjectRepositoryMock()
        {
            InitializeProjects();
        }
        public void AddProject(Project project)
        {
            _projects.Add(project);
        }

        public void DeleteProject(int projectId)
        {
            var projectToDelete = _projects.FirstOrDefault(p => p.Id == projectId);
            if (projectToDelete != null)
            {
                _projects.Remove(projectToDelete);
            }
        }

        public List<Project> GetAllProjects()
        {
            return _projects;
        }

        public Project GetProjectById(int projectId)
        {
            var projectToReturn = _projects.FirstOrDefault(p => p.Id == projectId);
            if (projectToReturn != null)
                return projectToReturn;
            throw new Exception($"Item with id {projectId} doesn't exist");
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
        private void InitializeProjects()
        {
            _projects = new List<Project>();
            _projects.Add(new Project
            {
                Id = 1,
                Number = "001",
                Name = "Project1",
                Description = "Description1",
                DeadLine = DateTime.Now + TimeSpan.FromDays(50),
                PlanedHours = 50,
                NowWorking = false
            });

            _projects.Add(new Project
            {
                Id = 2,
                Number = "002",
                Name = "Project2",
                Description = "Description2",
                DeadLine = DateTime.Now + TimeSpan.FromDays(50),
                PlanedHours = 50,
                NowWorking = false
            });

            _projects.Add(new Project
            {
                Id = 3,
                Number = "003",
                Name = "Project3",
                Description = "Description3",
                DeadLine = DateTime.Now + TimeSpan.FromDays(50),
                PlanedHours = 50,
                NowWorking = false
            });
        }
    }
}
