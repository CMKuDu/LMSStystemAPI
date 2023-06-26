using AutoMapper;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouresController : ControllerBase
    {
        private readonly ICouresRepository _courseRepo;
        private readonly IMapper _mapper;
        public CouresController(ICouresRepository courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CoursesDTO>>GetAll() {
            var co = _courseRepo.GetAll();
            return Ok(_mapper.Map<CoursesDTO>(co));

        }
        [HttpGet("{id}")]
        public ActionResult<CoursesDTO>GetById(int id)
        {
            var co = _courseRepo.GetById(id);
            if(co != null)
            {
                return Ok(_mapper.Map<CoursesDTO>(co));

            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<CoursesDTO>Add(CoursesDTO coursesDTO)
        {
            var co = _mapper.Map<Courses>(coursesDTO);
            _courseRepo.Add(co);
            _courseRepo.SaveChanges();

            var coDTO =_mapper.Map<CoursesDTO>(co);
            return CreatedAtRoute(nameof(GetById),new {Id = coDTO.CoursesId }, coDTO);
        }
    }
}
