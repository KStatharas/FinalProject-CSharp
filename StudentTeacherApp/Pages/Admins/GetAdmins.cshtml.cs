using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.DTO;
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

        public IList<AdminDTO> AdminDTO { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<AdminDTO,Admin>() != null)
            {
                AdminDTO = _service.GetAllEntities<AdminDTO,Admin>(); ;
            }
        }
    }
}
