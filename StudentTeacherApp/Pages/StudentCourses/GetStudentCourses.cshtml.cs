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

namespace StudentTeacherApp.Pages.StudentCourses
{
    public class GetStudentCoursesModel : PageModel
    {
        private readonly IGenericService _service;
        public GetStudentCoursesModel(IGenericService service)
        {
            _service = service;
        }

        public IList<StudentCourse> StudentCourse { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<StudentCourse>() != null)
            {
                StudentCourse = _service.GetAllEntities<StudentCourse>();
            }
        }
    }
}
