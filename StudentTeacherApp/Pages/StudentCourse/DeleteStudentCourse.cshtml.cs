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

namespace StudentTeacherApp.Pages.StudentCourse
{
    public class DeleteStudentCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public DeleteStudentCourseModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
      public StudentCourseDTO StudentCourseDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _service.GetAllEntities<StudentCourseDTO>() == null)
            {
                return NotFound();
            }

            var studentcoursedto = _service.GetEntity<StudentCourseDTO>(id);

            if (studentcoursedto == null)
            {
                return NotFound();
            }
            else 
            {
                StudentCourseDTO = studentcoursedto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _service.GetEntity<StudentCourseDTO>(id) == null)
            {
                return NotFound();
            }

            if (id != null)
            {
                _service.DeleteEntity<StudentCourseDTO>(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
