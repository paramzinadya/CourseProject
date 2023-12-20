using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
    public class Package : Mailing
    {
        public override int GetTotalPrice(string Region, string Weight, string MailingType, int price)
        {
            int packkoeff = 0;
            int weight = Convert.ToInt32(Weight);
            if (MailingType == "Мелкий пакет") packkoeff = 175;
            else if (MailingType == "Заказной мелкий пакет") packkoeff = 239;
            else if (MailingType == "Посылка") packkoeff = 267;
            else if (MailingType == "Посылка 1 класса") packkoeff = 309;
            else if (MailingType == "Ценная полсыка") packkoeff = 345;
            else if (MailingType == "Международная посылка") packkoeff = 1527;

            int weightkoeff = 0;
            if (weight >= 100 && weight <= 20000) weightkoeff = weight / 3;
            else throw new ArgumentException("Вес посылки не должен превышать 20кг и быть меньше 100г");

            price = price + packkoeff + weightkoeff;
            return base.GetTotalPrice(Region, Weight, MailingType, price);
        }
    }
}
