using AutoMapper;
using LMS_System.LMSSystym.Model.Data;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Repository
{
    public class CourseRepository : ICouresRepository
    {
        private readonly DataContext _dataContext;
        private readonly Mapper _mapper;
        public CourseRepository(DataContext context, Mapper map)
        {
            _dataContext = context;
            _mapper = map;
        }
        public async Task Delele(int id)
        {
            var dl = await _dataContext.Courses.SingleOrDefaultAsync(x => x.CoursesId == id);
            if(dl != null)
            {
                _dataContext.Courses.Remove(dl);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<List<CoursesDTO>> GetAllCourses()
        {
            var dl = await _dataContext.Courses.ToListAsync();
            return _mapper.Map<List<CoursesDTO>>(dl);
        }

        public async Task<CoursesDTO> GetCourses(int id)
        {
                var dl = await _dataContext.Courses.FindAsync(id);
                return _mapper.Map<CoursesDTO>(dl);
        }

        public async Task<int> PostCourses(CoursesDTO model)
        {
            var dl = _mapper.Map<Courses>(model);
             _dataContext.Courses.Add(dl);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task Update(int id, CoursesDTO model)
        {
            
            if(id == model.CoursesId)
            {
                var dl = _mapper.Map<Courses>(model);
                _dataContext.Courses.Update(dl);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
