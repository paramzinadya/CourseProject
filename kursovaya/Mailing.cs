using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace kursovaya
{
    abstract public class Mailing
    {

        public virtual int GetTotalPrice(string Region, string Weight, string MailingType, int price)
        {
            int regKoeff = 0;

            List<string> reg1 = new List<string>() { "Новосибирская область", "Кемеровская область", "Омская область", "Томская область", "Алтайский край", "Республика Хакасия", "Красноярский край", "Республика Алтай" };
            List<string> reg2 = new List<string>() { "Челябинская область", "Ханты-Мансийский АО", "Тюменская область", "Пермский край", "Свердловская область", "Республика Тыва", "Курганская область" };
            List<string> reg3 = new List<string>() { "Забайкальский край", "Ульяновская область", "Республика Бурятия", "Самарская область", "Республика Коми", "Республика Башкортостан", "Саратовская область", "Республика Мордовия", "Пензенская область", "Оренбургская область", "Нижегородская область", "Республика Татарстан", "Кировская область", "Республика Марий Эл", "Удмуртская Республика" };
            List<string> reg4 = new List<string>() { "Ярославская область", "Республика Калмыкия", "Карачаево-Черкесская Республика", "Тульская область", "Тверская область", "Тамбовская область", "Ставропольский край", "Смоленская область", "Санкт-Петербург", "Ленинградская область", "Рязанская область", "Ростовская область", "Республика Карелия", "Орловская область", "Москва", "Московская область", "Липецкая область", "Курская область", "Краснодарский край", "Костромская область", "Калужская область", "Ивановская область", "Воронежская область", "Волгоградская область", "Владимирская область", "Белгородская область" };

            if (reg1.Contains(Region)) regKoeff = 150;
            else if (reg2.Contains(Region)) regKoeff = 200;
            else if (reg3.Contains(Region)) regKoeff = 250;
            else if (reg4.Contains(Region)) regKoeff = 300;
            else if (Region == "Другое") regKoeff = 600;
            else regKoeff = 350;

            price = price + regKoeff;
            return price;
        }
    }
}
