using kudapoyti.Service.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using utf_task.Service.Dtos.AdminDto;
using utf_task.Service.Dtos.CreateDtos;
using utf_task.Service.Interfaces.Main;

namespace utf_task.Web.Controllers;

[Route("account")]
public class AccountController : Controller
{
    private readonly IEmployeeService _service;
    private readonly IAdminService _adminService;
    public AccountController(IEmployeeService service, IAdminService aservice)
    {
        _service = service;
        _adminService = aservice;
    }

    [HttpGet("login")]
    public ViewResult Login()
    {
        return View("Login");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(AdminLoginDto adminAccountLogin)
    {
        if (ModelState.IsValid)
        {
            try
            {
                string token = await _adminService.VerifyAdmin(adminAccountLogin.Login, adminAccountLogin.Password);
                HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });
                return RedirectToAction("Index", "Home");
            }
            catch (ModelErrorException modelError)
            {
                ModelState.AddModelError(modelError.Property, modelError.Message);
                return Login();
            }
            catch
            {
                return Login();
            }
        }
        else return Login();

    }


    [HttpGet("register")]
    public ViewResult Register()
    {
        return View("Register");
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(EmployeeCreateDto createDto)
    {
        if (ModelState.IsValid)
        {
            bool result = await _service.CreateAsync(createDto);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Register();
            }
        }
        else return Register();
    }

}
