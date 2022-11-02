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

namespace StudentTeacherApp.Pages.Admins
{
    public class GetAdminModel : PageModel
    {
        private readonly IGenericService _service;
        public GetAdminModel(IGenericService service)
        {
            _service = service;
        }

        public AdminDTO AdminDTO { get; set; }

        public IActionResult OnGet(int id)
        {
            if (_service.GetEntity<AdminDTO, Admin>(id) is default(AdminDTO))
            {
                return NotFound();
            }

            AdminDTO = _service.GetEntity<AdminDTO, Admin>(id);

            return Page();

        }
    }
}
