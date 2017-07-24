using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class Contacts
    {
       public List<Person> Persons { get; set; }
       public Contacts()
        {
            Persons = new List<Person>();
        }
    }
}
