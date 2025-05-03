using EducationCenter.DataAccess.Repository.IRepository;
using EducationCenter.Models.DTOs.Request;
using EducationCenter.Models.DTOs.Response;
using EducationCenter.Models.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EducationCenter.Areas.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStudentRepository _studentRepository;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IStudentRepository studentRepository)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._studentRepository = studentRepository;
        }




[HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequest)
    {
        var applicationUser = registerRequest.Adapt<ApplicationUser>();

        applicationUser.NotificationRecipient = new NotificationRecipient
        {
            DeliveryByGmail = false,
            IsDelivered = false
        };

        var result = await _userManager.CreateAsync(applicationUser, registerRequest.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await _signInManager.SignInAsync(applicationUser, false);

        if (!_roleManager.Roles.Any())
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Assistant"));
            await _roleManager.CreateAsync(new IdentityRole("Teacher"));
            await _roleManager.CreateAsync(new IdentityRole("Student"));
        }

        await _userManager.AddToRoleAsync(applicationUser, "Student");

        var studentRequest = registerRequest.Adapt<StudentRequest>();
        await _studentRepository.CreateStudentAsync(studentRequest, applicationUser.Id);

        var student = await _studentRepository.GetStudentWithUserAsync(applicationUser.Id);

        var response = new StudentRegisterResponseDTO
        {
            Message = "تم التسجيل بنجاح",
            StudentFullName = $"{student.ApplicationUser.FirstName} {student.ApplicationUser.LastName}",
            StudentId = student.Id,
            UserId = student.ApplicationUser.Id,
            Role = "Student",
            //AcademicYearID = student.AcademicYearID,
        };

        return Created(string.Empty, response);
    }







    [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            var appUser = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (appUser != null)
            {
                var result = await _userManager.CheckPasswordAsync(appUser, loginRequest.Password);

                if (result)
                {
                    // Login
                    await _signInManager.SignInAsync(appUser, loginRequest.RememberMe);

                    return NoContent();
                }
                else
                {
                    ModelStateDictionary keyValuePairs = new();
                    keyValuePairs.AddModelError("Error", "Invalid Data");
                    return BadRequest(keyValuePairs);
                }
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }
    }
}
