using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Piškvorky
{
    class Program
    {
        struct Znacky
        {
            public sbyte barvaZnackaHrac;
            public sbyte barvaZnackaPC;
            public string znackaHrac;
            public string znackaPC;
        }


        static void vychozi()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void vstup()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        static sbyte vyberBarvy(string mod, string tah)
        {

            Console.Clear();
            string[] aktualniVyber = new string[15];
            aktualniVyber[0] = " ";
            aktualniVyber[1] = " ";
            aktualniVyber[2] = " ";
            aktualniVyber[3] = " ";
            aktualniVyber[4] = " ";
            aktualniVyber[5] = " ";
            aktualniVyber[6] = " ";
            aktualniVyber[7] = " ";
            aktualniVyber[8] = " ";
            aktualniVyber[9] = " ";
            aktualniVyber[10] = " ";
            aktualniVyber[11] = " ";
            aktualniVyber[12] = " ";
            aktualniVyber[13] = " ";
            aktualniVyber[14] = " ";
            sbyte aktualniIndex = 0;
            aktualniVyber[aktualniIndex] = "►";
            vypsaniBarev(aktualniVyber, mod, tah);
            ConsoleKeyInfo klavesaBarva = Console.ReadKey();
            while (klavesaBarva.Key != ConsoleKey.Enter)
            {
                while (klavesaBarva.Key != ConsoleKey.UpArrow & klavesaBarva.Key != ConsoleKey.DownArrow & klavesaBarva.Key != ConsoleKey.Enter)
                {

                    err();
                    Console.Write("Stisknuta špatná klávesa. Ovládat lze ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("šipkami nahoru a dolu");
                    err();
                    Console.Write(" , pro potvrzení volby stiskněte ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Enter");
                    err();
                    Console.Write(" , pro vymazání výpisu chyb a znovu vypsání nábídky stiskněte kláevsu ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Delete");
                    err();
                    Console.WriteLine(" .");
                    klavesaBarva = Console.ReadKey();
                    if (klavesaBarva.Key == ConsoleKey.Delete)
                    {
                        Console.Clear();
                        vypsaniBarev(aktualniVyber, mod, tah);
                    }

                }
                if (klavesaBarva.Key == ConsoleKey.DownArrow & aktualniIndex < 14)
                {
                    aktualniVyber[aktualniIndex] = " ";
                    aktualniIndex++;
                    aktualniVyber[aktualniIndex] = "►";
                    Console.Clear();
                    vypsaniBarev(aktualniVyber, mod, tah);
                }
                else if (klavesaBarva.Key == ConsoleKey.UpArrow & aktualniIndex > 0)
                {
                    aktualniVyber[aktualniIndex] = " ";
                    aktualniIndex--;
                    aktualniVyber[aktualniIndex] = "►";
                    Console.Clear();
                    vypsaniBarev(aktualniVyber, mod, tah);
                }
                klavesaBarva = Console.ReadKey();
            }
            aktualniIndex++;
            return aktualniIndex++;
        }
        static void vypsaniBarev(string[] aktualniVyber, string mod, string tah)
        {
            vychozi();
            if (tah == "A")
            {
                if (mod == "pocitac")
                    Console.WriteLine("Vyberte si barvu své značky");
                else if (mod == "pvp")
                    Console.WriteLine("Vyberte si barvu značky Hráče 1");
            }
            else if (tah == "B")
            {
                if (mod == "pocitac")
                    Console.WriteLine("Vyberte si barvu značky Počítače");
                else if (mod == "pvp")
                    Console.WriteLine("Vyberte si barvu značky Hráče 2");
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(aktualniVyber[0] + " Modrá - tmavá");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(aktualniVyber[1] + " Zelená - tmavá");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(aktualniVyber[2] + " Azurová - tmavá");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(aktualniVyber[3] + " Červená - tmavá");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(aktualniVyber[4] + " Purpurová - tmavá");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(aktualniVyber[5] + " Žlutá - tmavá");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(aktualniVyber[6] + " Šedá");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(aktualniVyber[7] + " Šedá - tmavá");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(aktualniVyber[8] + " Modrá");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(aktualniVyber[9] + " Zelená");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(aktualniVyber[10] + " Azurová");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(aktualniVyber[11] + " Červená");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(aktualniVyber[12] + " Purpurová");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(aktualniVyber[13] + " Žlutá");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(aktualniVyber[14] + " Bílá");


        }
        static void volba()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        static void err()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        static string rozeznaniObsahu(Znacky znacka, string[][] pole, sbyte indexA, sbyte indexB)
        {
            if (pole[indexA][indexB] == znacka.znackaHrac)
            {
                rozeznaniBarvy(znacka.barvaZnackaHrac);
                return znacka.znackaHrac;
            }
            else if (pole[indexA][indexB] == znacka.znackaPC)
            {
                rozeznaniBarvy(znacka.barvaZnackaPC);
                return znacka.znackaPC;
            }
            else
                return " ";

        }
        static void vypsaniHernihoPole(Znacky znacka, string[][] pole, string prezdivka, string prezdivka2, List<string> moznePole, string obtiznost)
        {
            vychozi();
            rozeznaniBarvy(znacka.barvaZnackaHrac);
            Console.Write(prezdivka + " " + znacka.znackaHrac);
            vychozi();
            Console.Write(" vs. ");
            rozeznaniBarvy(znacka.barvaZnackaPC);
            Console.WriteLine(prezdivka2 + " " + znacka.znackaPC);
            vychozi();
            if (obtiznost != "pvp")
            {
                Console.Write("Obtížnost: ");
                if (obtiznost == "easy")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Lehká (easy)");
                }
                else if (obtiznost == "medium")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Střední (medium)");
                }
                else if (obtiznost == "hard")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Těžká (hard)");
                }
            }
            vychozi();
            Console.Write("Počet volných polí: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(moznePole.Count);
            vychozi();
            Console.WriteLine("╔═══╦═══════════╗");
            Console.WriteLine("║   ║ 1 │ 2 │ 3 ║");
            Console.WriteLine("╠═══╬═══════════╣");
            Console.Write("║ A ║ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 0, 0));
            vychozi();
            Console.Write(" │ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 0, 1));
            vychozi();
            Console.Write(" │ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 0, 2));
            vychozi();
            Console.WriteLine(" ║");
            Console.WriteLine("║───║───┼───┼───║");
            Console.Write("║ B ║ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 1, 0));
            vychozi();
            Console.Write(" │ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 1, 1));
            vychozi();
            Console.Write(" │ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 1, 2));
            vychozi();
            Console.WriteLine(" ║");
            Console.WriteLine("║───║───┼───┼───║");
            Console.Write("║ C ║ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 2, 0));
            vychozi();
            Console.Write(" │ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 2, 1));
            vychozi();
            Console.Write(" │ ");
            Console.Write(rozeznaniObsahu(znacka, pole, 2, 2));
            vychozi();
            Console.WriteLine(" ║");
            Console.WriteLine("╚═══╩═══════════╝");

        }
        static void rozeznaniBarvy(sbyte vstupniCislo)
        {
            if (vstupniCislo == 1)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            else if (vstupniCislo == 2)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            else if (vstupniCislo == 3)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            else if (vstupniCislo == 4)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            else if (vstupniCislo == 5)
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            else if (vstupniCislo == 6)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (vstupniCislo == 7)
                Console.ForegroundColor = ConsoleColor.Gray;
            else if (vstupniCislo == 8)
                Console.ForegroundColor = ConsoleColor.DarkGray;
            else if (vstupniCislo == 9)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (vstupniCislo == 10)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (vstupniCislo == 11)
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (vstupniCislo == 12)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (vstupniCislo == 13)
                Console.ForegroundColor = ConsoleColor.Magenta;
            else if (vstupniCislo == 14)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (vstupniCislo == 15)
                Console.ForegroundColor = ConsoleColor.White;

        }
        static bool kontrolaZnacky(string znacka)
        {
            return !(znacka.Length != 1 & znacka != "kolecko" & znacka != "krizek");

        }
        static void chybaZnacka(string ciZnackaSeMaZadat)
        {
            err();
            Console.WriteLine("Chybný vstup! Délka značky neodpovídá parametrům (musí mít 1 znak nebo ");
            Console.Write("podobu ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("kolecko");
            err();
            Console.Write(" či ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("krizek");
            err();
            Console.Write(")!");
            Console.WriteLine("");
            Console.Write("Pro smazání výpisu chyb a znovu zobrazení nabídky napište příkaz ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("smazat");
            err();
            Console.WriteLine(" .");
            Console.WriteLine("");
            vychozi();
            Console.Write("Zadejte " + ciZnackaSeMaZadat + " (nebo ");
            volba();
            Console.Write("kolecko");
            vychozi();
            Console.Write(" pro ");
            vstup();
            Console.Write("°");
            vychozi();
            Console.Write(", či ");
            volba();
            Console.Write("krizek");
            vychozi();
            Console.Write(" pro ");
            vstup();
            Console.Write("×");
            vychozi();
            Console.Write(" ): ");
            vstup();
        }
        static bool kontrolaBarvy(sbyte vstupniCislo)
        {
            return (vstupniCislo >= 1 & vstupniCislo <= 15);
        }
        static bool muzePCvyhrat(string[][] pole, Znacky znacka, List<string> moznaPole)
        {
            if (pole[0][0] == pole[0][1] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("A3") == true)
                return true;
            else if (pole[0][0] == pole[0][2] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("A2") == true)
                return true;
            else if (pole[0][1] == pole[0][2] & pole[0][1] == znacka.znackaPC & moznaPole.Contains("A1") == true)
                return true;
            else if (pole[1][0] == pole[1][1] & pole[1][0] == znacka.znackaPC & moznaPole.Contains("B3") == true)
                return true;
            else if (pole[1][0] == pole[1][2] & pole[1][0] == znacka.znackaPC & moznaPole.Contains("B2") == true)
                return true;
            else if (pole[1][1] == pole[1][2] & pole[1][1] == znacka.znackaPC & moznaPole.Contains("B1") == true)
                return true;
            else if (pole[2][0] == pole[2][1] & pole[2][0] == znacka.znackaPC & moznaPole.Contains("C3") == true)
                return true;
            else if (pole[2][0] == pole[2][2] & pole[2][0] == znacka.znackaPC & moznaPole.Contains("C2") == true)
                return true;
            else if (pole[2][1] == pole[2][2] & pole[2][1] == znacka.znackaPC & moznaPole.Contains("C1") == true)
                return true;
            else if (pole[0][0] == pole[1][0] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("C1") == true)
                return true;
            else if (pole[0][0] == pole[2][0] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("B1") == true)
                return true;
            else if (pole[1][0] == pole[2][0] & pole[1][0] == znacka.znackaPC & moznaPole.Contains("A1") == true)
                return true;
            else if (pole[0][1] == pole[1][1] & pole[0][1] == znacka.znackaPC & moznaPole.Contains("C2") == true)
                return true;
            else if (pole[0][1] == pole[2][1] & pole[0][1] == znacka.znackaPC & moznaPole.Contains("B2") == true)
                return true;
            else if (pole[1][1] == pole[2][1] & pole[1][1] == znacka.znackaPC & moznaPole.Contains("A2") == true)
                return true;
            else if (pole[0][2] == pole[1][2] & pole[0][2] == znacka.znackaPC & moznaPole.Contains("C3") == true)
                return true;
            else if (pole[0][2] == pole[2][2] & pole[0][2] == znacka.znackaPC & moznaPole.Contains("B3") == true)
                return true;
            else if (pole[1][2] == pole[2][2] & pole[1][2] == znacka.znackaPC & moznaPole.Contains("A3") == true)
                return true;
            else if (pole[0][0] == pole[1][1] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("C3") == true)
                return true;
            else if (pole[0][0] == pole[2][2] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("B2") == true)
                return true;
            else if (pole[1][1] == pole[2][2] & pole[1][1] == znacka.znackaPC & moznaPole.Contains("A1") == true)
                return true;
            else if (pole[0][2] == pole[1][1] & pole[0][2] == znacka.znackaPC & moznaPole.Contains("C1") == true)
                return true;
            else if (pole[0][2] == pole[2][0] & pole[0][2] == znacka.znackaPC & moznaPole.Contains("B2") == true)
                return true;
            else if (pole[2][0] == pole[1][1] & pole[1][1] == znacka.znackaPC & moznaPole.Contains("A3") == true)
                return true;
            else
                return false;
        }
        static void umisteniZnacky(Znacky znacka, string ciZnacka, string souradnice, string[][] pole)
        {
            if (souradnice == "A1")
            {
                if (ciZnacka == "hrac")
                    pole[0][0] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[0][0] = znacka.znackaPC;
            }
            else if (souradnice == "A2")
            {
                if (ciZnacka == "hrac")
                    pole[0][1] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[0][1] = znacka.znackaPC;
            }
            else if (souradnice == "A2")
            {
                if (ciZnacka == "hrac")
                    pole[0][1] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[0][1] = znacka.znackaPC;
            }
            else if (souradnice == "A3")
            {
                if (ciZnacka == "hrac")
                    pole[0][2] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[0][2] = znacka.znackaPC;
            }
            else if (souradnice == "B1")
            {
                if (ciZnacka == "hrac")
                    pole[1][0] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[1][0] = znacka.znackaPC;
            }
            else if (souradnice == "B2")
            {
                if (ciZnacka == "hrac")
                    pole[1][1] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[1][1] = znacka.znackaPC;
            }
            else if (souradnice == "B3")
            {
                if (ciZnacka == "hrac")
                    pole[1][2] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[1][2] = znacka.znackaPC;
            }
            else if (souradnice == "C1")
            {
                if (ciZnacka == "hrac")
                    pole[2][0] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[2][0] = znacka.znackaPC;
            }
            else if (souradnice == "C2")
            {
                if (ciZnacka == "hrac")
                    pole[2][1] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[2][1] = znacka.znackaPC;
            }
            else if (souradnice == "C3")
            {
                if (ciZnacka == "hrac")
                    pole[2][2] = znacka.znackaHrac;
                else if (ciZnacka == "PC")
                    pole[2][2] = znacka.znackaPC;
            }

        }
        static string tahPC(List<string> moznaPole, string[][] pole, Znacky znacka, string obtiznost)
        {
            string souradnice = " ";
            Random rnd = new Random();
            if (muzePCvyhrat(pole, znacka, moznaPole) == false)
            {
                if (pole[0][0] == pole[0][1] & pole[0][0] == znacka.znackaHrac & moznaPole.Contains("A3") == true)
                    souradnice = "A3";
                else if (pole[0][0] == pole[0][2] & pole[0][0] == znacka.znackaHrac & moznaPole.Contains("A2") == true)
                    souradnice = "A2";
                else if (pole[0][1] == pole[0][2] & pole[0][1] == znacka.znackaHrac & moznaPole.Contains("A1") == true)
                    souradnice = "A1";
                else if (pole[1][0] == pole[1][1] & pole[1][0] == znacka.znackaHrac & moznaPole.Contains("B3") == true)
                    souradnice = "B3";
                else if (pole[1][0] == pole[1][2] & pole[1][0] == znacka.znackaHrac & moznaPole.Contains("B2") == true)
                    souradnice = "B2";
                else if (pole[1][1] == pole[1][2] & pole[1][1] == znacka.znackaHrac & moznaPole.Contains("B1") == true)
                    souradnice = "B1";
                else if (pole[2][0] == pole[2][1] & pole[2][0] == znacka.znackaHrac & moznaPole.Contains("C3") == true)
                    souradnice = "C3";
                else if (pole[2][0] == pole[2][2] & pole[2][0] == znacka.znackaHrac & moznaPole.Contains("C2") == true)
                    souradnice = "C2";
                else if (pole[2][1] == pole[2][2] & pole[2][1] == znacka.znackaHrac & moznaPole.Contains("C1") == true)
                    souradnice = "C1";
                else if (pole[0][0] == pole[1][0] & pole[0][0] == znacka.znackaHrac & moznaPole.Contains("C1") == true)
                    souradnice = "C1";
                else if (pole[0][0] == pole[2][0] & pole[0][0] == znacka.znackaHrac & moznaPole.Contains("B1") == true)
                    souradnice = "B1";
                else if (pole[1][0] == pole[2][0] & pole[1][0] == znacka.znackaHrac & moznaPole.Contains("A1") == true)
                    souradnice = "A1";
                else if (pole[0][1] == pole[1][1] & pole[0][1] == znacka.znackaHrac & moznaPole.Contains("C2") == true)
                    souradnice = "C2";
                else if (pole[0][1] == pole[2][1] & pole[0][1] == znacka.znackaHrac & moznaPole.Contains("B2") == true)
                    souradnice = "B2";
                else if (pole[1][1] == pole[2][1] & pole[1][1] == znacka.znackaHrac & moznaPole.Contains("A2") == true)
                    souradnice = "A2";
                else if (pole[0][2] == pole[1][2] & pole[0][2] == znacka.znackaHrac & moznaPole.Contains("C3") == true)
                    souradnice = "C3";
                else if (pole[0][2] == pole[2][2] & pole[0][2] == znacka.znackaHrac & moznaPole.Contains("B3") == true)
                    souradnice = "B3";
                else if (pole[1][2] == pole[2][2] & pole[1][2] == znacka.znackaHrac & moznaPole.Contains("A3") == true)
                    souradnice = "A3";
                else if (pole[0][0] == pole[1][1] & pole[0][0] == znacka.znackaHrac & moznaPole.Contains("C3") == true)
                    souradnice = "C3";
                else if (pole[0][0] == pole[2][2] & pole[0][0] == znacka.znackaHrac & moznaPole.Contains("B2") == true)
                    souradnice = "B2";
                else if (pole[1][1] == pole[2][2] & pole[1][1] == znacka.znackaHrac & moznaPole.Contains("A1") == true)
                    souradnice = "A1";
                else if (pole[0][2] == pole[1][1] & pole[0][2] == znacka.znackaHrac & moznaPole.Contains("C1") == true)
                    souradnice = "C1";
                else if (pole[0][2] == pole[2][0] & pole[0][2] == znacka.znackaHrac & moznaPole.Contains("B2") == true)
                    souradnice = "B2";
                else if (pole[2][0] == pole[1][1] & pole[1][1] == znacka.znackaHrac & moznaPole.Contains("A3") == true)
                    souradnice = "A3";
                else if (pole[1][1] == pole[2][2] & pole[2][2] == znacka.znackaHrac & moznaPole.Contains("A3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A3";
                else if (pole[1][1] == pole[2][0] & pole[2][0] == znacka.znackaHrac & moznaPole.Contains("A1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A1";
                else if (pole[1][1] == pole[0][0] & pole[0][0] == znacka.znackaHrac & moznaPole.Contains("C1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C1";
                else if (pole[1][1] == pole[0][2] & pole[0][2] == znacka.znackaHrac & moznaPole.Contains("C3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C3";
                else if (pole[1][1] == pole[2][0] & pole[2][0] == znacka.znackaHrac & moznaPole.Contains("A2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A2";
                else if (pole[1][1] == pole[2][2] & pole[2][2] == znacka.znackaHrac & moznaPole.Contains("A2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A2";
                else if (pole[1][1] == pole[0][0] & pole[0][0] == znacka.znackaHrac & moznaPole.Contains("C2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A2";
                else if (pole[1][1] == pole[0][2] & pole[0][2] == znacka.znackaHrac & moznaPole.Contains("C2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A2";
                else if (pole[2][0] == pole[0][1] & pole[0][1] == znacka.znackaHrac & moznaPole.Contains("A1") & obtiznost == "hard")
                    souradnice = "A1";
                else if (pole[0][0] == pole[1][2] & pole[1][2] == znacka.znackaHrac & moznaPole.Contains("A3") & obtiznost == "hard")
                    souradnice = "A3";
                else if (pole[0][2] == pole[2][1] & pole[2][1] == znacka.znackaHrac & moznaPole.Contains("C3") & obtiznost == "hard")
                    souradnice = "C3";
                else if (pole[2][2] == pole[1][0] & pole[1][0] == znacka.znackaHrac & moznaPole.Contains("C1") & obtiznost == "hard")
                    souradnice = "C1";
                else if (moznaPole.Contains("B2") == false & moznaPole.Contains("A1") == false & moznaPole.Contains("A2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A2";
                else if (moznaPole.Contains("B2") == false & moznaPole.Contains("A3") == false & moznaPole.Contains("A2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A2";
                else if (moznaPole.Contains("B2") == false & moznaPole.Contains("C1") == false & moznaPole.Contains("C2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C2";
                else if (moznaPole.Contains("B2") == false & moznaPole.Contains("C3") == false & moznaPole.Contains("C2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C2";
                else if (moznaPole.Contains("C1") == false & moznaPole.Contains("A2") == false & moznaPole.Contains("B1") == true & obtiznost == "hard")
                    souradnice = "B1";
                else if (moznaPole.Contains("C3") == false & moznaPole.Contains("A2") == false & moznaPole.Contains("B3") == true & obtiznost == "hard")
                    souradnice = "B3";
                else if (moznaPole.Contains("C1") == false & moznaPole.Contains("B3") == false & moznaPole.Contains("C2") == true & obtiznost == "hard")
                    souradnice = "C2";
                else if (moznaPole.Contains("A1") == false & moznaPole.Contains("B3") == false & moznaPole.Contains("A2") == true & obtiznost == "hard")
                    souradnice = "A2";
                else if (moznaPole.Contains("A1") == false & moznaPole.Contains("C2") == false & moznaPole.Contains("B1") == true & obtiznost == "hard")
                    souradnice = "B1";
                else if (moznaPole.Contains("A3") == false & moznaPole.Contains("C2") == false & moznaPole.Contains("B3") == true & obtiznost == "hard")
                    souradnice = "B3";
                else if (moznaPole.Contains("A3") == false & moznaPole.Contains("B1") == false & moznaPole.Contains("A2") == true & obtiznost == "hard")
                    souradnice = "A2";
                else if (moznaPole.Contains("C3") == false & moznaPole.Contains("B1") == false & moznaPole.Contains("C2") == true & obtiznost == "hard")
                    souradnice = "C2";
                else if (moznaPole.Contains("B2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B2";
                else if (moznaPole.Contains("A1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A1";
                else if (moznaPole.Contains("A3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A3";
                else if (moznaPole.Contains("C1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C1";
                else if (moznaPole.Contains("C3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C3";
                else if (moznaPole.Contains("A2") == true & obtiznost == "easy")
                    souradnice = "A2";
                else if (moznaPole.Contains("B1") == true & obtiznost == "easy")
                    souradnice = "B1";
                else if (moznaPole.Contains("B3") == true & obtiznost == "easy")
                    souradnice = "B3";
                else if (moznaPole.Contains("C2") == true & obtiznost == "easy")
                    souradnice = "C2";
                else
                    souradnice = moznaPole[rnd.Next(moznaPole.Count)];
            }
            else
            {
                if (pole[0][0] == pole[0][1] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("A3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A3";
                else if (pole[0][0] == pole[0][2] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("A2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A2";
                else if (pole[0][1] == pole[0][2] & pole[0][1] == znacka.znackaPC & moznaPole.Contains("A1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A1";
                else if (pole[1][0] == pole[1][1] & pole[1][0] == znacka.znackaPC & moznaPole.Contains("B3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B3";
                else if (pole[1][0] == pole[1][2] & pole[1][0] == znacka.znackaPC & moznaPole.Contains("B2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B2";
                else if (pole[1][1] == pole[1][2] & pole[1][1] == znacka.znackaPC & moznaPole.Contains("B1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B1";
                else if (pole[2][0] == pole[2][1] & pole[2][0] == znacka.znackaPC & moznaPole.Contains("C3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C3";
                else if (pole[2][0] == pole[2][2] & pole[2][0] == znacka.znackaPC & moznaPole.Contains("C2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C2";
                else if (pole[2][1] == pole[2][2] & pole[2][1] == znacka.znackaPC & moznaPole.Contains("C1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C1";
                else if (pole[0][0] == pole[1][0] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("C1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C1";
                else if (pole[0][0] == pole[2][0] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("B1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B1";
                else if (pole[1][0] == pole[2][0] & pole[1][0] == znacka.znackaPC & moznaPole.Contains("A1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A1";
                else if (pole[0][1] == pole[1][1] & pole[0][1] == znacka.znackaPC & moznaPole.Contains("C2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C2";
                else if (pole[0][1] == pole[2][1] & pole[0][1] == znacka.znackaPC & moznaPole.Contains("B2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B2";
                else if (pole[1][1] == pole[2][1] & pole[1][1] == znacka.znackaPC & moznaPole.Contains("A2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A2";
                else if (pole[0][2] == pole[1][2] & pole[0][2] == znacka.znackaPC & moznaPole.Contains("C3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C3";
                else if (pole[0][2] == pole[2][2] & pole[0][2] == znacka.znackaPC & moznaPole.Contains("B3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B3";
                else if (pole[1][2] == pole[2][2] & pole[1][2] == znacka.znackaPC & moznaPole.Contains("A3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A3";
                else if (pole[0][0] == pole[1][1] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("C3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C3";
                else if (pole[0][0] == pole[2][2] & pole[0][0] == znacka.znackaPC & moznaPole.Contains("B2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B2";
                else if (pole[1][1] == pole[2][2] & pole[1][1] == znacka.znackaPC & moznaPole.Contains("A1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A1";
                else if (pole[0][2] == pole[1][1] & pole[0][2] == znacka.znackaPC & moznaPole.Contains("C1") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "C1";
                else if (pole[0][2] == pole[2][0] & pole[0][2] == znacka.znackaPC & moznaPole.Contains("B2") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "B2";
                else if (pole[2][0] == pole[1][1] & pole[1][1] == znacka.znackaPC & moznaPole.Contains("A3") == true & platiMedIHard(obtiznost) == true)
                    souradnice = "A3";
            }

            return souradnice;

        }
        static string vitez(string[][] pole, Znacky znacky)
        {
            if (pole[0][0] == pole[0][1] & pole[0][1] == pole[0][2])
            {
                if (pole[0][0] == znacky.znackaHrac)
                    return "hrac";
                else if (pole[0][0] == znacky.znackaPC)
                    return "PC";
            }
            else if (pole[1][0] == pole[1][1] & pole[1][1] == pole[1][2])
            {
                if (pole[1][0] == znacky.znackaHrac)
                    return "hrac";
                else if (pole[1][0] == znacky.znackaPC)
                    return "PC";
            }
            else if (pole[2][0] == pole[2][1] & pole[2][1] == pole[2][2])
            {
                if (pole[2][0] == znacky.znackaHrac)
                    return "hrac";
                else if (pole[2][0] == znacky.znackaPC)
                    return "PC";
            }
            else if (pole[0][0] == pole[1][0] & pole[1][0] == pole[2][0])
            {
                if (pole[0][0] == znacky.znackaHrac)
                    return "hrac";
                else if (pole[0][0] == znacky.znackaPC)
                    return "PC";
            }
            else if (pole[0][1] == pole[1][1] & pole[1][1] == pole[2][1])
            {
                if (pole[0][1] == znacky.znackaHrac)
                    return "hrac";
                else if (pole[0][1] == znacky.znackaPC)
                    return "PC";
            }
            else if (pole[0][2] == pole[1][2] & pole[1][2] == pole[2][2])
            {
                if (pole[0][2] == znacky.znackaHrac)
                    return "hrac";
                else if (pole[0][2] == znacky.znackaPC)
                    return "PC";
            }
            else if (pole[0][0] == pole[1][1] & pole[1][1] == pole[2][2])
            {
                if (pole[0][0] == znacky.znackaHrac)
                    return "hrac";
                else if (pole[0][0] == znacky.znackaPC)
                    return "PC";
            }
            else if (pole[0][2] == pole[1][1] & pole[1][1] == pole[2][0])
            {
                if (pole[0][2] == znacky.znackaHrac)
                    return "hrac";
                else if (pole[0][2] == znacky.znackaPC)
                    return "PC";
            }
            return "nikdo";
        }
        static void vyhraPC(Znacky znacky, string prezdivka)
        {
            Console.Clear();
            char uvozovky = (char)34;
            vychozi();
            Console.WriteLine("");
            Console.WriteLine(" __, __,  _, _,_ __,  _, _,      _,    __,  _, ___ __,  ");
            Console.WriteLine(" |_) |_) / \\ |_| |_) /_\\ |    / /_\\   , |  (_   |  |_    ");
            Console.WriteLine(" |   | \\ \\ / | | | \\ | | | , /  | |   ( |  , )  |  |  ,,,");
            Console.WriteLine(" ~   ~ ~  ~  ~ ~ ~ ~ ~ ~ ~~~    ~ ~    ~~   ~   ~  ~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                 ,____");
            Console.WriteLine("                 |---.\\");
            Console.WriteLine("        ___      |    `");
            Console.WriteLine("       / .-\\  ./=)");
            Console.WriteLine("       | |" + uvozovky + "|_/\\/|                 /|  ________________");
            Console.Write("       ;  |-;| /_|            ");
            rozeznaniBarvy(znacky.barvaZnackaPC);
            Console.Write(znacky.znackaPC);
            vychozi();
            Console.WriteLine("|===|*>________________>");
            Console.Write("      / \\_| |/ \\ |                \\|");
            rozeznaniBarvy(znacky.barvaZnackaPC);
            Console.WriteLine("     Počítač");
            vychozi();
            Console.WriteLine("     /      \\/\\( |");
            Console.WriteLine("     |   /  |` ) |");
            Console.Write("     /   \\ _/    |                     ");
            rozeznaniBarvy(znacky.barvaZnackaHrac);
            Console.WriteLine(znacky.znackaHrac);
            vychozi();
            Console.WriteLine("    /--._/  \\    |        .-" + uvozovky + uvozovky + "-.     .-" + uvozovky + "-. ");
            Console.WriteLine("    `/|)    |    /       / _  _ \\   / RIP \\");
            Console.WriteLine("      /     |   |        |(_)(_)|   |     |");
            Console.WriteLine("    .'      |   |        (_ /\\ _)  \\\\     |//");
            Console.WriteLine("  /         \\  |          L====J    ` " + uvozovky + " " + uvozovky + uvozovky + " " + uvozovky);
            Console.Write("  (_.-.__.__./  /         '-..-'");
            rozeznaniBarvy(znacky.barvaZnackaHrac);
            Console.WriteLine("   " + prezdivka);
            Thread.Sleep(9111);
        }
        static void vyhraHrac(Znacky znacky, string prezdivka)
        {
            volba();
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" _   ___   ___   _______  ___  _         _____      ___ _____ _____ _____ _ ");
            Console.WriteLine("| | | \\ \\ / | | | | ___ \\/ _ \\| |       / / _ \\    |_  /  ___|_   _|  ___| |");
            Console.WriteLine("| | | |\\ V /| |_| | |_/ / /_\\ | |      / / /_\\ \\     | \\ `--.  | | | |__ | |");
            Console.WriteLine("| | | | \\ / |  _  |    /|  _  | |     / /|  _  |     | |`--. \\ | | |  __|| |");
            Console.WriteLine("\\ \\_/ / | | | | | | |\\ \\| | | | |____/ / | | | | /\\__/ /\\__/ / | | | |___|_|");
            Console.WriteLine(" \\___/  \\_/ \\_| |_\\_| \\_\\\\_| |_\\_____/_/ \\_| |_/ \\____/\\____/  \\_/ \\____/(_)");
            rozeznaniBarvy(znacky.barvaZnackaHrac);
            Console.WriteLine("");
            Console.WriteLine("                                     " + znacky.znackaHrac);
            volba();
            Console.WriteLine("                                  o^/|\\^o");
            Console.WriteLine("                               o_^|\\/*\\/|^_o");
            Console.WriteLine("                              o\\*`'.\\|/.'`*/o");
            Console.WriteLine("                               \\\\\\\\\\\\|//////");
            Console.WriteLine("                                {><><@><><}");
            rozeznaniBarvy(znacky.barvaZnackaHrac);
            Console.WriteLine("                              " + prezdivka);
            Thread.Sleep(9111);

        }
        static void vyhraHrac1(string prezdivkaH1, string prezdivkaH2, Znacky znacka)
        {
            char uvozovky = (char)34;
            rozeznaniBarvy(znacka.barvaZnackaHrac);
            Console.Clear();
            Console.WriteLine("                " + znacka.znackaHrac);
            volba();
            Console.WriteLine("             o^/|\\^o ");
            Console.WriteLine("          o_^|\\/*\\/|^_o ");
            Console.WriteLine("         o\\*`'.\\|/.'`*/o ");
            Console.WriteLine("           \\\\\\\\\\|///// ");
            Console.WriteLine("           {><><@><><} ");
            Console.WriteLine("           `" + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + "` ");
            rozeznaniBarvy(znacka.barvaZnackaHrac);
            Console.WriteLine("           " + prezdivkaH1);
            vychozi();
            Console.WriteLine("                      ______");
            Console.WriteLine("                   .-" + uvozovky + "      " + uvozovky + "-.");
            Console.WriteLine("                  /            \\");
            Console.WriteLine("                 |              |");
            Console.WriteLine("                 |,  .-.  .-.  ,|");
            Console.WriteLine("                 | )(__/  \\__)( |");
            Console.WriteLine("                 |/     /\\     \\|");
            Console.WriteLine("       (@_       (_     ^^     _)");
            Console.WriteLine("  _     ) \\_______\\__|IIIIII|__/__________________________");
            Console.WriteLine(" (_)@8@8{}<________|-\\IIIIII/-|___________________________>");
            Console.WriteLine("        )_/        \\          /");
            Console.WriteLine("       (@           `--------` ");
            rozeznaniBarvy(znacka.barvaZnackaPC);
            Console.WriteLine("                    " + prezdivkaH2);
            Console.WriteLine("");
            Thread.Sleep(9111);
            vychozi();
        }
        static void vyhraHrac2(string prezdivkaH1, string prezdivkaH2, Znacky znacka)
        {
            char uvozovky = (char)34;
            rozeznaniBarvy(znacka.barvaZnackaPC);
            Console.Clear();
            Console.WriteLine("                " + znacka.znackaPC);
            volba();
            Console.WriteLine("             o^/|\\^o ");
            Console.WriteLine("          o_^|\\/*\\/|^_o ");
            Console.WriteLine("         o\\*`'.\\|/.'`*/o ");
            Console.WriteLine("           \\\\\\\\\\|///// ");
            Console.WriteLine("           {><><@><><} ");
            Console.WriteLine("           `" + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + uvozovky + "` ");
            rozeznaniBarvy(znacka.barvaZnackaPC);
            Console.WriteLine("           " + prezdivkaH2);
            vychozi();
            Console.WriteLine("                      ______");
            Console.WriteLine("                   .-" + uvozovky + "      " + uvozovky + "-.");
            Console.WriteLine("                  /            \\");
            Console.WriteLine("                 |              |");
            Console.WriteLine("                 |,  .-.  .-.  ,|");
            Console.WriteLine("                 | )(__/  \\__)( |");
            Console.WriteLine("                 |/     /\\     \\|");
            Console.WriteLine("       (@_       (_     ^^     _)");
            Console.WriteLine("  _     ) \\_______\\__|IIIIII|__/__________________________");
            Console.WriteLine(" (_)@8@8{}<________|-\\IIIIII/-|___________________________>");
            Console.WriteLine("        )_/        \\          /");
            Console.WriteLine("       (@           `--------` ");
            rozeznaniBarvy(znacka.barvaZnackaHrac);
            Console.WriteLine("                    " + prezdivkaH1);
            Console.WriteLine("");
            vychozi();
        }
        static void remiza()
        {
            vstup();
            Console.Clear();
            Console.WriteLine("        ");
            Console.WriteLine("         _______  _______  _______ _________ _______  _______ ");
            Console.WriteLine("        (  ____ )(  ____ \\(       )\\__   __// ___   )(  ___  )");
            Console.WriteLine("        | (    )|| (    \\/| () () |   ) (   \\/   )  || (   ) |");
            Console.WriteLine("        | (____)|| (__    | || || |   | |       /   )| (___) |");
            Console.WriteLine("        |     __)|  __)   | |(_)| |   | |      /   / |  ___  |");
            Console.WriteLine("        | (\\ (   | (      | |   | |   | |     /   /  | (   ) |");
            Console.WriteLine("        | ) \\ \\__| (____/\\| )   ( |___) (___ /   (_/\\| )   ( |");
            Console.WriteLine("        |/   \\__/(_______/|/     \\|\\_______/(_______/|/     \\|");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(9111);
        }
        static void uvodniMenu()
        {
            Console.WindowHeight = 24;
            Console.WindowWidth = 80;
            vychozi();
            Console.WriteLine("                            P I Š K V O R K Y");
            Console.WriteLine("");
            Console.WriteLine("     ____________________________      ");
            Console.WriteLine("    │\\_________________________/│\\     /\\                    /\\");
            Console.WriteLine("    ││                         ││ \\    \\ \\                  / /");
            Console.WriteLine("    ││                         ││  \\    \\ \\                / /");
            Console.WriteLine("    ││                         ││  │     \\.\\              /./");
            Console.WriteLine("    ││                         ││  │      \\.\\            /./");
            Console.WriteLine("    ││                         ││  │       \\.\\          /./");
            Console.WriteLine("    ││                         ││  │        \\\\\\        ///");
            Console.WriteLine("    ││                         ││  /         \\.\\      /./");
            Console.WriteLine("    ││_________________________││ /           \\.\\    /./");
            Console.WriteLine("    │/_________________________\\│/             \\.\\__/./");
            Console.WriteLine("       __\\_________________/__/│              _/)))(((\\_");
            Console.WriteLine("      │_______________________│/              _|)/##\\(|_");
            Console.WriteLine("    ________________________                  \\|)))(((|/");
            Console.WriteLine("   /oooo  oooo  oooo  oooo /│                  /o/  \\o\\");
            Console.WriteLine("  /ooooooooooooooooooooooo/ /                 /o/    \\o\\");
            Console.WriteLine(" /ooooooooooooooooooooooo/ /                 /_/      \\_\\");
            Console.WriteLine("/C=_____________________/_/            ");
            vstup();
            Console.WriteLine("      hrát proti počitači                  hrát ve 2 lidech");
            volba();
            Console.WriteLine("            Enter                              Mezerník");
        }

        static string vyberModu()
        {
            Console.Clear();
            protiPocitaci();
            sbyte hodnotaModu = 0;
            ConsoleKeyInfo klavesaMod = Console.ReadKey();
            while (klavesaMod.Key != ConsoleKey.Enter)
            {
                while (klavesaMod.Key != ConsoleKey.LeftArrow & klavesaMod.Key != ConsoleKey.RightArrow & klavesaMod.Key != ConsoleKey.Enter)
                {

                    err();
                    Console.Write("Stisknuta špatná klávesa. Ovládat lze ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("šipkami vlevo a vpravo");
                    err();
                    Console.Write(" , pro potvrzení volby stiskněte ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Enter");
                    err();
                    Console.Write(" , pro vymazání výpisu chyb a znovu vypsání nábídky stiskněte kláevsu ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Delete");
                    err();
                    Console.WriteLine(" .");
                    klavesaMod = Console.ReadKey();
                    if (klavesaMod.Key == ConsoleKey.Delete)
                    {
                        Console.Clear();
                        if (hodnotaModu == 0)
                            protiPocitaci();
                        else if (hodnotaModu == 1)
                            protiHraci();
                    }

                }
                if (klavesaMod.Key == ConsoleKey.RightArrow & hodnotaModu == 0)
                    hodnotaModu++;
                else if (klavesaMod.Key == ConsoleKey.LeftArrow & hodnotaModu == 1)
                    hodnotaModu--;

                Console.Clear();

                if (hodnotaModu == 0)
                    protiPocitaci();
                else if (hodnotaModu == 1)
                    protiHraci();

                klavesaMod = Console.ReadKey();
            }
            if (hodnotaModu == 0)
                return "pocitac";
            else
                return "pvp";
        }


        static void protiPocitaci()
        {
            Console.WindowHeight = 24;
            Console.WindowWidth = 80;
            vstup();
            Console.WriteLine("                            P I Š K V O R K Y");
            volba();
            Console.WriteLine("");
            Console.Write("      ____________________________      ");
            vychozi();
            Console.WriteLine("");
            volba();
            Console.Write("     │\\_________________________/│\\       ");
            vychozi();
            Console.WriteLine("/\\                    /\\ ");
            volba();
            Console.Write("     ││                         ││ \\      ");
            vychozi();
            Console.WriteLine("\\ \\                  / /");
            volba();
            Console.Write("     ││                         ││  \\      ");
            vychozi();
            Console.WriteLine("\\ \\                / /  ");
            volba();
            Console.Write("     ││                         ││  │       ");
            vychozi();
            Console.WriteLine("\\.\\              /./   ");
            volba();
            Console.Write("     ││                         ││  │        ");
            vychozi();
            Console.WriteLine("\\.\\            /./");
            volba();
            Console.Write("     ││                         ││  │         ");
            vychozi();
            Console.WriteLine("\\.\\          /./");
            volba();
            Console.Write("     ││                         ││  │          ");
            vychozi();
            Console.WriteLine("\\\\\\        ///");
            volba();
            Console.Write("     ││                         ││  /           ");
            vychozi();
            Console.WriteLine("\\.\\      /./");
            volba();
            Console.Write("     ││_________________________││ /             ");
            vychozi();
            Console.WriteLine("\\.\\    /./");
            volba();
            Console.Write("     │/_________________________\\│/               ");
            vychozi();
            Console.WriteLine("\\.\\__/./");
            volba();
            Console.Write("        __\\_________________/__/│                ");
            vychozi();
            Console.WriteLine("_/)))(((\\_");
            volba();
            Console.Write("       │_______________________│/                ");
            vychozi();
            Console.WriteLine("_|)/##\\(|_ ");
            volba();
            Console.Write("     ________________________                    ");
            vychozi();
            Console.WriteLine("\\|)))(((|/");
            volba();
            Console.Write("    /oooo  oooo  oooo  oooo /│                    ");
            vychozi();
            Console.WriteLine("/o/  \\o\\");
            volba();
            Console.Write("   /ooooooooooooooooooooooo/ /                   ");
            vychozi();
            Console.WriteLine("/o/    \\o\\");
            volba();
            Console.Write("  /ooooooooooooooooooooooo/ /                   ");
            vychozi();
            Console.WriteLine("/_/      \\_\\");
            volba();
            Console.Write(" /C=_____________________/_/");
            vychozi();
            Console.WriteLine("");
            volba();
            Console.Write("");
            vychozi();
            Console.WriteLine("");
            volba();
            Console.Write("      hrát proti počitači                     ");
            vychozi();
            Console.WriteLine("hrát ve 2 lidech");
            vychozi();
        }
        static void protiHraci()
        {
            Console.WindowHeight = 24;
            Console.WindowWidth = 80;
            vstup();
            Console.WriteLine("                            P I Š K V O R K Y");
            Console.WriteLine("");
            vychozi();
            Console.Write("      ____________________________      ");
            volba();
            Console.WriteLine("");
            vychozi();
            Console.Write("     │\\_________________________/│\\       ");
            volba();
            Console.WriteLine("/\\                    /\\ ");
            vychozi();
            Console.Write("     ││                         ││ \\      ");
            volba();
            Console.WriteLine("\\ \\                  / /");
            vychozi();
            Console.Write("     ││                         ││  \\      ");
            volba();
            Console.WriteLine("\\ \\                / /  ");
            vychozi();
            Console.Write("     ││                         ││  │       ");
            volba();
            Console.WriteLine("\\.\\              /./   ");
            vychozi();
            Console.Write("     ││                         ││  │        ");
            volba();
            Console.WriteLine("\\.\\            /./");
            vychozi();
            Console.Write("     ││                         ││  │         ");
            volba();
            Console.WriteLine("\\.\\          /./");
            vychozi();
            Console.Write("     ││                         ││  │          ");
            volba();
            Console.WriteLine("\\\\\\        ///");
            vychozi();
            Console.Write("     ││                         ││  /           ");
            volba();
            Console.WriteLine("\\.\\      /./");
            vychozi();
            Console.Write("     ││_________________________││ /             ");
            volba();
            Console.WriteLine("\\.\\    /./");
            vychozi();
            Console.Write("     │/_________________________\\│/               ");
            volba();
            Console.WriteLine("\\.\\__/./");
            vychozi();
            Console.Write("        __\\_________________/__/│                ");
            volba();
            Console.WriteLine("_/)))(((\\_");
            vychozi();
            Console.Write("       │_______________________│/                ");
            volba();
            Console.WriteLine("_|)/##\\(|_ ");
            vychozi();
            Console.Write("     ________________________                    ");
            volba();
            Console.WriteLine("\\|)))(((|/");
            vychozi();
            Console.Write("    /oooo  oooo  oooo  oooo /│                    ");
            volba();
            Console.WriteLine("/o/  \\o\\");
            vychozi();
            Console.Write("   /ooooooooooooooooooooooo/ /                   ");
            volba();
            Console.WriteLine("/o/    \\o\\");
            vychozi();
            Console.Write("  /ooooooooooooooooooooooo/ /                   ");
            volba();
            Console.WriteLine("/_/      \\_\\");
            vychozi();
            Console.Write(" /C=_____________________/_/");
            volba();
            Console.WriteLine("");
            vychozi();
            Console.Write("");
            volba();
            Console.WriteLine("");
            vychozi();
            Console.Write("      hrát proti počitači                     ");
            volba();
            Console.WriteLine("hrát ve 2 lidech");
            vychozi();
        }


        static void obtiznostEasy()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            volba();
            Console.Write("╔═══════════════════╗");
            vychozi();
            Console.WriteLine("");
            volba();
            Console.Write("║  ___              ║");
            vychozi();
            Console.WriteLine("  __  __        _ _               _  _   _   ___ ___  ");
            volba();
            Console.Write("║ | __|__ _ ____  _ ║");
            vychozi();
            Console.WriteLine(" |  \\/  |___ __| (_)_  _ _ __    | || | /_\\ | _ \\   \\  ");
            volba();
            Console.Write("║ | _|/ _` (_-< || |║");
            vychozi();
            Console.WriteLine(" | |\\/| / -_) _` | | || | '  \\   | __ |/ _ \\|   / |) | ");
            volba();
            Console.Write("║ |___\\__,_/__/\\_, |║");
            vychozi();
            Console.WriteLine(" |_|  |_\\___\\__,_|_|\\_,_|_|_|_|  |_||_/_/ \\_\\_|_\\___/  ");
            volba();
            Console.Write("║  Jednoduchá  |__/ ║");
            vychozi();
            Console.WriteLine("             Střední                      Těžká        ");
            volba();
            Console.WriteLine("╚═══════════════════╝");
            vychozi();
            volba();
            Console.WriteLine("");
            Console.WriteLine("                              Vyberte obtížnost");
            vychozi();
        }
        static void obtiznostMedium()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            volba();
            Console.Write("                     ╔══════════════════════════════╗");
            vychozi();
            Console.WriteLine("");
            Console.Write("   ___               ");
            volba();
            Console.Write("║ __  __        _ _            ║");
            vychozi();
            Console.WriteLine("  _  _   _   ___ ___   ");
            Console.Write("  | __|__ _ ____  _  ");
            volba();
            Console.Write("║|  \\/  |___ __| (_)_  _ _ __  ║");
            vychozi();
            Console.WriteLine(" | || | /_\\ | _ \\   \\  ");
            Console.Write("  | _|/ _` (_-< || | ");
            volba();
            Console.Write("║| |\\/| / -_) _` | | || | '  \\ ║");
            vychozi();
            Console.WriteLine(" | __ |/ _ \\|   / |) | ");
            Console.Write("  |___\\__,_/__/\\_, | ");
            volba();
            Console.Write("║|_|  |_\\___\\__,_|_|\\_,_|_|_|_|║");
            vychozi();
            Console.WriteLine(" |_||_/_/ \\_\\_|_\\___/  ");
            Console.Write("   Jednoduchá  |__/  ");
            volba();
            Console.Write("║            Střední           ║");
            vychozi();
            Console.WriteLine("          Těžká        ");
            Console.Write("                     ");
            volba();
            Console.Write("╚══════════════════════════════╝");
            Console.WriteLine();
            volba();
            Console.WriteLine("");
            Console.WriteLine("                              Vyberte obtížnost");
            vychozi();
        }
        static void obtiznostHard()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            vychozi();
            Console.Write("                                                     ");
            volba();
            Console.WriteLine("╔═════════════════════╗");
            vychozi();
            Console.Write("   ___                 __  __        _ _             ");
            volba();
            Console.WriteLine("║ _  _   _   ___ ___  ║");
            vychozi();
            Console.Write("  | __|__ _ ____  _   |  \\/  |___ __| (_)_  _ _ __   ");
            volba();
            Console.WriteLine("║| || | /_\\ | _ \\   \\ ║");
            vychozi();
            Console.Write("  | _|/ _` (_-< || |  | |\\/| / -_) _` | | || | '  \\  ");
            volba();
            Console.WriteLine("║| __ |/ _ \\|   / |) |║");
            vychozi();
            Console.Write("  |___\\__,_/__/\\_, |  |_|  |_\\___\\__,_|_|\\_,_|_|_|_| ");
            volba();
            Console.WriteLine("║|_||_/_/ \\_\\_|_\\___/ ║");
            vychozi();
            Console.Write("   Jednoduchá  |__/               Střední            ");
            volba();
            Console.WriteLine("║         Těžká       ║");
            vychozi();
            Console.Write("                                                     ");
            volba();
            Console.WriteLine("╚═════════════════════╝");
            vychozi();
            volba();
            Console.WriteLine("");
            Console.WriteLine("                              Vyberte obtížnost");
            vychozi();
        }
        static void vypsaniObtiznosti(sbyte index, string[] poleObtiznosti)
        {
            if (poleObtiznosti[index] == "easy")
                obtiznostEasy();
            else if (poleObtiznosti[index] == "medium")
                obtiznostMedium();
            else if (poleObtiznosti[index] == "hard")
                obtiznostHard();
        }
        static string obtiznost()
        {
            obtiznostEasy();
            string[] poleObtiznosti = new string[3];
            poleObtiznosti[0] = "easy";
            poleObtiznosti[1] = "medium";
            poleObtiznosti[2] = "hard";
            sbyte indexObtiznosti = 0;

            ConsoleKeyInfo vybraniObtiznosti = Console.ReadKey();
            while (vybraniObtiznosti.Key != ConsoleKey.Enter)
            {
                while (vybraniObtiznosti.Key != ConsoleKey.LeftArrow & vybraniObtiznosti.Key != ConsoleKey.RightArrow & vybraniObtiznosti.Key != ConsoleKey.Enter)
                {

                    err();
                    Console.Write("Stisknuta špatná klávesa. Ovládat lze ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("šipkami vlevo a vpravo");
                    err();
                    Console.Write(" , pro potvrzení volby stiskněte ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Enter");
                    err();
                    Console.Write(" , pro vymazání výpisu chyb a znovu vypsání nábídky stiskněte kláevsu ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Delete");
                    err();
                    Console.WriteLine(" .");
                    vybraniObtiznosti = Console.ReadKey();
                    if (vybraniObtiznosti.Key == ConsoleKey.Delete)
                    {
                        Console.Clear();
                        vypsaniObtiznosti(indexObtiznosti, poleObtiznosti);
                    }

                }
                if (vybraniObtiznosti.Key == ConsoleKey.RightArrow & indexObtiznosti < 2)
                    indexObtiznosti++;
                else if (vybraniObtiznosti.Key == ConsoleKey.LeftArrow & indexObtiznosti > 0)
                    indexObtiznosti--;
                vypsaniObtiznosti(indexObtiznosti, poleObtiznosti);
                vybraniObtiznosti = Console.ReadKey();
            }
            return poleObtiznosti[indexObtiznosti];

        }
        static bool platiMedIHard(string obtiznost)
        {
            if (obtiznost == "medium" | obtiznost == "hard")
                if (obtiznost != "easy")
                    return true;
                else
                    return false;
            else
                return false;
        }

        static void Main(string[] args)
        {

            bool dalsiHra = false;
            Random rnd = new Random();
            Console.Title = "Piškvorky © Jiří Škoda 2014";

        start:
            Console.Clear();
            uvodniMenu();
            string mod = vyberModu();
            string tezkost = " ";
            if (mod == "pocitac")
                tezkost = obtiznost();
            else if (mod == "pvp")
                tezkost = "pvp";
            Console.Clear();
            vychozi();
            if (mod == "pocitac")
                Console.Write("Zadejte svoji přezdívku: ");
            else if (mod == "pvp")
                Console.Write("Zadejte přezdívku Hráče 1: ");
            vstup();
            string prezdivka = Console.ReadLine();
            vychozi();
            Console.WriteLine("");
            if (mod == "pocitac")
                Console.Write("Zadejte svou značku (nebo ");
            else if (mod == "pvp")
                Console.Write("Zadejte značku Hráče 1 (nebo ");
            volba();
            Console.Write("kolecko");
            vychozi();
            Console.Write(" pro ");
            vstup();
            Console.Write("o");
            vychozi();
            Console.Write(", či ");
            volba();
            Console.Write("krizek");
            vychozi();
            Console.Write(" pro ");
            vstup();
            Console.Write("×");
            vychozi();
            Console.Write(" ): ");
            vstup();
            string znakHrace = Console.ReadLine();
            while (kontrolaZnacky(znakHrace) == false)
            {
                if (znakHrace == "smazat")
                    Console.Clear();
                if (mod == "pvp")
                    chybaZnacka("značku Hráče 1");
                else if (mod == "pocitac")
                    chybaZnacka("svou značku");
                znakHrace = Console.ReadLine();

            }
            if (znakHrace == "kolecko")
                znakHrace = "o";
            else if (znakHrace == "krizek")
                znakHrace = "×";

            Console.WriteLine("");
            vychozi();
            sbyte barvaHrace = vyberBarvy(mod, "A");
            Console.WriteLine("");
            Console.WriteLine("");
            string prezdivkaH2 = " ";
            if (mod == "pvp")
            {
                vychozi();
                Console.Write("Zadejte přezdívku Hráče 2: ");
                vstup();
                prezdivkaH2 = Console.ReadLine();
                vychozi();
            }
            Console.WriteLine(" ");
            vychozi();
            if (mod == "pocitac")
                Console.Write("Zadejte značku Počítače (nebo ");
            else if (mod == "pvp")
                Console.Write("Zadejte značku Hráče 2 (nebo ");
            volba();
            Console.Write("kolecko");
            vychozi();
            Console.Write(" pro ");
            vstup();
            Console.Write("o");
            vychozi();
            Console.Write(", či ");
            volba();
            Console.Write("krizek");
            vychozi();
            Console.Write(" pro ");
            vstup();
            Console.Write("×");
            vychozi();
            Console.Write(" ): ");
            vstup();
            string znakPC = Console.ReadLine();

            while (znakPC == znakHrace)
            {
                if (znakPC == "smazat")
                    Console.Clear();
                err();
                if (mod == "pocitac")
                {
                    Console.WriteLine("Chybný vstup! Značka počítače nesmí být stejná, jako značka hráče!");
                    Console.Write("Pro smazání výpisu chyb a znovu zobrazení nabídky napište příkaz ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("smazat");
                    err();
                    Console.WriteLine(" .");
                    vychozi();
                    Console.Write("Zadejte značku Počítače (nebo ");
                }
                else if (mod == "pvp")
                {
                    Console.WriteLine("Chybný vstup! Značka Hráče 2 nesmí být stejná, jako značka Hráče 1!");
                    Console.Write("Pro smazání výpisu chyb a znovu zobrazení nabídky napište příkaz ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("smazat");
                    err();
                    Console.WriteLine(" .");
                    vychozi();
                    Console.Write("Zadejte značku Hráče 2 (nebo ");
                }

                volba();
                Console.Write("kolecko");
                vychozi();
                Console.Write(" pro ");
                vstup();
                Console.Write("o");
                vychozi();
                Console.Write(", či ");
                volba();
                Console.Write("krizek");
                vychozi();
                Console.Write(" pro ");
                vstup();
                Console.Write("×");
                vychozi();
                Console.Write(" ): ");
                vstup();
                znakPC = Console.ReadLine();
            }
            while (kontrolaZnacky(znakPC) == false)
            {
                if (znakPC == "smazat")
                    Console.Clear();

                if (mod == "pocitac")
                    chybaZnacka("značku Počítače");
                else if (mod == "pvp")
                    chybaZnacka("značku Hráče 2");
                znakPC = Console.ReadLine();

            }
            if (znakPC == "kolecko")
                znakPC = "o";
            else if (znakPC == "krizek")
                znakPC = "×";

            Console.WriteLine("");
            vychozi();
            sbyte barvaPC = vyberBarvy(mod, "B");

            Znacky znacky;
            znacky.barvaZnackaHrac = barvaHrace;
            znacky.barvaZnackaPC = barvaPC;
            znacky.znackaHrac = znakHrace;
            znacky.znackaPC = znakPC;
        startBezNastaveni:
            string[][] znackyPole = new string[3][];
            znackyPole[0] = new string[3];
            znackyPole[1] = new string[3];
            znackyPole[2] = new string[3];
            List<string> mozneSouradnice = new List<string>();
            mozneSouradnice.Add("A1");
            mozneSouradnice.Add("A2");
            mozneSouradnice.Add("A3");
            mozneSouradnice.Add("B1");
            mozneSouradnice.Add("B2");
            mozneSouradnice.Add("B3");
            mozneSouradnice.Add("C1");
            mozneSouradnice.Add("C2");
            mozneSouradnice.Add("C3");
            if (dalsiHra == true)
                Console.Clear();
            vychozi();
            Console.Write("Teď určíme, kdo začne. ");
            if (mod == "pvp")
            {
                rozeznaniBarvy(znacky.barvaZnackaHrac);
                Console.Write(prezdivka);
            }
            volba();
            Console.Write(" PANNA");
            vychozi();
            Console.Write(" nebo ");
            volba();
            Console.Write("OREL");
            vychozi();
            Console.Write(" ? ");
            vstup();
            string vstupMince = Console.ReadLine();
            while (vstupMince != "PANNA" & vstupMince != "OREL")
            {
                if (vstupMince == "smazat")
                    Console.Clear();
                err();
                Console.Write("Chybný vstup! Vstup můž mít pouze podobu ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("PANNA");
                err();
                Console.Write(" nebo ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("OREL");
                err();
                Console.WriteLine(" !");
                Console.Write("Pro smazání výpisu chyb a znovu zobrazení nabídky napište příkaz ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("smazat");
                err();
                Console.WriteLine(" .");
                volba();
                Console.Write("PANNA");
                vychozi();
                Console.Write(" nebo ");
                volba();
                Console.Write("OREL");
                vychozi();
                Console.Write(" ? ");
                vstup();
                vstupMince = Console.ReadLine();
            }
            string mincePadla = " ";
            int mince = rnd.Next(0, 2);
            if (mince == 0)
                mincePadla = "PANNA";
            else if (mince == 1)
                mincePadla = "OREL";
                      

            bool zacinaPocitac = true;
            if (vstupMince == mincePadla)
                zacinaPocitac = false;
            else if (vstupMince != mincePadla)
                zacinaPocitac = true;
            vychozi();

            Thread.Sleep(3111);
            Console.WriteLine("");
            if (mincePadla == "OREL")
            {
                vychozi();
                Console.Write("Padl ");
            }
            else if (mincePadla == "PANNA")
            {
                vychozi();
                Console.Write("Padla ");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(mincePadla);
            vychozi();
            Console.WriteLine(" .");
            Console.Write("Začíná ");
            if (zacinaPocitac == false)
            {
                rozeznaniBarvy(znacky.barvaZnackaHrac);
                Console.Write(prezdivka);
            }
            else if (zacinaPocitac == true)
            {
                rozeznaniBarvy(znacky.barvaZnackaPC);
                if (mod == "pocitac")
                    Console.Write("Počítač");
                else if (mod == "pvp")
                    Console.Write(prezdivkaH2);
            }
            string souradnice;


            vychozi();



            Console.WriteLine(" .");
            Thread.Sleep(5555);
            Console.Clear();

            if (mod == "pocitac")
            {
                vypsaniHernihoPole(znacky, znackyPole, prezdivka, "Počítač", mozneSouradnice, tezkost);
                if (zacinaPocitac == true)
                {
                    souradnice = "B2";
                    umisteniZnacky(znacky, "PC", souradnice, znackyPole);

                    mozneSouradnice.Remove("B2");
                    Thread.Sleep(3111);
                }
                Console.Clear();
                vypsaniHernihoPole(znacky, znackyPole, prezdivka, "Počítač", mozneSouradnice, tezkost);

                string vitezstvi = "nikdo";
                while (mozneSouradnice.Count > 0 || vitezstvi != "nikdo")
                {
                    Console.Write("Zadejte souřadnice, kam chcete umístit svoji značku: ");
                    vstup();
                    souradnice = Console.ReadLine();
                    while (mozneSouradnice.Contains(souradnice) == false)
                    {
                        if (souradnice == "smazat")
                        {
                            Console.Clear();
                            vypsaniHernihoPole(znacky, znackyPole, prezdivka, prezdivkaH2, mozneSouradnice, tezkost);
                        }
                        err();
                        Console.WriteLine("Chybný vstup! Zadanou souřadnici nelze použít (špatně zadaná souřadnice, nebo již použitá souřadnice!");
                        Console.Write("Pro vymazání výpisu chyb a znovu vypsání herního pole zadejte příkaz ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("smazat");
                        err();
                        Console.WriteLine(" .");
                        vychozi();
                        Console.Write("Zadejte souřadnice, kam chcete umístit svoji značku: ");
                        vstup();
                        souradnice = Console.ReadLine();
                    }
                    umisteniZnacky(znacky, "hrac", souradnice, znackyPole);

                    mozneSouradnice.Remove(souradnice);
                    Console.Clear();
                    vypsaniHernihoPole(znacky, znackyPole, prezdivka, "Počítač", mozneSouradnice, tezkost);
                    vitezstvi = (vitez(znackyPole, znacky));
                    if (vitezstvi != "nikdo" || mozneSouradnice.Count == 0)
                    {
                        Console.Clear();
                        vypsaniHernihoPole(znacky, znackyPole, prezdivka, "Počítač", mozneSouradnice, tezkost);
                        Thread.Sleep(5111);
                        goto konec;
                    }

                    string pc = tahPC(mozneSouradnice, znackyPole, znacky, tezkost);
                    umisteniZnacky(znacky, "PC", pc, znackyPole);
                    mozneSouradnice.Remove(pc);

                    Thread.Sleep(3111);
                    Console.Clear();
                    vypsaniHernihoPole(znacky, znackyPole, prezdivka, "Počítač", mozneSouradnice, tezkost);
                    vitezstvi = (vitez(znackyPole, znacky));
                    if (vitezstvi != "nikdo" || mozneSouradnice.Count == 0)
                    {
                        Console.Clear();
                        vypsaniHernihoPole(znacky, znackyPole, prezdivka, "Počítač", mozneSouradnice, tezkost);
                        Thread.Sleep(5111);
                        goto konec;
                    }
                }
            konec:
                vitezstvi = (vitez(znackyPole, znacky));
                if (vitezstvi == "hrac")
                    vyhraHrac(znacky, prezdivka);
                else if (vitezstvi == "PC")
                    vyhraPC(znacky, prezdivka);
                else if (mozneSouradnice.Count == 0 & vitezstvi == "nikdo")
                    remiza();
                vychozi();
                goto zaver;
            }
            else if (mod == "pvp")
            {
                Console.Clear();
                vypsaniHernihoPole(znacky, znackyPole, prezdivka, prezdivkaH2, mozneSouradnice, tezkost);
                if (zacinaPocitac == true)
                {
                    rozeznaniBarvy(znacky.barvaZnackaPC);
                    Console.Write(prezdivkaH2);
                    vychozi();
                    Console.Write(" Zadejte souřadnice, kam chcete umístit svoji značku: ");
                    vstup();
                    souradnice = Console.ReadLine();
                    while (mozneSouradnice.Contains(souradnice) == false)
                    {
                        if (souradnice == "smazat")
                        {
                            Console.Clear();
                            vypsaniHernihoPole(znacky, znackyPole, prezdivka, prezdivkaH2, mozneSouradnice, tezkost);
                        }
                        err();
                        Console.WriteLine("Chybný vstup! Zadanou souřadnici nelze použít (špatně zadaná souřadnice, nebo již použitá souřadnice!");
                        Console.Write("Pro vymazání výpisu chyb a znovu vypsání herního pole zadejte příkaz ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("smazat");
                        err();
                        Console.WriteLine(" .");
                        rozeznaniBarvy(znacky.barvaZnackaPC);
                        Console.Write(prezdivkaH2);
                        vychozi();
                        Console.Write("Zadejte souřadnice, kam chcete umístit svoji značku: ");
                        vstup();
                        souradnice = Console.ReadLine();
                    }
                    umisteniZnacky(znacky, "PC", souradnice, znackyPole);

                    mozneSouradnice.Remove(souradnice);
                }
                Console.Clear();
                vypsaniHernihoPole(znacky, znackyPole, prezdivka, prezdivkaH2, mozneSouradnice, tezkost);
                string vitezstvi = "nikdo";
                while (mozneSouradnice.Count > 0 || vitezstvi != "nikdo")
                {
                    rozeznaniBarvy(znacky.barvaZnackaHrac);
                    Console.Write(prezdivka);
                    vychozi();
                    Console.Write(" Zadejte souřadnice, kam chcete umístit svoji značku: ");
                    vstup();
                    souradnice = Console.ReadLine();
                    while (mozneSouradnice.Contains(souradnice) == false)
                    {
                        if (souradnice == "smazat")
                        {
                            Console.Clear();
                            vypsaniHernihoPole(znacky, znackyPole, prezdivka, prezdivkaH2, mozneSouradnice, tezkost);
                        }
                        err();
                        Console.WriteLine("Chybný vstup! Zadanou souřadnici nelze použít (špatně zadaná souřadnice, nebo již použitá souřadnice!");
                        Console.Write("Pro vymazání výpisu chyb a znovu vypsání herního pole zadejte příkaz ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("smazat");
                        err();
                        Console.WriteLine(" .");
                        rozeznaniBarvy(znacky.barvaZnackaHrac);
                        Console.Write(prezdivka);
                        vychozi();
                        Console.Write(" Zadejte souřadnice, kam chcete umístit svoji značku: ");
                        vstup();
                        souradnice = Console.ReadLine();
                    }
                    umisteniZnacky(znacky, "hrac", souradnice, znackyPole);
                    mozneSouradnice.Remove(souradnice);
                    Console.Clear();
                    vypsaniHernihoPole(znacky, znackyPole, prezdivka, prezdivkaH2, mozneSouradnice, tezkost);
                    if (vitez(znackyPole, znacky) != "nikdo" || mozneSouradnice.Count == 0)
                    {
                        Thread.Sleep(5111);
                        goto konecHra;
                    }
                    rozeznaniBarvy(znacky.barvaZnackaPC);
                    Console.Write(prezdivkaH2);
                    vychozi();
                    Console.Write(" Zadejte souřadnice, kam chcete umístit svoji značku: ");
                    vstup();
                    souradnice = Console.ReadLine();
                    while (mozneSouradnice.Contains(souradnice) == false)
                    {
                        if (souradnice == "smazat")
                        {
                            Console.Clear();
                            vypsaniHernihoPole(znacky, znackyPole, prezdivka, prezdivkaH2, mozneSouradnice, tezkost);
                        }
                        err();
                        Console.WriteLine("Chybný vstup! Zadanou souřadnici nelze použít (špatně zadaná souřadnice, nebo již použitá souřadnice!");
                        Console.Write("Pro vymazání výpisu chyb a znovu vypsání herního pole zadejte příkaz ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("smazat");
                        err();
                        Console.WriteLine(" .");
                        rozeznaniBarvy(znacky.barvaZnackaPC);
                        Console.Write(prezdivkaH2);
                        vychozi();
                        vychozi();
                        Console.Write(" Zadejte souřadnice, kam chcete umístit svoji značku: ");
                        vstup();
                        souradnice = Console.ReadLine();
                    }
                    umisteniZnacky(znacky, "PC", souradnice, znackyPole);
                    mozneSouradnice.Remove(souradnice);
                    Console.Clear();
                    vypsaniHernihoPole(znacky, znackyPole, prezdivka, prezdivkaH2, mozneSouradnice, tezkost);
                    if (vitez(znackyPole, znacky) != "nikdo" || mozneSouradnice.Count == 0)
                    {
                        Thread.Sleep(5111);
                        goto konecHra;
                    }

                konecHra:

                    if (vitez(znackyPole, znacky) == "hrac")
                    {
                        vyhraHrac1(prezdivka, prezdivkaH2, znacky);
                        goto zaver;
                    }
                    else if (vitez(znackyPole, znacky) == "PC")
                    {
                        vyhraHrac2(prezdivka, prezdivkaH2, znacky);
                        goto zaver;
                    }
                    else if (mozneSouradnice.Count == 0 & vitezstvi == "nikdo")
                    {
                        remiza();
                        goto zaver;
                    }

                }

            }
        zaver:
            vychozi();
            Console.Write("Pro novou hru se stejným nastavením stiskněte ");
            volba();
            Console.Write("Enter");
            vychozi();
            Console.WriteLine(" .");
            Console.Write("Pro novou hru s jiným nastavením stiskněte ");
            volba();
            Console.Write("Backspace");
            vychozi();
            Console.WriteLine(" .");
            Console.Write("Pro konec stiskněte ");
            volba();
            Console.Write("Escape");
            vychozi();
            Console.WriteLine(" .");
            ConsoleKeyInfo vstupniKlavesa = Console.ReadKey();
            while (vstupniKlavesa.Key != ConsoleKey.Backspace & vstupniKlavesa.Key != ConsoleKey.Enter & vstupniKlavesa.Key != ConsoleKey.Escape)
            {
                err();
                Console.WriteLine("Stisknutá klávesa je mimo možnosti.");
                Console.WriteLine("Stiskněte klávesu:");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter");
                err();
                Console.WriteLine(" pro novou hru se stejným nastavením");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Backspace");
                err();
                Console.WriteLine(" pro novou hru s jiným nastavením");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Escape");
                err();
                Console.WriteLine(" pro konec");
                vstupniKlavesa = Console.ReadKey();

            }
            if (vstupniKlavesa.Key == ConsoleKey.Enter)
            {
                dalsiHra = true;
                goto startBezNastaveni;
            }
            else if (vstupniKlavesa.Key == ConsoleKey.Backspace)
                goto start;
            else if (vstupniKlavesa.Key == ConsoleKey.Escape)
                goto end;
        end:
            Console.Clear();
        }
    }
}
