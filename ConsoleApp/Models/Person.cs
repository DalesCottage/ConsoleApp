using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Person
    {
        public virtual  int Id { get; set; }
        public virtual string FirstName { get; set; }    // same as db column names 
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
    }
}
