using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.ServiceLayer.Interface;
using Phonebook.Models;
using System.IO;
using System.Xml.Serialization;
namespace Phonebook.ServiceLayer
{
    class XMLhelper : IXMLhelper
    {
        XmlSerializer xs;
        public XMLhelper (){
            //create xml serializer object based on type of Contacts
           xs = new XmlSerializer(typeof(Contacts));
        }
        public void WriteXml(Contacts con) {
            //write to xml file
            using (TextWriter tw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/Contacts.xml"))
            {
                xs.Serialize(tw, con);
            }
            using(StreamWriter file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/Contacts.txt"))
            {
                foreach (var item in con.Persons)
                {
                    file.WriteLine(item.ToString());
                }
            }
            
        }
        public Contacts ReadXml()
        {
            //read xml file
            //using(FileStream fs= new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Contacts.xml", FileMode.Open))
            //{
            //    //convert string from file into object Contacts
            //    Contacts c =(Contacts) xs.Deserialize(fs);
            //    return c;
            //}
            string line;
            Contacts c = new Contacts();
            using(StreamReader file = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/Contacts.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] s = line.Split(',');
                    c.Persons.Add(new Person()
                    {
                        Name = new Name() { Prefix = s[0], Firstname = s[1], Middlename = s[2], Lastname = s[3], Suffix = s[4] },
                        Phone = new Phone() { Number = s[5], Type = (PhoneType)Enum.Parse(typeof(PhoneType), s[6]) },
                        Email = new Email() { Address = s[7], Type = (AddressType)Enum.Parse(typeof(AddressType), s[8]) },
                        Group = (Group)Enum.Parse(typeof(Group), s[9]),
                        Organization =s[10],
                        Address=new Address() { Street= s[11], City=s[12], State= s[13], ZipCode= s[14], Country= s[15], Type= (AddressType)Enum.Parse(typeof(AddressType),s[16])},
                        NickName= s[17],
                        Website= s[18]
                    });
                }
            }

            return c;
           
        }
    }
}
