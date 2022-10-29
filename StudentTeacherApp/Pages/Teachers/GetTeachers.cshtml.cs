using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Teachers
{
    public class GetTeachersModel : PageModel
    {
        private readonly IGenericService _service;
        public GetTeachersModel(IGenericService service)
        {
            _service = service;
        }

        public IList<Teacher> Teacher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<Teacher>() != null)
            {
                Teacher = _service.GetAllEntities<Teacher>();
            }
        }
    }
}
