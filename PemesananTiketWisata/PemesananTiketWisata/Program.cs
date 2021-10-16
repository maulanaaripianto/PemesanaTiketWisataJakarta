using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PemesananTiketWisata
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Wisata> dataUser = new List<Wisata>();
            InitiateUser(dataUser);

            int menu;
            bool exit = false;

            do
            {
                Console.Clear();
                Wisata.SelectMenu(out menu);
                switch (menu)
                {
                    case 1: Wisata.MenuCreateUser(dataUser); break;
                    case 2: Wisata.MenuLogin(dataUser); break;
                    case 3: exit = true; break;
                }

            } while (exit == false);
        }
        public static void InitiateUser(List<Wisata> users)
        {
            users.Add(new Wisata("user", "user", "user", "user"));

        }
    }
}
