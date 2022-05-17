using EmailProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailProject.Data
{
    public class MailSql : IMail
    {
        private Banekockica_testContext Banekockica_TestContext { get; }
        public SelectList ImportanceSL { get; set; }

        public MailSql(Banekockica_testContext banekockica_TestContext)
        {
            Banekockica_TestContext = banekockica_TestContext;
        }

        public async Task<IEnumerable<Email>> GetEmails()
        {
            return await Banekockica_TestContext.Email.ToListAsync();   
        }

        public async Task<IEnumerable<ImportanceEmail>> GetImportanceEmail()
        {
            return await Banekockica_TestContext.ImportanceEmail.ToListAsync();
        }
    }
}
