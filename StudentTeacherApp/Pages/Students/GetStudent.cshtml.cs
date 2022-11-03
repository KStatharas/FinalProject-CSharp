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

namespace StudentTeacherApp.Pages.Students
{
    [Authorize]
    public class GetStudentModel : PageModel
    {
        private readonly IGenericService _service;
        public GetStudentModel(IGenericService service)
        {
            _service = service;
        }

        public StudentDTO StudentDTO { get; set; }

        public IActionResult OnGet(int id)
        {
            if (_service.GetEntity<StudentDTO,Student>(id) is default(StudentDTO))
            {
                return NotFound();
            }

            StudentDTO = _service.GetEntity<StudentDTO,Student>(id);

            return Page();

        }
    }
}
