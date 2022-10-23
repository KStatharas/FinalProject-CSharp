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
            if (id == null || _service.GetAllEntities<StudentDTO>() is null)
            {
                return NotFound();
            }

            var studentdto = _service.GetEntity<StudentDTO>(id);

            if (studentdto == null)
            {
                return NotFound();
            }
            else
            {
                StudentDTO = studentdto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (id == null || _service.GetEntity<StudentDTO>(id) == null)
            {
                return NotFound();
            }

            if (id != null)
            {
                _service.DeleteEntity<StudentDTO>(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
