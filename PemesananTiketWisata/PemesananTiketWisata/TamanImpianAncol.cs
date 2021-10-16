using System;
using System.Collections.Generic;
using System.Text;

namespace PemesananTiketWisata
{
    class TamanImpianAncol : Wisata
    {

        public TamanImpianAncol(string firstName, string lastName, string username, string password) : base(firstName, lastName, username, password)
        {
            this.isAdmin = true;
        }

        public static void MenuAdmin(List<Wisata> dataUser, int id)
        {
            bool exit = false;
            do
            {
                Console.Clear();
                foreach (var item in dataUser)
                {
                    Console.WriteLine("================================================");
                    Console.WriteLine($"Selamat Datang di Pembelian Tiket Dufan {item.firstName} {item.lastName}");
                    Console.WriteLine("================================================");
                    Console.WriteLine(" 1. Beli Tiket");
                    Console.WriteLine(" 2. Exit");
                    Console.WriteLine(" Input menu number to proceed...");
                }

                int adminMenu = 0;

                try
                {
                    adminMenu = Convert.ToInt32(Console.ReadLine());
                    if (adminMenu > 3) { throw new FormatException(); }
                }
                catch (Exception)
                {
                    Console.WriteLine("Input tidak sesuai!!!");
                    Console.ReadLine();
                    Console.Clear();
                }

                switch (adminMenu)
                {
                    case 1:
                        BeliTiket();
                        break;
                    case 2:
                        exit = true;
                        break;
                }
            } while (exit == false);
        }

        public static void BeliTiket()
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("Pilih Kategori Tiket");
                Console.WriteLine(" 1. Dewasa");
                Console.WriteLine(" 2. Anak-Anak");
                Console.WriteLine(" 3. Dewasa dan Anak - Anak");
                Console.WriteLine(" 4. Exit");
                Console.WriteLine(" Input menu number to proceed...");

                int adminMenu = 0;

                try
                {
                    adminMenu = Convert.ToInt32(Console.ReadLine());
                    if (adminMenu > 4) { throw new FormatException(); }
                }
                catch (Exception)
                {
                    Console.WriteLine("Input tidak sesuai!!!");
                    Console.ReadLine();
                    Console.Clear();
                }

                switch (adminMenu)
                {
                    case 1:
                        TiketDewasa();
                        break;
                    case 2:
                        TiketAnak();
                        break;
                    case 3:
                        TikeDewasaDanAnak();
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            } while (exit == false);
        }

        public static void TiketDewasa()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("Harga 1 Tiket 150.000/ Orang");
            Console.WriteLine("============================");
            Console.Write("Berapa Jumlah Tiket Yang Ingin Anda Beli : ");
            int jumlah = 0;

            try
            {
                jumlah = Convert.ToInt32(Console.ReadLine());
                if (jumlah < 1) { throw new FormatException(); }
            }
            catch (Exception)
            {
                Console.WriteLine("Input tidak sesuai!!!");
                Console.ReadLine();
                Console.Clear();
            }

            for (int i = 0; i < jumlah; i++)
            {
                Console.WriteLine($"\nData Pembeli   {(i + 1)}");
                Console.Write("Nama Lengkap : ");
                string namaPembeli = Console.ReadLine();
                Console.WriteLine("Pilih 1=Laki-laki 2=Perempuan");
                Console.Write("Gender : ");
                string gender = Console.ReadLine();
                if (gender == "1")
                {
                    Console.WriteLine("Laki-Laki");
                }else if (gender == "2")
                {
                    Console.WriteLine("Perempuan");
                }

                int usia;
                do
                {
                   Console.Write("Usia : ");
                   usia = Convert.ToInt32(Console.ReadLine());
                    if (usia < 7)
                    {
                        Console.WriteLine("Maaf Usia Min 7 tahun");
                    }
                } while (usia < 7);
               
                var rand = new Random();
                string idTiket = $"ID{rand.Next(1000)}";
                Console.WriteLine($"ID Tiket : {idTiket}");
            }

            Console.Clear();

            int total = jumlah * 150000;
            Console.WriteLine($"Total : {total}");

