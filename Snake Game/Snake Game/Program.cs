using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        static Random veletlen = new Random();
        static int i;
        static int sebesseg = 500;
        static byte kigyoTestoHossz = 2;
        static byte fejx, fejy, taplalekx, taplaleky, holvoltx, holvolty;
        static byte y, x, hanyszorfutottle;
        static byte pontok = 0;
        static byte[] testx = new byte[1000];
        static byte[] testy = new byte[1000];                                     // A kígyó testének kordinátái.
        static char merrenez = 'e';                                              // A kígyó haladási íránya (e: előre, j:jobbra, b:balra, h:hátra)
        static ConsoleKeyInfo irany = new ConsoleKeyInfo();

        static void Palyagenerallas()
        {
            for (x = 0; x <= 50; ++x)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("X");
            }
            for (y = 1; y <= 24; ++y)
            {
                Console.SetCursorPosition(50, y);
                Console.Write("X");
            }
            for (x = 0; x <= 49; ++x)
            {
                Console.SetCursorPosition(x, 24);
                Console.Write("X");
            }
            for (y = 1; y <= 23; ++y)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("X");
            }
        }
        static void Kigyogenerallas()
        {
            for (i = 0; i <= 2; ++i)                                   // Kígyó rajzolás, a táplálékgenerállás előtt kell lefutnia!
            {
                Console.SetCursorPosition(25, 13 - i);
                Console.Write("O");
            }
            testx[0] = 25;
            testx[1] = 25;
            testy[0] = 12;
            testy[1] = 13;
            fejx = 25;
            fejy = 11;
        }

        static void Taplalekgenerallas()
        {
            bool exit = false;
            do
            {
                taplalekx = (byte)veletlen.Next(1, 49);
                taplaleky = (byte)veletlen.Next(1, 23);
                hanyszorfutottle = 0;
                for (i = 0; i <= kigyoTestoHossz; ++i)
                {
                    if (taplalekx != testx[i] && taplaleky != testy[i] && taplalekx != fejx && taplaleky != fejy)
                    {
                        hanyszorfutottle++;
                    }
                }
                if (hanyszorfutottle == kigyoTestoHossz)
                    exit = true;
            } while (exit == false);                                                                                  // Feltétel, hogy ne a kígyó testébe generálja.
            Console.SetCursorPosition(taplalekx, taplaleky);
            Console.Write("*");
        }        
        static void Bemenet(int sebesseg)
        {
            System.Threading.Thread.Sleep(sebesseg);
            if (Console.KeyAvailable)
            {
                irany = Console.ReadKey(true);
            }
        }

        static void Mozgas()
        {
            
            if (irany.KeyChar == 'w' && merrenez == 'j' || irany.KeyChar == 'w' && merrenez == 'b')
            {
                holvoltx = fejx;
                holvolty = fejy;
                fejy--;
                Console.SetCursorPosition(fejx, fejy);
                Console.Write("O");
                for (i = kigyoTestoHossz; i >= 0; --i)
                {
                    x = testx[i];
                    y = testy[i];
                    testx[i] = holvoltx;
                    testy[i] = holvolty;
                    Console.SetCursorPosition(testx[i], testy[i]);
                    Console.Write("O");
                    holvoltx = x;
                    holvolty = y;
                }
                Console.SetCursorPosition(holvoltx, holvolty);
                Console.Write(" ");
                merrenez = 'e';
            }

            else if (irany.KeyChar == 'd' && merrenez == 'h' || irany.KeyChar == 'd' && merrenez == 'e')
            {
                holvoltx = fejx;
                holvolty = fejy;
                fejx++;
                Console.SetCursorPosition(fejx, fejy);
                Console.Write("O");
                for (i = kigyoTestoHossz; i >= 0; --i)
                {
                    x = testx[i];
                    y = testy[i];
                    testx[i] = holvoltx;
                    testy[i] = holvolty;
                    Console.SetCursorPosition(testx[i], testy[i]);
                    Console.Write("O");
                    holvoltx = x;
                    holvolty = y;
                }
                Console.SetCursorPosition(holvoltx, holvolty);
                Console.Write(" ");
                merrenez = 'j';
            }
            else if (irany.KeyChar == 's' && merrenez == 'j' || irany.KeyChar == 's' && merrenez == 'b')
            {
                holvoltx = fejx;
                holvolty = fejy;
                fejy++;
                Console.SetCursorPosition(fejx, fejy);
                Console.Write("O");
                for (i = kigyoTestoHossz; i >= 0; --i)
                {
                    x = testx[i];
                    y = testy[i];
                    testx[i] = holvoltx;
                    testy[i] = holvolty;
                    Console.SetCursorPosition(testx[i], testy[i]);
                    Console.Write("O");
                    holvoltx = x;
                    holvolty = y;
                }
                Console.SetCursorPosition(holvoltx, holvolty);
                Console.Write(" ");
                merrenez = 'h';
            }
            else if (irany.KeyChar == 'a' && merrenez == 'h' || irany.KeyChar == 'a' && merrenez == 'e')
            {
                holvoltx = fejx;
                holvolty = fejy;
                fejx--;
                Console.SetCursorPosition(fejx, fejy);
                Console.Write("O");
                for (i = kigyoTestoHossz; i >= 0; --i)
                {
                    x = testx[i];
                    y = testy[i];
                    testx[i] = holvoltx;
                    testy[i] = holvolty;
                    Console.SetCursorPosition(testx[i], testy[i]);
                    Console.Write("O");
                    holvoltx = x;
                    holvolty = y;
                }
                Console.SetCursorPosition(holvoltx, holvolty);
                Console.Write(" ");
                merrenez = 'b';
            }
            else if (merrenez == 'e')
            {
                holvoltx = fejx;
                holvolty = fejy;
                fejy--;
                Console.SetCursorPosition(fejx, fejy);
                Console.Write("O");
                for (i = kigyoTestoHossz; i >= 0; --i)
                {
                    x = testx[i];                 
                    y = testy[i];
                    testx[i] = holvoltx;
                    testy[i] = holvolty;
                    Console.SetCursorPosition(testx[i], testy[i]);
                    Console.Write("O");
                    holvoltx = x;
                    holvolty = y;
                }
                Console.SetCursorPosition(holvoltx, holvolty);
                Console.Write(" ");
            }
            else if (merrenez == 'j')
            {
                holvoltx = fejx;
                holvolty = fejy;
                fejx++;
                Console.SetCursorPosition(fejx, fejy);
                Console.Write("O");
                for (i = kigyoTestoHossz; i >= 0; --i)
                {
                    x = testx[i];                 
                    y = testy[i];
                    testx[i] = holvoltx;
                    testy[i] = holvolty;
                    Console.SetCursorPosition(testx[i], testy[i]);
                    Console.Write("O");
                    holvoltx = x;
                    holvolty = y;
                }
                Console.SetCursorPosition(holvoltx, holvolty);
                Console.Write(" ");
            }
            else if ( merrenez == 'b')
            {
                holvoltx = fejx;
                holvolty = fejy;
                fejx--;
                Console.SetCursorPosition(fejx, fejy);
                Console.Write("O");
                for (i = kigyoTestoHossz; i >= 0; --i)
                {
                    x = testx[i];                 
                    y = testy[i];
                    testx[i] = holvoltx;
                    testy[i] = holvolty;
                    Console.SetCursorPosition(testx[i], testy[i]);
                    Console.Write("O");
                    holvoltx = x;
                    holvolty = y;
                }
                Console.SetCursorPosition(holvoltx, holvolty);
                Console.Write(" ");
            }
            else if (merrenez == 'h')
            {
                holvoltx = fejx;
                holvolty = fejy;
                fejy++;
                Console.SetCursorPosition(fejx, fejy);
                Console.Write("O");
                for (i = kigyoTestoHossz; i >= 0; --i)
                {
                    x = testx[i];                 
                    y = testy[i];
                    testx[i] = holvoltx;
                    testy[i] = holvolty;
                    Console.SetCursorPosition(testx[i], testy[i]);
                    Console.Write("O");
                    holvoltx = x;
                    holvolty = y;
                }
                Console.SetCursorPosition(holvoltx, holvolty);
                Console.Write(" ");
            }

        }

        static bool Falbautkozes(byte fejx, byte fejy)
        {
            if (fejx == 0 || fejx == 50 || fejy == 0 || fejy == 24)
                return true;
            return false;
        }

        static bool Magadbautkozes()
        {
            for (int i = 0; testy.Length > i; i++)
            {
                if (fejy == testy[i] && fejx == testx[i])               
                    return true;              
            }
            return false;
        }

        static bool Novekedes()
        {
            if (fejx == taplalekx && fejy == taplaleky)
            {
                kigyoTestoHossz++;
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Palyagenerallas();
            Console.SetCursorPosition(70, 1);
            Console.Write("Pontok: " + pontok);
            Kigyogenerallas();
            Taplalekgenerallas();
            do
            {
                Bemenet(sebesseg);
                Mozgas();
                Console.SetCursorPosition(70, 14);
                if (Novekedes())
                {
                    Taplalekgenerallas();
                    pontok++;
                    Console.SetCursorPosition(70, 1);
                    Console.Write("Pontok: " + pontok);
                    if (pontok % 5 == 0 && sebesseg >= 200 && sebesseg > 100)
                        sebesseg = sebesseg - 100;
                }
            } while (Falbautkozes(fejx, fejy) == false && Magadbautkozes() == false);

            Console.Clear();
            Console.WriteLine("Game over!");
            Console.ReadKey();
        }
    }
}

