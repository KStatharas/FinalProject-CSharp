﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.StudentCourses
{
    public class AddStudentCourseModel : PageModel
    {
        private readonly IGenericService _service;
        public AddStudentCourseModel(IGenericService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            ViewData["CourseId"] = new SelectList(_service.GetAllEntities<Course>(), "Id", "Id");
            ViewData["StudentId"] = new SelectList(_service.GetAllEntities<Student>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public StudentCourseDTO StudentCourseDTO { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.AddEntity(StudentCourseDTO);

            return RedirectToPage("/Index");
        }
    }
}
