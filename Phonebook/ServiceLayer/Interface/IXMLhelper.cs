using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Models;
namespace Phonebook.ServiceLayer.Interface
{
    interface IXMLhelper
    {
        Contacts ReadXml();
        void WriteXml(Contacts contact);
    }
}
