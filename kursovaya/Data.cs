using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace kursovaya
{
    public class Data
    {
        private List<Order> allOrders = new List<Order>();
        private List<User> allUsers = new List<User>();

        public List<Order> AllOrders
        {
            get { return allOrders; }
            set { allOrders = value; }
        }

        public List<User> AllUsers
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        public void SerializeSentOrders() //сериализация списка отправленных заказов
        {

            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Data\Files\Orders.json";
            string json = JsonConvert.SerializeObject(AllOrders, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
        public void DeserializeSentOrders() //десериализация списка отправленных заказов
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Data\Files\Orders.json";
            string jsonString = File.ReadAllText(fileName);
            AllOrders = JsonConvert.DeserializeObject<List<Order>>(jsonString);
        }

        public void DeserializeToIssueOrders() //десериализация списка прибывших в отделение заказов для выдачи
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Data\Files\IssuePostalItems.json";
            string jsonString = File.ReadAllText(fileName);
            AllOrders = JsonConvert.DeserializeObject<List<Order>>(jsonString);
        }

        public void SerializeIssuedOrders() //сериализация списка выданных заказов
        {

            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Data\Files\issued.json";
            string json = JsonConvert.SerializeObject(AllOrders, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public void DeserializeIssuedOrders() //десериализация списка выданных заказов
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Data\Files\issued.json";
            string jsonString = File.ReadAllText(fileName);
            AllOrders = JsonConvert.DeserializeObject<List<Order>>(jsonString);
        }

        public void DeserializeUsers() //десериализация списка сотрудников
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Data\Files\Users.json";
            string jsonString = File.ReadAllText(fileName);
            AllUsers = JsonConvert.DeserializeObject<List<User>>(jsonString);
        }

        public void SerializeThisUser() 
        {

            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Data\Files\ThisUser.json";
            string json = JsonConvert.SerializeObject(AllUsers, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
        public void DeserializeThisUser() 
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Data\Files\ThisUser.json";
            string jsonString = File.ReadAllText(fileName);
            AllUsers = JsonConvert.DeserializeObject<List<User>>(jsonString);
        }

        public void AddSentOrder(Order order) //добавление отправленного заказа
        {
            AllOrders.Add(order);
            SerializeSentOrders();
        }


        public void AddIssuedOrder(Order order) //добавление выданного заказа
        {
            AllOrders.Add(order);
            SerializeIssuedOrders();
        }

        public void AddThisUser(User user)
        {
            AllUsers.Add(user);
            SerializeThisUser();
        }


        public List<Order> ShowAllOrders()
        {
            return AllOrders.ToList();
        }

        public List<User> ShowAllUsers()
        {
            return AllUsers.ToList();
        }

    }
}
