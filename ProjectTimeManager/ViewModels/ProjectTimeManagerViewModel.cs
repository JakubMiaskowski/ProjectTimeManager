using ProjectTimeManager.Application.Dto;
using ProjectTimeManager.Application.Interfaces;
using ProjectTimeManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace ProjectTimeManager.ViewModels
{
    public class ProjectTimeManagerViewModel : BaseViewModel
    {
        private readonly IProjectService _projectService;

        public ProjectTimeManagerViewModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        private ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects
        {
            get
            {
                return _projects;
            }
            set
            {
                _projects = value;
                OnPropertyChanged("Items");
            }
        }

        public void ReloadProjects()
        {
            var projects = new ObservableCollection<Project>();
            foreach (var project in _projectService.GetAllProjects())
            {
                projects.Add(project);
            }

            Projects = projects;
        }

    }
}
