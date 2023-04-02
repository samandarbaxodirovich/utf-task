using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using utf_task.Service.Dtos.UpdateDtos;
using utf_task.Service.Interfaces.Main;

namespace utf_task.Web.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IEmployeeService _service;
        public AdminController(IEmployeeService service)
        {
            this._service = service;
        }


        [HttpGet("delete")]
        public async Task<ViewResult> Delete(long Id)
        {
            var admin = await _service.GetById(Id);
            if (admin != null)
            {
                return View(admin);
            }
            return View();
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(long Id)
        {
            var admin = await _service.DeleteAsync(Id);
            if (admin) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpGet("update")]
        public async Task<ViewResult> Update(long Id)
        {
            var employee = await _service.GetById(Id);
           
            var dto = new EmployeeUpdateDto()
            {
                Id = Id,
                FullName = employee.FullName,
                PhoneNumber= employee.PhoneNumber,
            };
            return View(dto);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(long Id, EmployeeUpdateDto updateProductDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(Id, updateProductDto);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                return await Update(Id);
            }
            return View();
        }
    }
}
