using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUdp_client
{
    class User
    {
        private DateTime now;

        public User(string nickname, DateTime time, string message)
        {
            Nickname = nickname;
            time = DateSent;
            Message = message;
        }

        public string Nickname { get; set; }

        public DateTime DateSent { get; set; }

        public string Message { get; set; }

    }
}
