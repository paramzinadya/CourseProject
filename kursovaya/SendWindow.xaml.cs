using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
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
    /// Логика взаимодействия для SendWindow.xaml
    /// </summary>
    public partial class SendWindow : Window
    {
        public bool Card;
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
        public SendWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Address SendAddress = new Address();
                SendAddress.Country = STRANA.Text;
                SendAddress.Region = REGION.Text;
                SendAddress.City = GOROD.Text;
                SendAddress.Street = ULICA.Text;
                SendAddress.HouseNumber = DOM.Text;
                SendAddress.ApartmentNumber = KV.Text;
                SendAddress.Index = INDEX.Text;

                Sender newSender = new Sender(FIO.Text, SendAddress, TELEFON.Text);


                Address ResAddress = new Address();
                ResAddress.Country = STRANA1.Text;
                ResAddress.Region = REGION1.Text;
                ResAddress.City = GOROD1.Text;
                ResAddress.Street = ULICA1.Text;
                ResAddress.HouseNumber = DOM1.Text;
                ResAddress.ApartmentNumber = KV1.Text;
                ResAddress.Index = INDEX1.Text;

                Resipient newRecipient = new Resipient(FIO1.Text, ResAddress, TELEFON1.Text);


                Payment payment = new Payment();

                if (Card) payment = Payment.Card;
                else payment = Payment.Cash;

                Order NewOrder = new Order(payment, TRACKNOMER.Text, newSender, newRecipient, PRICE.Text, VES.Text, VID.Text, TIME.Text);

                Data data = new Data();
                data.DeserializeSentOrders();
                data.AddSentOrder(NewOrder);


                if (MessageBox.Show("Отправлено")  == MessageBoxResult.OK)
                {
                    MainScreen mainscreen = new MainScreen();
                    mainscreen.Show();
                    this.Hide();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка! {ex.Message}");
            }

            
        }

        private void STRANA1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void GENERACIA_Click(object sender, RoutedEventArgs e)
        {
            if (STRANA1.Text == "Россия" || STRANA1.Text == "Российская Федерация")
            {
                Random random = new Random();
                long number = (long)(random.NextDouble() * 90000000000000) + 10000000000000;
                string numberString = number.ToString();
                TRACKNOMER.Text = numberString;
            }
            else if (STRANA1.Text == "" || STRANA1.Text == "СТРАНА")
            {
                TRACKNOMER.Text = "Страна не заполнена";
            }
            else
            {
                Random random = new Random();
                string Bukvi = "";
                for (int i = 0; i < 3; i++)
                {
                    char uppercaseLetter = (char)random.Next(65, 91);
                    Bukvi += uppercaseLetter;
                }


                long number = (long)(random.NextDouble() * 9000000000000) + 1000000000000;
                string numberString = Bukvi + number.ToString();
                TRACKNOMER.Text = numberString;
            }

            TIME.Text = DateTime.Now.ToString();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Card = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Card = false;
        }

        private void PRICEBUTTON_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int price = 0;

                if (VID.Text.Contains("письмо") || VID.Text.Contains("Письмо"))
                {
                    Letter letter = new Letter();
                    price = letter.GetTotalPrice(REGION1.Text, VES.Text, VID.Text, 0);
                }
                else if (VID.Text.Contains("посылка") || VID.Text.Contains("Посылка") || VID.Text.Contains("пакет"))
                {
                    Package package = new Package();
                    price = package.GetTotalPrice(REGION1.Text, VES.Text, VID.Text, 0);
                }
                else if (VID.Text.Contains("бандероль") || VID.Text.Contains("Бандероль"))
                {
                    ParcelPost parcelpost = new ParcelPost();
                    price = parcelpost.GetTotalPrice(REGION1.Text, VES.Text, VID.Text, 0);
                }

                PRICE.Text = price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка! {ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainScreen mainscreen = new MainScreen();
            mainscreen.Show();
            this.Hide();
        }
    }
}
