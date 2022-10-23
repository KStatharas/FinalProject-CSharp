using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Course
{
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
            if (id == null || _service.GetAllEntities<CourseDTO>() is null)
            {
                return NotFound();
            }

            var coursedto = _service.GetEntity<CourseDTO>(id);

            if (coursedto == null)
            {
                return NotFound();
            }
            else 
            {
                CourseDTO = coursedto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (id == null || _service.GetEntity<CourseDTO>(id) == null)
            {
                return NotFound();
            }

            if (id != null)
            {
                _service.DeleteEntity<CourseDTO>(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
