using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace kursovaya
{

    public class Resipient : Client
    {
        public Address ResipientAddress { get; }
        

        private bool Check(Address ResipientAddress)
        {
            bool check = true;
            if (ResipientAddress.Country == "" || ResipientAddress.Country == "СТРАНА")
            {
                check = false;
                throw new ArgumentException("Страна получателя не заполнена");
            }

            else if (ResipientAddress.Region == "")
            {
                check = false;
                throw new ArgumentException("Регион получателя не заполнен");
            }

            else if (ResipientAddress.City == "" || ResipientAddress.City == "ГОРОД")
            {
                check = false;
                throw new ArgumentException("Город получателя не заполнен");
            }

            else if (ResipientAddress.Street == "" || ResipientAddress.Street == "УЛИЦА")
            {
                check = false;
                throw new ArgumentException("Улица получателя не заполнена");
            }

            else if (ResipientAddress.HouseNumber == "" || ResipientAddress.HouseNumber == "ДОМ")
            {
                check = false;
                throw new ArgumentException("Дом получателя не заполнен");
            }

            else if (ResipientAddress.ApartmentNumber == "" || ResipientAddress.ApartmentNumber == "КВАРТИРА")
            {
                check = false;
                throw new ArgumentException("Квартира получателя не заполнена");
            }

            else if (ResipientAddress.Index == "" || ResipientAddress.Index == "ИНДЕКС")
            {
                check = false;
                throw new ArgumentException("Индекс получателя не заполнен");
            }
            return check;
        }
        public Resipient(string Name, Address ResipientAddress, string PhoneNumber) : base(Name, PhoneNumber)
        {
            if (Check(ResipientAddress) == true)
            {
                this.ResipientAddress = ResipientAddress;
            }
        }
    }
}
