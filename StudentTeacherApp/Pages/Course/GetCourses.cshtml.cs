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
    public class GetCoursesModel : PageModel
    {
        private readonly IGenericService _service;
        public GetCoursesModel(IGenericService service)
        {
            _service = service;
        }

        public IList<CourseDTO> CourseDTO { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<CourseDTO>() != null)
            {
                CourseDTO = _service.GetAllEntities<CourseDTO>();
            }
        }
    }
}
