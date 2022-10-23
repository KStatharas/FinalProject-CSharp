using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Teacher
{
    public class DeleteTeacherModel : PageModel
    {
        private readonly IGenericService _service;
        public DeleteTeacherModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
      public TeacherDTO TeacherDTO { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id == null || _service.GetAllEntities<TeacherDTO>() is null)
            {
                return NotFound();
            }

            var teacherdto = _service.GetEntity<TeacherDTO>(id);

            if (teacherdto == null)
            {
                return NotFound();
            }
            else
            {
                TeacherDTO = teacherdto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (id == null || _service.GetEntity<TeacherDTO>(id) == null)
            {
                return NotFound();
            }

            if (id != null)
            {
                _service.DeleteEntity<TeacherDTO>(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
