﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Courses
{
    [Authorize]
    public class GetCoursesModel : PageModel
    {
        private readonly IGenericService _service;
        public GetCoursesModel(IGenericService service)
        {
            _service = service;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<Course>() != null)
            {
                Course = _service.GetAllEntities<Course>();
            }
        }

        //public void OnMyClick(int id)
        //{
        //    string username = User.Identity.Name;

        //    UserDTO UserDTO = _service.GetUsernameEntity(username);

        //    StudentCourse studentCourse = new StudentCourse()
        //    {
        //        StudentId = UserDTO.Id,
        //        CourseId = id
        //    };

    }
}
