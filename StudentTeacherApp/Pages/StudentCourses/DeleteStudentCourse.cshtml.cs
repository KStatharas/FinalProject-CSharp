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

        public async Task<IActionResult> OnGet(int studentid, int courseid)
        {

            StudentCourseDTO = _service.GetCourse(studentid, courseid);

            if (StudentCourseDTO is null)
            {
                return NotFound();
            }
           
            return Page();
        }

        public IActionResult OnPost(int studentid, int courseid)
        {
            if (_service.GetCourse(studentid, courseid) is null)
            {
                return NotFound();
            }

            _service.DeleteCourse(studentid, courseid);

            return RedirectToPage("/Index");
        }
    }
}
