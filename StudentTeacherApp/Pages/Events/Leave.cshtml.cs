using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentTeacherApp.Data.Models;
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

        //public async Task<IActionResult> OnGetAsync(int id)
        //{
        //    string username = User.Identity.Name;

        //    UserDTO UserDTO = _service.GetUsernameEntity(username);

        //    StudentCourseDTO studentCourseDTO = new StudentCourseDTO()
        //    {
        //        StudentId = UserDTO.Id,
        //        CourseId = id
        //    };

        //    _service.AddEntity(studentCourseDTO);

        //    return RedirectToPage("/Index");
        //}

    }
}
