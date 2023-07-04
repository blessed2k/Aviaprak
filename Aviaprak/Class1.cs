using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviaprak
{
    internal class UserInfo
    {
        private static string logIn;

        public static string LogIn
        {
            get { return logIn; }
            set { logIn = value; }
        }
    }
}
