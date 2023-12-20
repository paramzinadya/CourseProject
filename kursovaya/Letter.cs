using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
    public class Letter : Mailing
    {
        public override int GetTotalPrice(string Region, string Weight, string MailingType, int price)
        {
            int letKoef = 0;
            int weight = Convert.ToInt32(Weight);
            if (MailingType == "Письмо") letKoef = 39;
            else if (MailingType == "Заказное письмо") letKoef = 70;
            else if (MailingType == "Заказное письмо 1 класса") letKoef = 119;
            else if (MailingType == "Ценное письмо") letKoef = 249;
            else if (MailingType == "Ценное письмо 1 класса") letKoef = 276;

            int weightkoeff = 0;
            if (weight > 0 && weight <= 100) weightkoeff = weight / 2;
            else throw new ArgumentException("Вес письма не должен превышать 100г и быть меньше 1г");
            price = price + letKoef + weightkoeff;
            return base.GetTotalPrice(Region, Weight, MailingType, price);
        }
    }
}
