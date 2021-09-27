//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ChezubaManagement.Models
//{
//    public class MockProjectRepository : IProjectRepository
//    {
//        private List<Project> _projectList;

//        public MockProjectRepository()
//        {
//            _projectList = new List<Project>()
//            {
//                new Project() { Id = 1, NGO_name="Waasta", Heading="Advocate", Site="Onsite", Duration= 2 , Time_com= 2 , Address=" Kharag Singh Road", Name=" Rajesh Verma", Phone= 123456789},
//                new Project() { Id = 2, NGO_name="Niswarth", Heading="Graphic Designer", Site="Online", Duration= 1 , Time_com= 12 , Address=" Uttoroyan,F-Block", Name=" Sameer Lama", Phone=456789123},
//                new Project() { Id = 3, NGO_name="Disha", Heading="Translator", Site="Online", Duration= 3 , Time_com= 2 , Address="Hakimpra", Name=" Tushar Singh", Phone=789123456}
//            };
//        }

//        public Project Add(Project project)
//        {
//            project.Id = _projectList.Max(e => e.Id) + 1;
//            _projectList.Add(project);
//            return project;
//        }

       

//        public IEnumerable<Project> GetAllProjects()
//        {
//            return _projectList;
//        }

//        public Project GetProject(int Id)
//        {
//            return _projectList.FirstOrDefault(e => e.Id == Id);
//        }

//        public Project Update(Project projectChanges)
//        {
//            Project project = _projectList.FirstOrDefault(e => e.Id == projectChanges.Id);
//            if(project != null)
//            {
//                project.Heading = projectChanges.Heading;
//                project.NGO_name = projectChanges.NGO_name;
//                project.Site = projectChanges.Site;
//                project.Duration = projectChanges.Duration;
//                project.Time_com = projectChanges.Time_com;
//                project.Address = projectChanges.Address;
//                project.Name = projectChanges.Name;
//                project.Phone = projectChanges.Phone;
//            }
//            return project;
//        }
//    }
//}
