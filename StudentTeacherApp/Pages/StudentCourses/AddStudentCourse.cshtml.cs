using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.StudentCourses
{
    [Authorize]
    public class AddStudentCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public AddStudentCourseModel(IGenericService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            ViewData["CourseId"] = new SelectList(_service.GetAllEntities<CourseDTO,Course>(), "Id", "Id");
            ViewData["StudentId"] = new SelectList(_service.GetAllEntities<StudentDTO,Student>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public StudentCourseDTO StudentCourseDTO { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_service.AttendsCourse(StudentCourseDTO.StudentId, StudentCourseDTO.CourseId)) return RedirectToPage("/Account/CourseExists");

            _service.AddEntity(StudentCourseDTO);

            return RedirectToPage("/Index");
        }
    }
}
