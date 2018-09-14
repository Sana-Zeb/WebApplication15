using System;
using System.Collections.Generic;

namespace WebApplication15.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public int? PhoneNo { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
    }
}
