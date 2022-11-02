using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Admins
{
    public class GetAdminsModel : PageModel
    {
        private readonly IGenericService _service;
        public GetAdminsModel(IGenericService service)
        {
            _service = service;
        }

        public IList<Admin> Admin { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<Admin>() != null)
            {
                Admin = _service.GetAllEntities<Admin>(); ;
            }
        }
    }
}
