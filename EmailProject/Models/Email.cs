using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmailProject.Models
{
    public partial class Email
    {
        public int EmialId { get; set; }
        public string FromEmailAddress { get; set; }
        public string ToEmailAddress { get; set; }
        public string CcemailAddresses { get; set; }
        public string Subject { get; set; }
        public int Importance { get; set; }
        public string EmailContent { get; set; }

        public virtual ImportanceEmail ImportanceNavigation { get; set; }
    }
}
