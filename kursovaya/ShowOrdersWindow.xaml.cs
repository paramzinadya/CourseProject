using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kursovaya
{
    /// <summary>
    /// Логика взаимодействия для ShowOrdersWindow.xaml
    /// </summary>
    public partial class ShowOrdersWindow : Window
    {
        public ShowOrdersWindow()
        {
            InitializeComponent();
            Data data1 = new Data();
            data1.DeserializeSentOrders();
            List<Order> ListOfOrders1 = new List<Order>();
            ListOfOrders1 = data1.ShowAllOrders();
            string NewList = "";
            int count = 1;
            foreach (Order order in ListOfOrders1)
            {
                NewList += "-------------------------------- "+count.ToString()+ " --------------------------------" + "\n\n";
                count++;
                NewList += "Трэк-номер: " + order.TrackNumber + "\n";
                NewList += "Дата и время отправки: " + order.DateAndTime + "\n";
                NewList += "Вид отправления: " + order.MailingType + "\n";
                NewList += "Вес: " + order.Weight + " г." + "\n";
                NewList += "Стоимость: " + order.Price + " руб." + "\n";
                if (order.payment == 0) NewList += "Тип оплаты: Банковской картой" + "\n\n";
                else NewList += "Тип оплаты: Наличными" + "\n\n";

                NewList += "ФИО отправителя: " + order.sender.Name + "\n";
                NewList += "Страна отправителя: " + order.sender.SenderAddress.Country + "\n";
                NewList += "Регион отправителя: " + order.sender.SenderAddress.Region + "\n";
                NewList += "Город отправителя: " + order.sender.SenderAddress.City + "\n";
                NewList += "Улица отправителя: " + order.sender.SenderAddress.Street + "\n";
                NewList += "Дом отправителя: " + order.sender.SenderAddress.HouseNumber + "\n";
                NewList += "Квартира отправителя: " + order.sender.SenderAddress.ApartmentNumber + "\n";
                NewList += "Индекс отправителя: " + order.sender.SenderAddress.Index + "\n";
                NewList += "Телефон отправителя: " + order.sender.PhoneNumber + "\n\n";

                NewList += "ФИО получателя: " + order.resipient.Name + "\n";
                NewList += "Страна получателя: " + order.resipient.ResipientAddress.Country + "\n";
                NewList += "Регион получателя: " + order.resipient.ResipientAddress.Region + "\n";
                NewList += "Город получателя: " + order.resipient.ResipientAddress.City + "\n";
                NewList += "Улица получателя: " + order.resipient.ResipientAddress.Street + "\n";
                NewList += "Дом получателя: " + order.resipient.ResipientAddress.HouseNumber + "\n";
                NewList += "Квартира получателя: " + order.resipient.ResipientAddress.ApartmentNumber + "\n";
                NewList += "Индекс получателя: " + order.resipient.ResipientAddress.Index + "\n";
                NewList += "Телефон получателя: " + order.resipient.PhoneNumber + "\n";
                NewList += "--------------------------------------------------------------------"  + "\n\n";

            }
            SENTORDERS.Text = NewList;

            Data data2 = new Data();
            data2.DeserializeIssuedOrders();
            List<Order> ListOfOrders2 = new List<Order>();
            ListOfOrders2 = data2.ShowAllOrders();
            string NewList2 = "";
            count= 1;
            foreach (Order order in ListOfOrders2)
            {
                NewList2 += "-------------------------------- "+count.ToString()+ " --------------------------------" + "\n\n";
                count++;
                NewList2 += "Трэк-номер: " + order.TrackNumber + "\n";
                NewList2 += "Дата и время отправки: " + order.DateAndTime + "\n";
                NewList2 += "Вид отправления: " + order.MailingType + "\n";
                NewList2 += "Вес: " + order.Weight + " г." + "\n";
                NewList2 += "Стоимость: " + order.Price + " руб." + "\n";
                if (order.payment == 0) NewList2 += "Тип оплаты: Банковской картой" + "\n\n";
                else NewList2 += "Тип оплаты: Наличными" + "\n\n";

                NewList2 += "ФИО отправителя: " + order.sender.Name + "\n";
                NewList2 += "Страна отправителя: " + order.sender.SenderAddress.Country + "\n";
                NewList2 += "Регион отправителя: " + order.sender.SenderAddress.Region + "\n";
                NewList2 += "Город отправителя: " + order.sender.SenderAddress.City + "\n";
                NewList2 += "Улица отправителя: " + order.sender.SenderAddress.Street + "\n";
                NewList2 += "Дом отправителя: " + order.sender.SenderAddress.HouseNumber + "\n";
                NewList2 += "Квартира отправителя: " + order.sender.SenderAddress.ApartmentNumber + "\n";
                NewList2 += "Индекс отправителя: " + order.sender.SenderAddress.Index + "\n";
                NewList2 += "Телефон отправителя: " + order.sender.PhoneNumber + "\n\n";

                NewList2 += "ФИО получателя: " + order.resipient.Name + "\n";
                NewList2 += "Страна получателя: " + order.resipient.ResipientAddress.Country + "\n";
                NewList2 += "Регион получателя: " + order.resipient.ResipientAddress.Region + "\n";
                NewList2 += "Город получателя: " + order.resipient.ResipientAddress.City + "\n";
                NewList2 += "Улица получателя: " + order.resipient.ResipientAddress.Street + "\n";
                NewList2 += "Дом получателя: " + order.resipient.ResipientAddress.HouseNumber + "\n";
                NewList2 += "Квартира получателя: " + order.resipient.ResipientAddress.ApartmentNumber + "\n";
                NewList2 += "Индекс получателя: " + order.resipient.ResipientAddress.Index + "\n";
                NewList2 += "Телефон получателя: " + order.resipient.PhoneNumber + "\n";
                NewList2 += "-------------------------------------------------------------------"  + "\n\n";
            }
            RESIEVEDORDERS.Text = NewList2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainScreen mainscreen = new MainScreen();
            mainscreen.Show();
            this.Hide();
        }
    }
}
