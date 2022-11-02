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

namespace StudentTeacherApp.Pages.Users
{
    public class UpdateUserModel : PageModel
    {
        private readonly IGenericService _service;
        public UpdateUserModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public string Firstname { get; set; }

        [BindProperty]
        public string Lastname { get; set; }

        [BindProperty]
        public UserDTO UserDTO { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int id)
        {

            if (_service.GetEntity<UserDTO, User>(id) is default(UserDTO))
            {
                return NotFound();
            }

            UserDTO = _service.GetEntity<UserDTO, User>(id);
            Firstname = UserDTO.FirstLast.Firstname;
            Lastname = UserDTO.FirstLast.Lastname;

            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.UpdateUserEntity(UserDTO, Firstname, Lastname);

            //_context.Attach(StudentDTO).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentDTOExists(StudentDTO.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("/Index");
        }

        //private bool StudentDTOExists(int id)
        //{
        //  return _context.StudentDTO.Any(e => e.Id == id);
        //}
    }
}
