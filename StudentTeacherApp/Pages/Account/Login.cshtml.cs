using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentTeacherApp.DTO;
using StudentTeacherApp.Service;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace StudentTeacherApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IGenericService _service;
        public LoginModel(IGenericService service)
        {
            _service = service;
        }

        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            UserDTO UserDTO = _service.GetUsernameEntity(Credential.Username);
            
            if (UserDTO != default(UserDTO))
            {
                //if (Credential.Username == "admin" && Credential.Password == "1234321")
                //{
                //    //Claims
                //    var claims = new List<Claim>
                //    {
                //    new Claim(ClaimTypes.Name,"admin"),
                //    new Claim(ClaimTypes.Email,"admin@schoolsev.gr"),
                //    new Claim("Admin","User"),
                //    new Claim(ClaimTypes.Role,"Someone"),
                //    };
                //    var identity = new ClaimsIdentity(claims, "LoginCredAuth");
                //    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                //    await HttpContext.SignInAsync("LoginCredAuth", principal);

                //    return RedirectToPage("/Index");
                //}
            
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,Credential.Username),
                        new Claim(ClaimTypes.Role,UserDTO.Type)
                    };
                    var identity = new ClaimsIdentity(claims, "CredAuth");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("CredAuth", principal);

                    return RedirectToPage("/Index");

                //else if (UserDTO.Type == "Teacher")
                //{
                //    var claims = new List<Claim>
                //    {
                //        new Claim(ClaimTypes.Name,Credential.Username),
                //        new Claim(ClaimTypes.Role,"Teacher")
                //    };
                //    var identity = new ClaimsIdentity(claims, "TeacherAuth");
                //    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                //    await HttpContext.SignInAsync("TeacherAuth", principal);

                //    return RedirectToPage("/Index");
                //}
                //else if (UserDTO.Type =="Student")
                //{
                //    var claims = new List<Claim>
                //    {
                //        new Claim(ClaimTypes.Name,Credential.Username),
                //        new Claim(ClaimTypes.Role,"Student")
                //    };
                //    var identity = new ClaimsIdentity(claims, "StudentAuth");
                //    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                //    await HttpContext.SignInAsync("StudentAuth", principal);

                //    return RedirectToPage("/Index");
                //}
           
            }
                return Page();
            
        }
    }
    public class Credential
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
