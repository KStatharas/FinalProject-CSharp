using System;
using System.Collections.Generic;
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
    public class GetStudentCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public GetStudentCourseModel(IGenericService service)
        {
            _service = service;
        }

        public StudentCourseDTO StudentCourseDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int studentid,int courseid)
        {
            StudentCourseDTO = _service.GetCourse(studentid, courseid);

            if (StudentCourseDTO is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
