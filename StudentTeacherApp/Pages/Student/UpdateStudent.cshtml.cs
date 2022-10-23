using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Student
{
    public class UpdateStudentModel : PageModel
    {
        private readonly IGenericService _service;
        public UpdateStudentModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public StudentDTO StudentDTO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _service.GetEntity<StudentDTO>(id) == null)
            {
                return NotFound();
            }

            StudentDTO = _service.GetEntity<StudentDTO>(id);
          
            return Page();
        }

      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.UpdateEntity<StudentDTO>(StudentDTO);

            //_context.Attach(StudentDTO).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentDTOExists(StudentDTO.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        //private bool StudentDTOExists(int id)
        //{
        //  return _context.StudentDTO.Any(e => e.Id == id);
        //}
    }
}
