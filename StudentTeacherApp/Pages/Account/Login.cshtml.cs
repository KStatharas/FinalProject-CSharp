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
                string id = Convert.ToString(UserDTO.Id);

            
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,Credential.Username),
                    new Claim(ClaimTypes.Role,UserDTO.Type),
                    new Claim("UserId",id)
                };
                var identity = new ClaimsIdentity(claims, "CredAuth");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CredAuth", principal);

                return RedirectToPage("/Index");

            }
            else
            {
                return RedirectToPage("/Account/UserDoesntExist");
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
