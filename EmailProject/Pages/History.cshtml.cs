using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailProject.Data;
using EmailProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailProject.Pages
{
    public class HistoryModel : PageModel
    {
        public List<Email> Emails;
        public List<ImportanceEmail> ImportancesEmail;
        private IMail Mail { get; }
        public HistoryModel(IMail mail)
        {
            Mail = mail;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var emails =  await Mail.GetEmails();
            var importances = await Mail.GetImportanceEmail();
            ImportancesEmail = importances.ToList();
            Emails = emails.ToList();
            foreach (var item in Emails)
            {
                item.ImportanceNavigation = ImportancesEmail.Where(i => i.ImportanceEmailId == item.Importance).FirstOrDefault();
            }
            return Page(); 
        }
    }
}
