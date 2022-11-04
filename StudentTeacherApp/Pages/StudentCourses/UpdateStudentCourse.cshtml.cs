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
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.StudentCourses
{
    [Authorize(Roles = "Admin,Teacher")]
    public class UpdateStudentCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public UpdateStudentCourseModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public StudentCourseDTO StudentCourseDTO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int studentid, int courseid)
        {
            ViewData["CourseId"] = new SelectList(_service.GetAllEntities<CourseDTO, Course>(), "Id", "Id");
            ViewData["StudentId"] = new SelectList(_service.GetAllEntities<StudentDTO, Student>(), "Id", "Id");

            StudentCourseDTO = _service.GetCourse(studentid, courseid);

            if (StudentCourseDTO is null)
            {
                return NotFound();
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_service.GetCourse(StudentCourseDTO.StudentId, StudentCourseDTO.CourseId) != null)
            {
                return RedirectToPage("/Account/CourseExists");
            }

            _service.UpdateEntity(StudentCourseDTO);

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
