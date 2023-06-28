using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;

namespace LMS_System.Repository.IRepository
{
    public interface ICouresRepository
    {
        public Task<List<CoursesDTO>> GetAllCourses();
        public Task<CoursesDTO> GetCourses(int id);
        public Task<int> PostCourses(CoursesDTO model);
        public Task Delele(int id);
        public Task Update(int id, CoursesDTO model);
    }
}
