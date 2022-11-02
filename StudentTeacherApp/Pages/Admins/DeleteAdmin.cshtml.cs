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
    public class DeleteAdminModel : PageModel
    {
        private readonly IGenericService _service;
        public DeleteAdminModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public AdminDTO AdminDTO { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {

            var admindto = _service.GetEntity<AdminDTO, Admin>(id);

            if (admindto is default(AdminDTO))
            {
                return NotFound();
            }
            else
            {
                AdminDTO = admindto;
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (_service.GetEntity<AdminDTO, Admin>(id) is default(AdminDTO))
            {
                return NotFound();
            }

            _service.DeleteEntity<Admin>(id);

            return RedirectToPage("/Index");
        }
    }
}
