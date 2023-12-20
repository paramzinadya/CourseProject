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
    /// Логика взаимодействия для ResieveWindow.xaml
    /// </summary>
    public partial class ResieveWindow : Window
    {
        public ResieveWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainScreen mainscreen = new MainScreen();
            mainscreen.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string Track = ISSUE.Text;

            Data newData = new Data();
            newData.DeserializeIssuedOrders();
            List<Order> ListOfIssuedOrders= new List<Order>();
            ListOfIssuedOrders = newData.ShowAllOrders();
            foreach(Order order in ListOfIssuedOrders)
            {
                if (order.TrackNumber == Track)
                {
                    if (MessageBox.Show("Заказ уже выдан")  == MessageBoxResult.OK)
                    {
                        MainScreen mainscreen = new MainScreen();
                        mainscreen.Show();
                        this.Hide();
                        break;
                    }
                }
            }

            bool flag = true;
            Data data = new Data();
            data.DeserializeToIssueOrders();
            List<Order> ListOfOrders1 = new List<Order>();
            ListOfOrders1 = data.ShowAllOrders();
            foreach (Order order in ListOfOrders1)
            {
                if (order.TrackNumber == Track)
                {
                    flag= false;
                    ResieveInfoWindow resieveinfowindow = new ResieveInfoWindow(Track);
                    resieveinfowindow.Show();
                    this.Hide();
                    break;
                }
            }
            if (flag)
            {
                if (MessageBox.Show("Отправление не найдено")  == MessageBoxResult.OK)
                {
                    MainScreen mainscreen = new MainScreen();
                    mainscreen.Show();
                    this.Hide();
                }
            }
        }
    }
}
