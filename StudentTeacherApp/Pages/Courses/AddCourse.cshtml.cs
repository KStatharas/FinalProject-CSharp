using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Courses
{
    [Authorize(Roles = "Admin,Teacher")]
    public class AddCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public AddCourseModel(IGenericService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            ViewData["TeacherId"] = new SelectList(_service.GetAllEntities<TeacherDTO,Teacher>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CourseDTO CourseDTO { get; set; }
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.AddEntity(CourseDTO);

            return RedirectToPage("/Index");
        }
    }
}
