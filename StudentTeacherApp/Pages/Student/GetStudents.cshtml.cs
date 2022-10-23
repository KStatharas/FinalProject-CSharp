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

namespace StudentTeacherApp.Pages.Student
{
    public class GetStudentsModel : PageModel
    {
        private readonly IGenericService _service;
        public GetStudentsModel(IGenericService service)
        {
            _service = service;
        }

        public IList<StudentDTO> StudentDTO { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<StudentDTO>() != null)
            {
                StudentDTO = _service.GetAllEntities<StudentDTO>(); ;
            }
        }
    }
}
