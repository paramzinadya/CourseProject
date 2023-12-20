using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kursovaya
{
    /// <summary>
    /// Логика взаимодействия для ResieveInfoWindow.xaml
    /// </summary>
    public partial class ResieveInfoWindow : Window
    {
        public ResieveInfoWindow(string track)
        {

            InitializeComponent();
            Data data = new Data();
            data.DeserializeToIssueOrders();
            List<Order> ListOfOrders1 = new List<Order>();
            ListOfOrders1 = data.ShowAllOrders();
            foreach (Order order in ListOfOrders1)
            {
                if (order.TrackNumber == track)
                {
                    NOMER.Text = order.TrackNumber;
                    fio.Text = order.resipient.Name;
                    strana.Text = order.resipient.ResipientAddress.Country;
                    region.Text = order.resipient.ResipientAddress.Region;
                    gorod.Text = order.resipient.ResipientAddress.City;
                    ulica.Text = order.resipient.ResipientAddress.Street;
                    dom.Text = order.resipient.ResipientAddress.HouseNumber;
                    kv.Text = order.resipient.ResipientAddress.ApartmentNumber;
                    index.Text = order.resipient.ResipientAddress.Index;
                    telefon.Text = order.resipient.PhoneNumber;
                    fio_Copy.Text = order.sender.Name;
                    strana_Copy.Text = order.sender.SenderAddress.Country;
                    region_Copy.Text = order.sender.SenderAddress.Region;
                    gorod_Copy.Text = order.sender.SenderAddress.City;
                    ulica_Copy.Text = order.sender.SenderAddress.Street;
                    dom_Copy.Text = order.sender.SenderAddress.HouseNumber;
                    kv_Copy.Text = order.sender.SenderAddress.ApartmentNumber;
                    index_Copy.Text = order.sender.SenderAddress.Index;
                    telefon_Copy.Text = order.sender.PhoneNumber;
                    vid.Text = order.MailingType;
                    dataivrema.Text = order.DateAndTime;
                    ves.Text = order.Weight;
                    price.Text = order.Price;
                    if (order.payment == 0) tip.Text = "Банковской картой";
                    else tip.Text = "Наличными";
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainScreen mainscreen = new MainScreen();
            mainscreen.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Address senderAddress = new Address();
            senderAddress.Country = strana.Text;
            senderAddress.Region = region.Text;
            senderAddress.City = gorod.Text;
            senderAddress.Street = ulica.Text;
            senderAddress.HouseNumber = dom.Text;
            senderAddress.ApartmentNumber = kv.Text;
            senderAddress.Index = index.Text;

            Sender senderIssued = new Sender(fio.Text, senderAddress, telefon.Text);

            Address resipientAddress = new Address();
            resipientAddress.Country = strana_Copy.Text;
            resipientAddress.Region = region_Copy.Text;
            resipientAddress.City = gorod_Copy.Text;
            resipientAddress.Street = ulica_Copy.Text;
            resipientAddress.HouseNumber = dom_Copy.Text;
            resipientAddress.ApartmentNumber = kv_Copy.Text;
            resipientAddress.Index = index_Copy.Text;

            Resipient resipientIssued = new Resipient(fio_Copy.Text, resipientAddress, telefon_Copy.Text);
            Payment paymentIssued = new Payment();
            if (tip.Text == "Банковской картой") paymentIssued = Payment.Card;
            else paymentIssued = Payment.Cash;


            Order IssuedOrder = new Order(paymentIssued, NOMER.Text, senderIssued, resipientIssued, price.Text, ves.Text, vid.Text, dataivrema.Text);

            Data data = new Data();
            data.DeserializeIssuedOrders();
            data.AddIssuedOrder(IssuedOrder);


            if (MessageBox.Show("Отправление выдано")  == MessageBoxResult.OK)
            {
                MainScreen mainscreen = new MainScreen();
                mainscreen.Show();
                this.Hide();
            }
        }
    }
}
