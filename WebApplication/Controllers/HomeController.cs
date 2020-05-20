using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Contract;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISystemBaseUserService _userService;

        public HomeController(ILogger<HomeController> logger,
            ISystemBaseUserService userService
            )
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Save(SystemBaseUserDto userDto)
        {
            var isSuccess = _userService.Add(userDto);
            return new JsonResult(new { code = isSuccess ? 1 : 0, message = isSuccess ? "新增成功" : "新增失败" });
        }
    }
}
