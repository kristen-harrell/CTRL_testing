using System;
using System.Collections.Generic;

#nullable disable

namespace testing_ctrl_portal.Models
{
    public partial class PasswordReset
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public bool ResetCodeSent { get; set; }
        public DateTime ResetCodeTimestamp { get; set; }
        public string ResetCode { get; set; }
    }
}
