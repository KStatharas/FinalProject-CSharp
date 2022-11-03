using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentTeacherApp.Data;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Teachers
{
    [Authorize]
    public class GetTeachersModel : PageModel
    {
        private readonly IGenericService _service;
        public GetTeachersModel(IGenericService service)
        {
            _service = service;
        }

        public IList<TeacherDTO> TeacherDTO { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<TeacherDTO,Teacher>() != null)
            {
                TeacherDTO = _service.GetAllEntities<TeacherDTO,Teacher>();
            }
        }
    }
}
