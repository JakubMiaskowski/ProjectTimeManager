using ProjectTimeManager.Application.Interfaces;
using ProjectTimeManager.Domain.Models;
using System.Collections.Generic;

namespace ProjectTimeManager.ViewModels
{
    public class ProjectTimeManagerViewModel
    {
        private readonly IProjectService _projectService;
        public ProjectTimeManagerViewModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public List<Project> Projects 
        {
            get
            {
                return _projectService.GetAllProjects();
            }
        }

    }
}
