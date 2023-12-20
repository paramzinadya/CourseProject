using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kursovaya
{
    public class Sender : Client
    {
        public Address SenderAddress { get; }


        private bool Check(Address SenderAddress)
        {
            bool check = true;
            if (SenderAddress.Country == "" || SenderAddress.Country == "СТРАНА")
            {
                check = false;
                throw new ArgumentException("Страна получателя не заполнена");
            }

            else if (SenderAddress.Region == "")
            {
                check = false;
                throw new ArgumentException("Регион получателя не заполнен");
            }

            else if (SenderAddress.City == "" || SenderAddress.City == "ГОРОД")
            {
                check = false;
                throw new ArgumentException("Город получателя не заполнен");
            }

            else if (SenderAddress.Street == "" || SenderAddress.Street == "УЛИЦА")
            {
                check = false;
                throw new ArgumentException("Улица получателя не заполнена");
            }

            else if (SenderAddress.HouseNumber == "" || SenderAddress.HouseNumber == "ДОМ")
            {
                check = false;
                throw new ArgumentException("Дом получателя не заполнен");
            }

            else if (SenderAddress.ApartmentNumber == "" || SenderAddress.ApartmentNumber == "КВАРТИРА")
            {
                check = false;
                throw new ArgumentException("Квартира получателя не заполнена");
            }

            else if (SenderAddress.Index == "" || SenderAddress.Index == "ИНДЕКС")
            {
                check = false;
                throw new ArgumentException("Индекс получателя не заполнен");
            }
            return check;
        }
        public Sender(string Name, Address SenderAddress, string PhoneNumber) : base(Name, PhoneNumber)
        {
            if (Check(SenderAddress) == true)
            {
                this.SenderAddress = SenderAddress;
            }
        }
    }
}
