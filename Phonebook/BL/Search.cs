using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Models;
using System.Reflection;

namespace Phonebook.BL
{
    public class Search:ISearch
    {
        public Contacts Find(string s, Contacts c)
        {
            Contacts result = new Contacts();
            //navigate to all person in contact
            foreach(var person in c.Persons)
            {
                //if string is found in any property/node of the object it will be added to the result list
                if (Node(s, person))
                {
                    result.Persons.Add(person);
                  
                };
            }
            //return list of persons that matches the string otherwise return all persons if not found
            if (result.Persons.Count != 0)
            {
                return result;
            }
            return c;
        }
  
        private bool Node(string s, object p)
        {
           //get type of p and store it to type variable
            Type type = p.GetType();
            //get list of properties Type of p. EX Name, Phone, Email, etc..
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            //navigate to all properties
            foreach (var prop in props)
            {
                //if property is not string
                if (p.GetType() != typeof(String))
                {

                    //check value if null escapes blank objects in the form
                    if (prop.GetValue(p, null) != null)
                    {

                        //check if the properties has nested objects
                        if (prop.GetValue(p).GetType().GetProperties().Length > 0)
                        {   
                            //recursive call this function to navigate to nested objects 
                            var re = Node(s, prop.GetValue(p, null));
                            if (re)
                            {
                                return re;
                            }
                        }
                    }

                }
                //if type is string
                else
                {
                    //check if equal to s
                    if (s.ToUpper() == p.ToString().ToUpper())
                    {
                        return true;

                    }
                }
            }
            //not found
            return false;
        }
    }
}
