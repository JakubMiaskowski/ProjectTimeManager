using System;
using System.Collections.Generic;
using System.Linq;
using ProjectTimeManager.Domain.Models;
using ProjectTimeManager.Application.Dto;

namespace ProjectTimeManager.Application.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();
        Project GetProjectById(int projectId);
        void AddNewProject(NewProjectDto projectDto);
        void EditProject(int projectToEditId, EditProjectDto editedProjectDto);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
        ProjectDetailsDto GetProjectDetails(int projectId);
        ProjectForListDto GetProjectForList(Project project);
        ListOfProjectsDto GetListOfProjects();
        DateTime? StartWorkingOnProject(Project project);
        void StopWorkingOnProject(Project project);
    }
}
