using Microsoft.AspNetCore.Mvc;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Controllers
{
    public class HomeController : Controller
    {

        private readonly IGenericService _service;
        public HomeController(IGenericService service)
        {
            _service = service;
        }

        public UserDTO UserDTO { get; set; }


        public IActionResult _SessionPartial()
        {
            UserDTO = _service.GetUsernameEntity(User.Identity.Name);
            return View();
        }

    }
}
