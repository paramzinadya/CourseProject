using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
    public enum Payment
    {
        Cash,
        Card
    }
    public class Order
    {
        public string TrackNumber { get; }
        public Sender sender { get; }
        public Resipient resipient { get; }
        public string Price { get; }
        public string Weight { get; }
        public string MailingType { get; }
        public string DateAndTime { get; }
        public Payment payment { get; }

        private bool CheckData(string TrackNumber, Sender sender, Resipient resipient, string Price, string Weight, string MailingType, string DateAndTime, Payment payment)
        {
            bool Check = true;

            if (TrackNumber == "")
            {
                Check = false;
                throw new ArgumentException("Трэк-номер не заполнен");
            }

            else if (sender == null)
            {
                Check = false;
                throw new ArgumentException("Отправитель не заполнен");
            }

            else if (resipient == null)
            {
                Check = false;
                throw new ArgumentException("Получатель не заполнен");
            }

            else if (Price == "")
            {
                Check = false;
                throw new ArgumentException("Цена не заполнена");
            }

            else if (Weight == "")
            {
                Check = false;
                throw new ArgumentException("Вес не заполнен");
            }

            else if (MailingType == "")
            {
                Check = false;
                throw new ArgumentException("Вид отправления не заполнен");
            }

            else if (DateAndTime == "")
            {
                Check = false;
                throw new ArgumentException("Дата и время не заполнены");
            }

            return Check;
        }

        
        public Order(Payment payment, string trackNumber, Sender sender, Resipient resipient, string Price, string Weight, string MailingType, string DateAndTime)
        {
            if (CheckData(trackNumber, sender, resipient, Price, Weight, MailingType, DateAndTime, payment) == true)
            {
                this.payment=payment;
                this.TrackNumber=trackNumber;
                this.sender=sender;
                this.resipient=resipient;
                this.Price=Price;
                this.Weight=Weight;
                this.MailingType=MailingType;
                this.DateAndTime=DateAndTime;
            }
        }
    }
}
