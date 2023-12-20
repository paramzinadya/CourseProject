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
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Window
    {
        public MainScreen()
        {
            InitializeComponent();
            Data data = new Data();
            data.DeserializeThisUser();
            List<User> ThisUserList = new List<User>();
            ThisUserList = data.ShowAllUsers();
            foreach (User user in ThisUserList)
            {
                IMA.Text = "Сотрудник: " + user.Id.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendWindow sendwindow = new SendWindow();
            sendwindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResieveWindow resievewindow = new ResieveWindow();
            resievewindow.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ShowOrdersWindow showorderswindow = new ShowOrdersWindow();
            showorderswindow.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
