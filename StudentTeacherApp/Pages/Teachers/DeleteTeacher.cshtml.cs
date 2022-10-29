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

namespace StudentTeacherApp.Pages.Teachers
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

            var teacherdto = _service.GetEntity<TeacherDTO,Teacher>(id);

            if (teacherdto is default(TeacherDTO))
            {
                return NotFound();
            }
            else
            {
                TeacherDTO = teacherdto;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (_service.GetEntity<TeacherDTO,Teacher>(id) is default(TeacherDTO))
            {
                return NotFound();
            }

            _service.DeleteEntity<Teacher>(id);

            return RedirectToPage("/Index");
        }
    }
}
