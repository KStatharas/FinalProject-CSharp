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

namespace StudentTeacherApp.Pages.Teachers
{
    [Authorize]
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
            if (_service.GetEntity<TeacherDTO,Teacher>(id) is default(TeacherDTO))
            {
                return NotFound();
            }

            TeacherDTO = _service.GetEntity<TeacherDTO,Teacher>(id);

            return Page();
        }
    }
}
