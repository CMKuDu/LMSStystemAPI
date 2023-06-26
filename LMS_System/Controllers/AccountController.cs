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
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AccountDTO>> GetAll()
        {
            var acc = _accountRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<AccountDTO>>(acc)); 
        }
        [HttpGet("{id}",Name = "GetById")]
        public ActionResult<AccountDTO> GetById(int id)
        {
            var acc = _accountRepository.GetById(id);
            if(acc != null) 
            {
                return Ok (_mapper.Map<AccountDTO>(acc));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<AccountDTO>Add(AccountDTO accountDTO)
        {
            var acc = _mapper.Map<Account>(accountDTO);
            _accountRepository.Add(acc);
            _accountRepository.SaveChanges();

            var accDTO = _mapper.Map<AccountDTO>(acc);

            return CreatedAtRoute(nameof(GetById),new {Id = accDTO.AccountId}, accDTO);
        }
    }
}
