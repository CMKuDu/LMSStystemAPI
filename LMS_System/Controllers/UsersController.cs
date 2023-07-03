using AutoMapper;
using LMS_System.Helper;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;
using LMS_System.Prototypes;
using LMS_System.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        private IMapper _mapper;
        private IConfiguration _configuration;
        private ILogger<UsersController> _logger;
        public UsersController(IUserRepository userRepo, IRoleRepository roleRepo, IMapper mapper, IConfiguration configuration, ILogger<UsersController> logger)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUSers(int page = 1, int pageSize = 10, string? key = null)
        {
            try
            {
                var allUser = await _userRepo.GetAllUser();
                if (!string.IsNullOrEmpty(key))
                {
                    allUser = allUser
                        .Where(u => u.Username.Contains(key) || u.Email.Contains(key))
                        .ToList();
                }
                var paginatedUsers = Pagination.Paginate(allUser, page, pageSize);
                var totalUser = allUser.Count();
                var totalPage = Pagination.CalculateTotalPages(totalUser, pageSize);

                var paginationInfo = new
                {
                    TotalUser = totalUser,
                    Page = page,
                    pageSize = pageSize,
                    ToltalPage = totalPage
                };
                return Ok(new { User = paginatedUsers, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("role/{rolesId}"), Authorize(Roles = "Admin ")]
        public async Task<IActionResult> GetAllUserByRoles(int roleId,int page =1, int pageSize =10,string ? key = null)
        {
            try
            {
                var allUs = await _userRepo.GetAllUserByRoleId(roleId);
                if(!string.IsNullOrEmpty(key))
                {
                    allUs = allUs.Where(x => x.Name.Contains(key) || x.Email.Contains(key)).ToList();
                }
                var paginatedUsers = Pagination.Paginate(allUs, page, pageSize);
                var totalUser = allUs.Count();
                var totalPage = Pagination.CalculateTotalPages(totalUser, pageSize);

                var paginationInfo = new
                {
                    TotalUser = totalUser,
                    Page = page,
                    pageSize = pageSize,
                    ToltalPage = totalPage
                };
                return Ok(new { User = paginatedUsers, Pagination = paginationInfo });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var allUsId = await _userRepo.GetUserByIt(id);
            return allUsId == null ? NotFound() : Ok(allUsId);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(string email, string userName,string password)
        {
            _logger.LogInformation("Create new a User");
            try
            {
                var nus = new UserDTO
                {
                    Email = email,
                    Username = userName,
                    Password = password,
                    VerificationToken = jwtHandler.CreateRandomToken()
                };
                if(await _userRepo.Post(nus) != -1)
                {
                    return Ok(new ApiResponse
                    {
                        Success = true,
                        Message = "Register success",
                        Data = CreatedAtAction(nameof(GetUserById),new {id = nus.UserID},nus)
                    });
                }
                else
                {
                    return BadRequest(new ApiResponse
                    {
                        Success = false,
                        Message = "Register fail: The user already exits",
                        Data = null,
                    });
                }
            }
            catch(System.Exception e)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Register fail: " + e.GetBaseException(),
                    Data = null,
                });
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username,string password)
        {
            GenerateToken tokenGenera = new GenerateToken(_configuration, _roleRepo);

            if (!await _userRepo.CheckUserName(username))
            {
                return NotFound("UserName or Password not found");
            }
            try
            {
                var us = await _userRepo.Login(username, password);

                var passwordHash = HashMD5.GetMD5Hash(password);

                if (passwordHash != us.Password)
                {
                    return BadRequest("UserName or Password not found");
                }
                if (us.VerifyAt == null)
                {
                    return BadRequest("Not Verify");
                }
                if (us != null)
                {
                    string token = await tokenGenera.CreateToken(us);

                    var resfreshToken = GenerateRefreshToken.CreateRefeshToken();
                    var cookieOPtions = new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = resfreshToken.Expires,
                    };
                    Response.Cookies.Append("refreshToken", resfreshToken.Token, cookieOPtions);

                    await _userRepo.SetRefreshToken(us.UserID, resfreshToken);

                    return Ok(token);
                }
                return Ok(us);
            }
            catch
            {
                return BadRequest();
            }
        }
        
    }
}
