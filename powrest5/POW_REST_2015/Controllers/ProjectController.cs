using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Models;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class ProjectController : ApiController
    {
        private ProjectRepository projectRepository;

        public ProjectController()
        {
            this.projectRepository = new ProjectRepository();
        }


        public List<CProject> Get(string year, string type, string team, string program)
        {
            if(type == "media")
            {
                return projectRepository.getProjectsByProgram(year, "Team", program);
            }
            else
            {
                return projectRepository.getProjects(year, type, team, program);
            }
        }
       
        public List<CProject> Get(string year, string UserID, string type)
        {
            return projectRepository.getMyProjects(year, UserID, type);
        }      

        public List<CProject> Get(string year, string ID)
        {
            return projectRepository.getProjectbyID(year, ID);
        }
        
        public List<CProject> GetByUID(string year, string UID)
        {
            return projectRepository.getIndividualProjectsbyUID(year, UID);
        }

        public List<CProject> GetByYear(string year)
        {
            return projectRepository.getProjectsbyYear(year);
        }

        public List<CProject> Get(string ID)
        {
            return projectRepository.getProjectbyID("2015", ID);
        }                
    }
}
