using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using utf_task.Service.Common.Utils;
using utf_task.Service.Interfaces.Common;
using utf_task.Service.Interfaces.Main;
using utf_task.Web.Models;

namespace utf_task.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly int _paginatorService=5;
        public HomeController(IEmployeeService service)
        {
            this._service = service;
        }

        public async Task<ViewResult>  Index(int page=1)
        {
            var get=await _service.GetAllAsync(new PaginationParams(page, _paginatorService));
            return View("Index",get);
            //return RedirectToAction("Login","Account");
        }

        public IActionResult Privacy()
        {
            return RedirectToAction("Login","Account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}