using System;
using System.Collections.Generic;

namespace testing_ctrl_portal.Models
{
    public partial class PersistCode
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime? Expiration { get; set; }
        public string ResetCode { get; set; }
    }
}
