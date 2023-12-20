using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
    public class ParcelPost : Mailing
    {
        public override int GetTotalPrice(string Region, string Weight, string MailingType, int price)
        {
            int typekoeff = 0;
            int weight = Convert.ToInt32(Weight);
            if (MailingType == "Бандероль") typekoeff = 77;
            else if (MailingType == "Заказная бандероль") typekoeff = 96;
            else if (MailingType == "Заказная бандероль 1 класса") typekoeff = 125;
            else if (MailingType == "Ценная бандероль") typekoeff = 274;
            else if (MailingType == "Ценная бандероль 1 класса") typekoeff = 299;

            int weightkoeff = 0;
            if (weight > 100 && weight <= 2000) weightkoeff = weight / 5;
            else throw new ArgumentException("Вес бандероли не должен превышать 2кг и быть меньше 100 г");


            price = price + typekoeff + weightkoeff;
            return base.GetTotalPrice(Region, Weight, MailingType, price);
        }
    }
}
