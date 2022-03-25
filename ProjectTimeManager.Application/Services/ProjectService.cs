using System;
using System.Collections.Generic;
using System.Linq;
using ProjectTimeManager.Domain.Models;
using ProjectTimeManager.Application.Interfaces;
using ProjectTimeManager.Domain.Interfaces;
using ProjectTimeManager.Application.Dto;

namespace ProjectTimeManager.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepo = projectRepository;
        }
        public List<Project> GetAllProjects()
        {
            return _projectRepo.GetAllProjects();
        }
        public Project GetProjectById(int projectId)
        {
            return _projectRepo.GetProjectById(projectId);
        }
        public void AddNewProject(NewProjectDto projectDto)
        {
            var nextId = GenerateNextId();
            var project = new Project()
            {
                Id = nextId,
                Number = GenerateProjectNumberFromProjectId(nextId),
                Name = projectDto.Name,
                Description = projectDto.Description,
                DeadLine = projectDto.DeadLine,
                PlanedHours = projectDto.PlanedHours,
                SecondCounter = 0,
                NowWorking = false
            };
            _projectRepo.AddProject(project);
        }
        public void EditProject(int projectToEditId, EditProjectDto editedProjectDto)
        {
            var projectToEdit = _projectRepo.GetProjectById(projectToEditId);
            projectToEdit.Name = editedProjectDto.Name;
            projectToEdit.Description = editedProjectDto.Description;
            projectToEdit.DeadLine = editedProjectDto.DeadLine;
            projectToEdit.PlanedHours = editedProjectDto.PlanedHours;
            UpdateProject(projectToEdit);
        }
        public void UpdateProject(Project project)
        {
            _projectRepo.UpdateProject(project);
        }
        public void DeleteProject(int projectId)
        {
            _projectRepo.DeleteProject(projectId);
        }
        public ProjectDetailsDto GetProjectDetails(int projectId)
        {
            var project = GetProjectById(projectId);
            var projectDetails = new ProjectDetailsDto()
            {
                Id = project.Id,
                Number = project.Number,
                Name = project.Name,
                Description = project.Description,
                DeadLine = project.DeadLine.Day + "//" + project.DeadLine.Month + "//" + project.DeadLine.Year,
                PlanedHours = project.PlanedHours,
                ActualHours = SecondsToHours(project.SecondCounter),
                NowWorking = project.NowWorking
            };
            return projectDetails;
        }
        public ProjectForListDto GetProjectForList(Project project)
        {
            var projectForList = new ProjectForListDto()
            {
                Id = project.Id,
                Number = project.Number,
                Name = project.Name,
                PlanedHours = project.PlanedHours,
                ActualHours = SecondsToHours(project.SecondCounter)
            };
            return projectForList;
        }
        public ListOfProjectsDto GetListOfProjects()
        {
            var projects = GetAllProjects();
            var listOfProjects = new List<ProjectForListDto>();
            foreach(var project in projects)
            {
                listOfProjects.Add(GetProjectForList(project));
            }
            return new ListOfProjectsDto()
            {
                Projects = listOfProjects
            }; 
        }
        public DateTime? StartWorkingOnProject(Project project)
        {
            StopProjectsCurrentlyWorkingOn();
            project.NowWorking = true;
            project.WorkStart = DateTime.Now;
            UpdateProject(project);
            return project.WorkStart;
        }
        public void StopWorkingOnProject(Project project)
        {
            project.SecondCounter += CalculateWorkTimeInSeconds(project.WorkStart, DateTime.Now);
            project.NowWorking = false;
            project.WorkStart = null;
            UpdateProject(project);
        }   
        private long CalculateWorkTimeInSeconds(DateTime? workStart, DateTime workStop)
        {
            return CalculateTimeSpan(workStart, workStop).Ticks;
        }
        private double SecondsToHours(long seconds)
        {
            if (seconds==0)
            {
                return 0;
            }
            else
            {
                return Math.Round((double)seconds / 3600, 2);
            }
        }
        private TimeSpan CalculateTimeSpan(DateTime? workStart, DateTime workStop)
        {
            return workStop.Subtract((DateTime)workStart);
        }
        private void StopProjectsCurrentlyWorkingOn()
        {
            var projectsToStop = GetProjectsCurrentlyWorkingOn();
            if(projectsToStop != null)
            {
                foreach(var project in projectsToStop)
                {
                    StopWorkingOnProject(project);
                }
            }
        }
        private List<Project> GetProjectsCurrentlyWorkingOn()
        {
            var projects = GetAllProjects();
            if(projects != null)
            {
                var projectsCurrentylWorkingOn = projects.Where(p => p.NowWorking == true).ToList();
                if(projectsCurrentylWorkingOn != null || projectsCurrentylWorkingOn.Count == 0)
                {
                    return projectsCurrentylWorkingOn;
                }
                else
                {
                    return null;
                } 
            }
            else
            {
                return null;
            }
                    
        }
        private int GetLastProjectId()
        {
            var projects = GetAllProjects();
            if (projects.Any())
            {
                return projects.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                return 0;
            }
        }
        private int GenerateNextId()
        {
            return GetLastProjectId() + 1;
        }
        private string GenerateProjectNumberFromProjectId(int id)
        {
            return @"P/" + id;
        }

    }
}
