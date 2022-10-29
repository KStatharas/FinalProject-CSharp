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

namespace StudentTeacherApp.Pages.Courses
{
    public class GetCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public GetCourseModel(IGenericService service)
        {
            _service = service;
        }


        public CourseDTO CourseDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_service.GetEntity<CourseDTO,Course>(id) is default(CourseDTO))
            {
                return NotFound();
            }

            CourseDTO = _service.GetEntity<CourseDTO,Course>(id);

            return Page();
        }
    }
}
