using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Student
{
    public class GetStudentModel : PageModel
    {
        private readonly IGenericService _service;
        public GetStudentModel(IGenericService service)
        {
            _service = service;
        }

        public StudentDTO StudentDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _service.GetEntity<StudentDTO>(id) == null)
            {
                return NotFound();
            }

            StudentDTO = _service.GetEntity<StudentDTO>(id);

            return Page();

        }
    }
}
