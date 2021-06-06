using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Password_Generator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string ver = "0.0.3";
            Console.Title = $"Random Password Generator by Adiks, wersja {ver}";
            for (; ; )
            {
                bool spr = false;
                int dlg = 0;

                while (!spr)
                {
                    Console.Write("Wprowadź długość hasła: ");
                    string dlugosc = Console.ReadLine();
                    spr = int.TryParse(dlugosc, out dlg);

                    if (dlg > 2048 || dlg < 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wprowadzona długość musi być liczbą całkowitą w zakresie od 6 do 2048");
                        Console.ResetColor();

                        spr = false;

                        continue;
                    }
                }

                Console.Clear();

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("----------Wybierz-typ-losowego-hasła----------");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("- 1. Małe litery                             -");
                Console.WriteLine("- 2. Duże litery                             -");
                Console.WriteLine("- 3. Małe i duże litery                      -");
                Console.WriteLine("- 4. Cyfry                                   -");
                Console.WriteLine("- 5. Cyfry i małe litery                     -");
                Console.WriteLine("- 6. Cyfry i duże litery                     -");
                Console.WriteLine("- 7. Cyfry, małe litery i duże litery        -");
                Console.WriteLine("- 8. Cyfry, małe litery, duże litery i znaki -");
                Console.WriteLine("- 9. BRAK                                    -");
                Console.WriteLine("- 0. Wyjdź z programu                        -");
                Console.WriteLine("----------------------------------------------");
                Console.Write("Wybor: ");

                char wybor = Console.ReadKey().KeyChar;
                Random losuj = new Random();
                StringBuilder builder = new StringBuilder();

                Console.Clear();

                switch (wybor)
                {
                    case '1':
                        for (int i = 0; i < dlg; i++)
                        {
                            char litera = (char)(losuj.Next(97, 123));
                            builder.Append(litera);
                        }
                        zakonczenie(builder.ToString());
                        break;
                    case '2':
                        for (int i = 0; i < dlg; i++)
                        {
                            char litera = (char)(losuj.Next(65, 91));
                            builder.Append(litera);
                        }
                        zakonczenie(builder.ToString());
                        break;
                    case '3':
                        for (int i = 0; i < dlg; i++)
                        {
                            char litera = (char)(losuj.Next(65, 123));
                            if (litera > 90 && litera < 97)
                            {
                                i--;
                                continue;
                            }
                            builder.Append(litera);
                        }
                        zakonczenie(builder.ToString());
                        break;
                    case '4':
                        for (int i = 0; i < dlg; i++)
                        {
                            char litera = (char)(losuj.Next(48, 58));
                            builder.Append(litera);
                        }
                        zakonczenie(builder.ToString());
                        break;
                    case '5':
                        for (int i = 0; i < dlg; i++)
                        {
                            char litera = (char)(losuj.Next(48, 122));
                            if (litera > 57 && litera < 97)
                            {
                                i--;
                                continue;
                            }
                            builder.Append(litera);
                        }
                        zakonczenie(builder.ToString());
                        break;
                    case '6':
                        for (int i = 0; i < dlg; i++)
                        {
                            char litera = (char)(losuj.Next(48, 91));
                            if (litera > 57 && litera < 65)
                            {
                                i--;
                                continue;
                            }
                            builder.Append(litera);
                        }
                        zakonczenie(builder.ToString());
                        break;
                    case '7':
                        for (int i = 0; i < dlg; i++)
                        {
                            char litera = (char)(losuj.Next(48, 122));
                            if (litera >= 48 && litera <= 57)
                            {
                                builder.Append(litera);
                            }
                            else if (litera >= 65 && litera <= 90)
                            {
                                builder.Append(litera);
                            }
                            else if (litera >= 97 && litera <= 122)
                            {
                                builder.Append(litera);
                            }
                            else
                            {
                                i--;
                                continue;
                            }
                        }
                        zakonczenie(builder.ToString());
                        break;
                    case '8':
                        for (int i = 0; i < dlg; i++)
                        {
                            char litera = (char)(losuj.Next(48, 122));
                            builder.Append(litera);
                        }
                        zakonczenie(builder.ToString());
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Błędny wybór");
                        Console.ResetColor();
                        break;
                }
            }
        }
        static void zakonczenie(string haslo)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Twoje wygenerowane hasło to: ");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(haslo);

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Hasło zostało automatycznie skopiowane do schowka");
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");

            Clipboard.SetText(haslo);

            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}