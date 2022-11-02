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

namespace StudentTeacherApp.Pages.Users
{
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
            if (_service.GetUserEntities<UserDTO,User>() != null)
            {
                User = _service.GetUserEntities<UserDTO,User>();
            }
        }
    }
}
