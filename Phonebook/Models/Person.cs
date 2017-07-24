using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class Person
    {
        public Name Name { get; set; }
        public Phone Phone { get; set; }
        public Email Email { get; set; }
        public Group Group { get; set; }
        public string Organization { get; set; }
        public Address Address { get; set; }
        public string NickName { get; set; }
        public string Website { get; set; }
        public override string ToString()
        {
            return Name.Prefix + "," + Name.Firstname + "," + Name.Middlename + "," + Name.Lastname + "," + Name.Suffix + "," + Phone.Number + "," + Phone.Type.ToString() + "," + Email.Address + "," + Email.Type + "," + Group.ToString() + "," + Organization + "," + Address.Street + "," + Address.City + "," + Address.State + "," + Address.ZipCode + "," + Address.Country + "," + Address.Type.ToString() + "," + NickName + "," + Website;
        }
    }
    public class Name {
        public string Prefix { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Suffix { get; set; }
    }
    public class Phone
    {
        public string Number { get; set; }
        public PhoneType Type { get; set; }
    }
  
    public class Email
    {
        public string Address { get; set; }
        public AddressType Type { get; set; }

    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public AddressType Type { get; set; }
    }
    //enumerates
    public enum AddressType
    {
        home,
        work,
        other
    }
    public enum Group
    {
        family,
        friends,
        work,
        others
    }
    public enum PhoneType
    {
        mobile,
        work,
        home,
        main,
        work_fax,
        home_fax,
        others
    }
}
