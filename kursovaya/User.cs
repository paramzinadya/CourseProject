using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kursovaya
{
        public class User
        {
            public string Login { get; }
            public string Password { get; }
            public string Id { get; }

            public User(string Login, string Password, string Id)
            {
                this.Login = Login;
                this.Password = Password;
                this.Id = Id;
            }
        }
}
