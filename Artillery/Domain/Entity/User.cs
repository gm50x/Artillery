using System;
using System.Collections.Generic;
using System.Text;

namespace Artillery.Domain.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime Creation { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {UserName} - {Email} - {Creation} ";
        }
    }
}
