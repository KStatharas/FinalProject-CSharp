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

namespace StudentTeacherApp.Pages.Students
{
    public class GetStudentsModel : PageModel
    {
        private readonly IGenericService _service;
        public GetStudentsModel(IGenericService service)
        {
            _service = service;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetAllEntities<Student>() != null)
            {
                Student = _service.GetAllEntities<Student>(); ;
            }
        }
    }
}
