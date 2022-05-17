using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmailProject.Models
{
    public partial class ImportanceEmail
    {
        public ImportanceEmail()
        {
            Email = new HashSet<Email>();
        }

        public int ImportanceEmailId { get; set; }
        public string ImportanceName { get; set; }

        public virtual ICollection<Email> Email { get; set; }

        public static implicit operator ImportanceEmail(List<ImportanceEmail> v)
        {
            throw new NotImplementedException();
        }
    }
}
