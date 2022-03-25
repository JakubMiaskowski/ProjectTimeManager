using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ProjectTimeManager.Domain.Models;
using ProjectTimeManager.Domain.Interfaces;


namespace ProjectTimeManager.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private IDbConnection _dbConnection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-8K1VQVC;Initial Catalog=TestBase;Integrated Security=True");
        }
        public void AddProject(Project project)
        {
            var p = new DynamicParameters(GetProjectParameters(project));
            var query = "INSERT INTO dbo.Project (Id, Number, Name, Description, DeadLine, PlanedHours, SecondCounter, NowWorking, WorkStart) " +
                "VALUES (@ID, @NUMBER, @NAME, @DESCRIPTION, @DEAD_LINE, @PLANED_HOURS, @SECOND_COUNTER, @NOW_WORKING, @WORK_START);";
            using (var connection = _dbConnection())
            {
                connection.Execute(query, p);
            }
        }
        public void UpdateProject(Project project)
        {
            var p = new DynamicParameters(GetProjectParameters(project));
            var query = "UPDATE dbo.Project SET Name = @NAME, Description = @DESCRIPTION, " +
                "DeadLine = @DEAD_LINE, PlanedHours = @PLANED_HOURS, SecondCounter = @SECONDS_COUNTER, " +
                "NowWorking = @NOW_WORKING, WorkStart = @WORK_START WHERE Id = @Id;";
            using (var connection = _dbConnection())
            {
                connection.Execute(query, p);
            }
        }
        public void DeleteProject(int projectId)
        {
            using (var connection = _dbConnection())
            {
                connection.Execute(DeleteProjectByIdQuery(projectId));
            }
        }
        public List<Project> GetAllProjects()
        {
            using (var connection = _dbConnection())
            {
               return connection.Query<Project>(GetAllProjectsQuery()).ToList();
            }

        }
        public Project GetProjectById(int projectId)
        {
            using(var connection = _dbConnection())
            {
                return connection.QueryFirstOrDefault<Project>(GetProjectByIdQuery(projectId));
            }
        }
        private string GetAllProjectsQuery()
        {
            return "SELECT * FROM dbo.Project";
        }
        private string GetProjectByIdQuery(int id)
        {
            return $"SELECT * FROM dbo.Project WHERE Id = {id};";
        }
        private string DeleteProjectByIdQuery(int id)
        {
            return $"DELETE FROM dbo.Project WHERE Id = {id};";
        }

        private Dictionary<string,object> GetProjectParameters(Project project)
        {
            return new Dictionary<string, object>()
            {
                {"@ID", project.Id},
                {"@NUMBER", project.Number},
                {"@NAME", project.Name},
                {"@DESCRIPTION", project.Description},
                {"@DEAD_LINE", project.DeadLine},
                {"@PLANED_HOURS", project.PlanedHours},
                {"@SECOND_COUNTER", project.SecondCounter},
                {"@NOW_WORKING", project.NowWorking},
                {"@WORK_START", project.WorkStart}
            };
        }




    }
}
