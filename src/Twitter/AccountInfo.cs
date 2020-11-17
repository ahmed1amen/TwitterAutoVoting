using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twitter
{
    public class AccountInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Verify { get; set; }
        public string Error { get; set; }
        public bool Done { get; set; }
    }
}
