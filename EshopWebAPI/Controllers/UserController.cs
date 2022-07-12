using EshopWeb.CoreLayer.DTOs.Users;
using EshopWeb.CoreLayer.Utilities;
using EshopWebAPI.Services.User;
using EshopWebAPI.ViewModel.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _userService.GetById(id);
            return (user == null) ? NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateVM CreateVM)
        {
            var user = new CreateDto()
            {
                Name = CreateVM.Name,
                Family = CreateVM.Family,
                UserName = CreateVM.UserName,
                Password = CreateVM.Password
            };

            if (!ModelState.IsValid) return BadRequest(CreateVM);

            if (CreateVM == null) return BadRequest(CreateVM);

            

           var model = _userService.CreateUser(user);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] EditDto editDto)
        {
            if (id != editDto.ID) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);


            var model = _userService.EditUser(editDto);

            if(model.Status != OperationResultStatus.Success)
                return BadRequest(ModelState);

            return Ok();
        }

    }
}
