using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using ProjectTimeManager.Domain;
using ProjectTimeManager.Domain.Models;
using ProjectTimeManager.Domain.Interfaces;
using ProjectTimeManager.Application.Services;
using ProjectTimeManager.Application.Interfaces;
using ProjectTimeManager.Infrastructure.Repositories;
using ProjectTimeManager.ViewModels;

namespace ProjectTimeManager.Ninject
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectRepository>().To<ProjectRepositoryMock>();
            Bind<IProjectService>().To<ProjectService>();
            Bind<ProjectTimeManagerViewModel>().ToSelf();
            Bind<ProjectListViewModel>().ToSelf();
            Bind<ProjectDetailsViewModel>().ToSelf();
        }
    }
}
