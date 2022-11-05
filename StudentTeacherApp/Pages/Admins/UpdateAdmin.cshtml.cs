using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Data;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;
using StudentTeacherApp.Data.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace StudentTeacherApp.Pages.Admins
{
    [Authorize(Roles = "Admin")]
    public class UpdateAdminModel : PageModel
    {
        private readonly IGenericService _service;
        public UpdateAdminModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public AdminDTO AdminDTO { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int id)
        {

            if (_service.GetEntity<AdminDTO, Admin>(id) is default(AdminDTO))
            {
                return NotFound();
            }

            AdminDTO = (AdminDTO)(object)_service.GetEntity<AdminDTO, Admin>(id);

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.UpdateEntity<AdminDTO>(AdminDTO);



            return RedirectToPage("/Index");
        }

    }
}
