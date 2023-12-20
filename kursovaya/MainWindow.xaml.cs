using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursovaya
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            Data data = new Data();
            data.DeserializeUsers();
            bool Flag = true ;
            List<User> ListOfUsers = new List<User>();
            ListOfUsers = data.ShowAllUsers();
            foreach (User user in ListOfUsers)
            {
                if (user.Login == username && user.Password == password)
                {
                    Data newdata = new Data();
                    User thisuser = new User(user.Login, user.Password, user.Id);
                    newdata.AddThisUser(thisuser);
                    MainScreen mainscreen = new MainScreen();
                    mainscreen.Show();
                    this.Hide();
                    Flag= false;
                    break;   
                }
            }
            if (Flag)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

