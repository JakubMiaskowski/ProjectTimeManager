using System.Collections.Generic;
using ProjectTimeManager.Domain.Models;


namespace ProjectTimeManager.Domain.Interfaces
{
    public interface IProjectRepository
    {
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
        List<Project> GetAllProjects();
        Project GetProjectById(int projectId);
    }
}
