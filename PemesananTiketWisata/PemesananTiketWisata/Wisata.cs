using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PemesananTiketWisata
{
    class Wisata
    {
        public string lastName;
        protected string password;
        public string firstName;
        public string username;
        public bool isAdmin;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Wisata(string firstName, string lastName, string username, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static void SelectMenu(out int menu)
        {
            
            menu = 0;
            try
            {
                Console.Clear();
                Console.WriteLine("**********************************************************");
                Console.WriteLine("* Selamat Datang di Program Pemesana Tiket Wisata Jakarta*");
                Console.WriteLine("**********************************************************");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Select Menu : ");
                menu = Convert.ToInt32(Console.ReadLine());
                if (menu > 3)
                {
                    throw new FormatException();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Input tidak sesuai!!!");
                Console.ReadLine();
                Console.Clear();
            }
        }



        public static void MenuCreateUser(List<Wisata> dataUser)
        {
            Console.Clear();
            bool isSuccess = false;
            do
            {
                Console.Clear();
                Console.WriteLine("==========Create User===========");
                Console.Write("First Name   : ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name    : ");
                string lastName = Console.ReadLine();
                Console.Write("Password     : ");
                string password = Console.ReadLine();
                string username = firstName.Substring(0, 2) + lastName.Substring(0, 3);

                ///menghindari username yang sama
                bool isExist = false;
                do
                {
                    if (dataUser.Exists(element => element.username == username))
                    {
                        isExist = true;
                        int id = dataUser.FindIndex(element => element.username == username);
                        var rand = new Random();
                        username = username + rand.Next(100);
                    }
                    else
                    { isExist = false; }

                } while (isExist == true);

                try
                {
                    CheckPasswordCriteria(password);
                    Console.WriteLine("Akun berhasil dibuat");
                    dataUser.Add(new Wisata(firstName, lastName, username, password));
                    isSuccess = true;

                }
                catch (Exception)
                {
                    Console.WriteLine("Silahkan ulangi prosedur");
                    Console.ReadKey();
                }

                Console.WriteLine($"Username anda adalah   : {username}");
                Console.ReadKey();
            } while (isSuccess == false);
        }

        public static void MenuLogin(List<Wisata> dataUser)
        {
            Console.Clear();
            Console.WriteLine("Please input your login info...");
            Console.Write("username  : ");
            string username = Console.ReadLine();
            Console.Write("Password  : ");
            string password = Console.ReadLine();
            int id = 0;
            foreach (var item in dataUser)
            {
                if (username == item.username)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, item.Password))
                    {
                        
                            TamanImpianAncol.MenuAdmin(dataUser, id);
                    }
                    else
                    {
                        Console.WriteLine("Password tidak sesuai!!");
                        Console.ReadKey();
                        break;
                    }
                }
                else
                {
                    if (id == dataUser.Count - 1)
                    {
                        Console.WriteLine("Data pengguna tidak ditemukan!!");
                        Console.ReadKey();
                    }
                }
                id += 1;
            }
        }

        public static void CheckPasswordCriteria(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            bool hasSymbols = false;
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            //untuk ngecek simbol
            foreach (var item in specialChar)
            {
                if (password.Contains(item))
                { hasSymbols = true; }
            }

            if (!hasLowerChar.IsMatch(password))
            {
                Console.WriteLine("Kata Sandi Wajib diisi");
                throw new FormatException();

            }
            else if (!hasUpperChar.IsMatch(password))
            {
                Console.WriteLine("Kata Sandi Wajib Menggunakan Huruf Besar");
                throw new FormatException();
            }
            else if (!hasMiniMaxChars.IsMatch(password))
            {
                Console.WriteLine("Kata sandi tidak boleh kurang dari atau lebih dari 12 karakter");
                throw new FormatException();
            }
            else if (!hasNumber.IsMatch(password))
            {
                Console.WriteLine("Kata Sandi Wajib diisi Menggunakan Angka");
                throw new FormatException();
            }

            else if (hasSymbols == false)
            {
                Console.WriteLine("Kata Sandi Wajib diisi Menggunakan Simbol");
                throw new FormatException();
            }
            else if (password.Length < 2)
            {
                Console.WriteLine("Kata sandi harus mengandung setidaknya satu karakter huruf besar-kecil");
            }
        }
    }
}
