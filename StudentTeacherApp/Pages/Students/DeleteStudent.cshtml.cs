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

namespace StudentTeacherApp.Pages.Students
{
    public class DeleteStudentModel : PageModel
    {
        private readonly IGenericService _service;
        public DeleteStudentModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
      public StudentDTO StudentDTO { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {

            var studentdto = _service.GetEntity<StudentDTO,Student>(id);

            if (studentdto is default(StudentDTO))
            {
                return NotFound();
            }
            else
            {
                StudentDTO = studentdto;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (_service.GetEntity<StudentDTO,Student>(id) is default(StudentDTO))
            {
                return NotFound();
            }

            _service.DeleteEntity<Student>(id);

            return RedirectToPage("/Index");
        }
    }
}
