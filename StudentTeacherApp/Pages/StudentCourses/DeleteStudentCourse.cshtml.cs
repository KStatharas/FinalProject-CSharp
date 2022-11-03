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

namespace StudentTeacherApp.Pages.StudentCourses
{
    [Authorize(Roles = "Admin,Teacher")]
    public class DeleteStudentCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public DeleteStudentCourseModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public StudentCourseDTO StudentCourseDTO { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {

            var studentcoursedto = _service.GetEntity<StudentCourseDTO,StudentCourse>(id);

            if (studentcoursedto is default(StudentCourseDTO))
            {
                return NotFound();
            }
            else
            {
                StudentCourseDTO = studentcoursedto;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (_service.GetEntity<StudentCourseDTO, StudentCourse>(id) is default(StudentCourseDTO))
            {
                return NotFound();
            }

            _service.DeleteEntity<StudentCourse>(id);

            return RedirectToPage("/Index");
        }
    }
}
