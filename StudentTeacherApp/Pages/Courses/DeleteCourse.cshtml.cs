using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Courses
{
    [Authorize(Roles = "Admin,Teacher")]
    public class DeleteCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public DeleteCourseModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public CourseDTO CourseDTO { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {

            var coursedto = _service.GetEntity<CourseDTO, Course>(id);

            if (coursedto is default(CourseDTO))
            {
                return NotFound();
            }
            else
            {
                CourseDTO = coursedto;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (_service.GetEntity<CourseDTO, Course>(id) is default(CourseDTO))
            {
                return NotFound();
            }

            _service.DeleteEntity<Course>(id);

            return RedirectToPage("/Index");
        }
    }
}
