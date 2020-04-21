using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Contacts_FGD
{
    public class Person
    {
        public Guid ID { get; } // inmutable
        public string gsName { get; set; }
        public string gsSurname { get; set; }
        public string gsNickname { get; set; }
        public string gsAdress { get; set; }
        public string gsPhone { get; set; }
        public string gsEmail { get; set; }
        public DateTime gdtBirthday { get; set; }
        public string gsSkype { get; set; }
        public string gsThreema { get; set; }

        public Person()
        {
            ID = Guid.NewGuid();
        }

        public Person(string name, string surname)
        {
            ID = Guid.NewGuid();
            gsName = name;
            gsSurname = surname;
            gsAdress = "";
            gsPhone = "";
            gsEmail = "";
            gdtBirthday = DateTime.Now;
            gsSkype = "";
            gsThreema = "";
        }

        public override string ToString()
        {
            return gsName + " " + gsSurname;
        }
    }
}