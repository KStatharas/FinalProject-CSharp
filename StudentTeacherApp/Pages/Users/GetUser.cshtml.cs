﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Data;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;
using StudentTeacherApp.Data.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace StudentTeacherApp.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class GetUserModel : PageModel
    {
        private readonly IGenericService _service;
        public GetUserModel(IGenericService service)
        {
            _service = service;
        }

        public UserDTO UserDTO { get; set; }

        public IActionResult OnGet(int id)
        {
            if (_service.GetEntity<UserDTO, User>(id) is default(UserDTO))
            {
                return NotFound();
            }

            UserDTO = _service.GetEntity<UserDTO, User>(id);

            return Page();

        }
    }
}
