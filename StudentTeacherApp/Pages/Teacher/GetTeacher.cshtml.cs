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
    public class GetTeacherModel : PageModel
    {
        private readonly IGenericService _service;
        public GetTeacherModel(IGenericService service)
        {
            _service = service;
        }

        public TeacherDTO TeacherDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _service.GetEntity<TeacherDTO>(id) == null)
            {
                return NotFound();
            }

            TeacherDTO = _service.GetEntity<TeacherDTO>(id);
         
            return Page();
        }
    }
}
