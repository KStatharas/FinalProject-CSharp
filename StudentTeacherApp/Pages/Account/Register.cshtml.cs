using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentTeacherApp.Data.Models;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Models;
using StudentTeacherApp.Service;

namespace StudentTeacherApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IGenericService _service;
        public RegisterModel(IGenericService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            ViewData["Types"] = new SelectList(types);

            return Page();
        }

        public static List<string> types = new List<string> { "Admin", "Student", "Teacher" };

        [BindProperty]
        public StudentDTO StudentDTO { get; set; }

        [BindProperty]
        public TeacherDTO TeacherDTO { get; set; }

        [BindProperty]
        public AdminDTO AdminDTO { get; set; }

        [BindProperty]
        public UserDTO UserDTO { get; set; }

        [BindProperty]
        public string Firstname { get; set; }

        [BindProperty]
        public string Lastname { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(UserDTO.Username == _service.GetUsernameEntity(UserDTO.Username).Username)
            {
                return RedirectToPage("/Account/AccountExists");
            }

            string? type = UserDTO.Type;

            switch (type)
            {
                case "Admin":
                    AdminDTO = new AdminDTO()
                    {
                        Id = _service.AddEntity(UserDTO),
                        Firstname = Firstname,
                        Lastname = Lastname
                    };
                    _service.AddEntity(AdminDTO);

                    break;
                case "Student":
                    StudentDTO = new StudentDTO()
                    {
                        Id = _service.AddEntity(UserDTO),
                        Firstname = Firstname,
                        Lastname = Lastname
                    };
                    _service.AddEntity(StudentDTO);

                    break;
                case "Teacher":
                    TeacherDTO = new TeacherDTO()
                    {
                        Id = _service.AddEntity(UserDTO),
                        Firstname = Firstname,
                        Lastname = Lastname
                    };
                    _service.AddEntity(TeacherDTO);

                    break;
                default:
                    _service.AddEntity(UserDTO);
                    break;

            }

            return RedirectToPage("/Index");
        }
    }
}
