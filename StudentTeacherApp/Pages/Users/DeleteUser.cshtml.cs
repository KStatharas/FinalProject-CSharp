using System;
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
    public class DeleteUserModel : PageModel
    {
        private readonly IGenericService _service;
        public DeleteUserModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public UserDTO UserDTO { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {

            var userdto = _service.GetEntity<UserDTO, User>(id);

            if (userdto is default(UserDTO))
            {
                return NotFound();
            }
            else
            {
                UserDTO = userdto;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (_service.GetEntity<UserDTO, User>(id) is default(UserDTO))
            {
                return NotFound();
            }

            _service.DeleteEntity<User>(id);

            return RedirectToPage("/Index");
        }
    }

}
