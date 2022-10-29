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
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.StudentCourses
{
    public class UpdateStudentCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public UpdateStudentCourseModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public StudentCourseDTO StudentCourseDTO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_service.GetEntity<StudentCourseDTO,StudentCourse>(id) is default(StudentCourseDTO))
            {
                return NotFound();
            }

            StudentCourseDTO = _service.GetEntity<StudentCourseDTO, StudentCourse>(id);
           
           //ViewData["CourseId"] = new SelectList(_context.CourseDTO, "Id", "Id");
           //ViewData["StudentId"] = new SelectList(_context.StudentDTO, "Id", "Id");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.UpdateEntity<StudentCourseDTO>(StudentCourseDTO);

            //_context.Attach(StudentCourseDTO).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentCourseDTOExists(StudentCourseDTO.StudentId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("/Index");
        }

        //private bool StudentCourseDTOExists(int id)
        //{
        //  return _context.StudentCourseDTO.Any(e => e.StudentId == id);
        //}
    }
}
