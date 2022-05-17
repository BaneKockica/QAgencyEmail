using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailProject.Data;
using EmailProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EmailProject.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Banekockica_testContext _context;        
        private IMail Mail { get; }
        public CreateModel(IMail mail, Banekockica_testContext context)
        {
            Mail = mail;
            _context = context;
        }



        [BindProperty]
        public Email Email { get; set; }
        public SelectList ImportancesEmail;

        public async Task<IActionResult> OnGetAsync()
        {
            var importances = await Mail.GetImportanceEmail();
            ImportancesEmail = new SelectList(importances.ToList(), "ImportanceEmailId", "ImportanceName");

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!string.IsNullOrEmpty(Email.CcemailAddresses))
            {
                var ccMailAddressesReplaced = Email.CcemailAddresses.Replace(',', ';');
                foreach (var item in ccMailAddressesReplaced.Split(';'))
                {
                    if (!string.IsNullOrEmpty(item) && !IsValidEmail(item))
                    {
                        ViewData["Message"] = "CC email addresses are not valid. Please separate them by , or ;";
                        return await OnGetAsync();
                    }                       
                }
            }
  

            _context.Email.Add(Email);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create");                  
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
