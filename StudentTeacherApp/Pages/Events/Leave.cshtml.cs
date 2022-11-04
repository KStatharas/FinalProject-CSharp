using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Events
{
    public class LeaveModel : PageModel
    {
        private readonly IGenericService _service;
        public LeaveModel(IGenericService service)
        {
            _service = service;
        }

        public UserDTO UserDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            UserDTO = _service.GetUsernameEntity(User.Identity.Name);
            _service.DeleteCourse(UserDTO.Id, id);

            return RedirectToPage("/Courses/GetCourses");

        }
    }
}
