using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
    abstract public class Client
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        private bool Check(string Name, string PhoneNumber)
        {
            bool check = true;
            if (Name == "" || Name == "ФИО")
            {
                check = false;
                throw new ArgumentException("ФИО не заполнено");
            }

            else if (PhoneNumber == "" || PhoneNumber == "НОМЕР ТЕЛЕФОНА")
            {
                check = false;
                throw new ArgumentException("Номер телефона получателя не заполнен");
            }

            else if (PhoneNumber.Length != 11)
            {
                check = false;
                throw new ArgumentException("Номер телефона должен состояить из 11 цифр");
            }

            else
            {
                foreach (var elem in PhoneNumber)
                {
                    if (elem < '0' || elem > '9')
                    {
                        check = false;
                        throw new ArgumentException("Номер телефона должен состоять только из цифр");
                    }
                }
            }
            return check;
        }

        public Client(string Name, string PhoneNumber)
        {
            if (Check(Name, PhoneNumber) == true)
            {
                this.Name = Name;
                this.PhoneNumber = PhoneNumber;
            }

        }
    }

}