            int saldo=0;
            do
            {
                Console.Write("Masukkan Pembayaran : ");
                saldo = Convert.ToInt32(Console.ReadLine());
                if (saldo < total)
                {
                    Console.WriteLine("Maaf Pembayaran Kurang");
                }
            } while (saldo < total);
            int kembalian = saldo - total;
        }

        public static void TiketAnak()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("Harga 1 Tiket 100.000/ Orang dibawah 7 tahun");
            Console.WriteLine("============================");
            Console.Write("Berapa Jumlah Tiket Yang Ingin Anda Beli : ");
            int jumlah = 0;

            try
            {
                jumlah = Convert.ToInt32(Console.ReadLine());
                if (jumlah < 1) { throw new FormatException(); }
            }
            catch (Exception)
            {
                Console.WriteLine("Input tidak sesuai!!!");
                Console.ReadLine();
                Console.Clear();
            }

            for (int i = 0; i < jumlah; i++)
            {
                Console.WriteLine($"\nData Pembeli   {(i + 1)}");
                Console.Write("Nama Lengkap : ");
                string namaPembeli = Console.ReadLine();
                Console.WriteLine("Pilih 1=Laki-laki 2=Perempuan");
                Console.Write("Gender : ");
                string gender = Console.ReadLine();
                if (gender == "1")
                {
                    Console.WriteLine("Laki-Laki");
                }
                else if (gender == "2")
                {
                    Console.WriteLine("Perempuan");
                }

                int usia;
                do
                {
                    Console.Write("Usia : ");
                    usia = Convert.ToInt32(Console.ReadLine());
                    if (usia < 7)
                    {
                        Console.WriteLine("Maaf Usia Maks 6 tahun");
                    }
                } while (usia < 7);
                var rand = new Random();
                string idTiket = $"ID{rand.Next(1000)}";
                Console.WriteLine($"ID Tiket : {idTiket}" );
            }

            Console.Clear();

            int total = jumlah * 100000;
            Console.WriteLine($"Total : {total}");

            int saldo = 0;
            do
            {
                Console.Write("Masukkan Pembayaran : ");
                saldo = Convert.ToInt32(Console.ReadLine());
                if (saldo < total)
                {
                    Console.WriteLine("Maaf Pembayaran Kurang");
                }
            } while (saldo < total);
            int kembalian = saldo - total;
        }

        public static void TikeDewasaDanAnak()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("Harga 1 Tiket Dewasa 150.000");
            Console.WriteLine("============================");
            Console.Write("Berapa Jumlah Tiket Yang Ingin Anda Beli : ");
            int jumlah = 0;

            try
            {
                jumlah = Convert.ToInt32(Console.ReadLine());
                if (jumlah < 1) { throw new FormatException(); }
            }
            catch (Exception)
            {
                Console.WriteLine("Input tidak sesuai!!!");
                Console.ReadLine();
                Console.Clear();
            }

            for (int i = 0; i < jumlah; i++)
            {
                Console.WriteLine($"\nData Pembeli   {(i + 1)}");
                Console.Write("Nama Lengkap : ");
                string namaPembeli = Console.ReadLine();
                Console.WriteLine("Pilih 1=Laki-laki 2=Perempuan");
                Console.Write("Gender : ");
                string gender = Console.ReadLine();
                if (gender == "1")
                {
                    Console.WriteLine("Laki-Laki");
                }
                else if (gender == "2")
                {
                    Console.WriteLine("Perempuan");
                }
                int usia;
                do
                {
                    Console.Write("Usia : ");
                    usia = Convert.ToInt32(Console.ReadLine());
                    if (usia < 7)
                    {
                        Console.WriteLine("Maaf Usia Min 7 tahun");
                    }
                } while (usia < 7);
                var rand = new Random();
                string idTiket = $"ID{rand.Next(1000)}";
                Console.WriteLine($"ID Tiket : {idTiket}");
            }

            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("Harga 1 Tiket Anak-Anaka 100.000 dibawah 6");
            Console.WriteLine("============================");
            Console.Write("Berapa Jumlah Tiket Yang Ingin Anda Beli : ");
            int jumlah2 = 0;

            try
            {
                jumlah2 = Convert.ToInt32(Console.ReadLine());
                if (jumlah2 < 1) { throw new FormatException(); }
            }
            catch (Exception)
            {
                Console.WriteLine("Input tidak sesuai!!!");
                Console.ReadLine();
                Console.Clear();
            }

            for (int i = 0; i < jumlah2; i++)
            {
                Console.WriteLine($"\nData Pembeli   {(i + 1)}");
                Console.Write("Nama Lengkap : ");
                string namaPembeli = Console.ReadLine();
                Console.WriteLine("Pilih 1=Laki-laki 2=Perempuan");
                Console.Write("Gender : ");
                string gender = Console.ReadLine();
                if (gender == "1")
                {
                    Console.WriteLine("Laki-Laki");
                }
                else if (gender == "2")
                {
                    Console.WriteLine("Perempuan");
                }

                int usia;
                do
                {
                    Console.Write("Usia : ");
                    usia = Convert.ToInt32(Console.ReadLine());
                    if (usia < 7)
                    {
                        Console.WriteLine("Maaf Usia Maks 6 tahun");
                    }
                } while (usia < 7);
                var rand = new Random();
                string idTiket = $"ID{rand.Next(1000)}";
                Console.WriteLine($"ID Tiket : {idTiket}");
            }
            Console.Clear();

            int total = (jumlah * 150000)+(jumlah*100000);
            Console.WriteLine($"Total : {total}");

            int saldo = 0;
            do
            {
                Console.Write("Masukkan Pembayaran : ");
                saldo = Convert.ToInt32(Console.ReadLine());
                if (saldo < total)
                {
                    Console.WriteLine("Maaf Pembayaran Kurang");
                }
            } while (saldo < total);
            int kembalian = saldo - total;
        }
    }
}
