using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Teachers
{
    [Authorize(Roles = "Admin")]
    public class UpdateTeacherModel : PageModel
    {
        private readonly IGenericService _service;
        public UpdateTeacherModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public TeacherDTO TeacherDTO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_service.GetEntity<TeacherDTO,Teacher>(id) is default(TeacherDTO))
            {
                return NotFound();
            }

            TeacherDTO = _service.GetEntity<TeacherDTO,Teacher>(id);
      
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.UpdateEntity<TeacherDTO>(TeacherDTO);
            //_context.Attach(TeacherDTO).State = EntityState.Modified;

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!TeacherDTOExists(TeacherDTO.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            return RedirectToPage("/Index");
            //}

            //private bool TeacherDTOExists(int id)
            //{
            //  return _context.TeacherDTO.Any(e => e.Id == id);
            //}

        }
    }
}
