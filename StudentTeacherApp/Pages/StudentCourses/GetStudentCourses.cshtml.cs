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
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.StudentCourses
{
    [Authorize(Roles = "Admin,Teacher")]
    public class GetStudentCoursesModel : PageModel
    {
        private readonly IGenericService _service;
        public GetStudentCoursesModel(IGenericService service)
        {
            _service = service;
        }

        public IList<StudentCourseDTO> StudentCourseDTO { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<StudentCourseDTO,StudentCourse>() != null)
            {
                StudentCourseDTO = _service.GetAllEntities<StudentCourseDTO,StudentCourse>();
            }
        }
    }
}
