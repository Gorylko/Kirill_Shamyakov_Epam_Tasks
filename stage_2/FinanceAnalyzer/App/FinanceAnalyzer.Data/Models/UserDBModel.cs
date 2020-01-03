using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Data.Models
{
    internal class UserDBModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public byte[] Password { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
