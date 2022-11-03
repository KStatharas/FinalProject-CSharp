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
    public class GetUsersModel : PageModel
    {
        private readonly IGenericService _service;
        public GetUsersModel(IGenericService service)
        {
            _service = service;
        }

        public IList<UserDTO> User { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<UserDTO,User>() != null)
            {
                User = _service.GetAllEntities<UserDTO,User>();
            }
        }
    }
}
