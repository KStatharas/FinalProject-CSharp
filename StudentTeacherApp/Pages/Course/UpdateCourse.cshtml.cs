﻿using System;
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

namespace StudentTeacherApp.Pages.Course
{
    public class UpdateCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public UpdateCourseModel(IGenericService service)
        {
            _service = service;
        }


        [BindProperty]
        public CourseDTO CourseDTO { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _service.GetEntity<CourseDTO>(id) == null)
            {
                return NotFound();
            }

            CourseDTO = _service.GetEntity<CourseDTO>(id);
           
           //ViewData["TeacherId"] = new SelectList(_context.TeacherDTO, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.UpdateEntity<CourseDTO>(CourseDTO);

            //_context.Attach(CourseDTO).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CourseDTOExists(CourseDTO.Id))
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

        //private bool CourseDTOExists(int id)
        //{
        //  return _context.CourseDTO.Any(e => e.Id == id);
        //}
    }
}