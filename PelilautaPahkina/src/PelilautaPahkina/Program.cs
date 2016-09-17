using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace PelilautaPahkina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();

            dynamic tättärää = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(System.IO.File.ReadAllText("sotatanner.json"));

            // DEPLOY ZE ARMAAADA!
            foreach (var o in tättärää.nappulat)
            {
                foreach (var o2 in o)
                {
                    Board.SetValue(board, o2, 1);
                    
                    
                }
            }

            var linearray = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

            //change2

            // FIRE ZE CANNONS!
            for (int i = 0; i < 100; i++) 
            {
                if (!string.IsNullOrEmpty(tättärää.shotsFired[i].ToString()))
                    Board.SetValue(board, linearray[i.GetLinearrayNumber()] + "" + i % 10, 4); //SHOT FIRED!
            }

            // SINKING THE BISHMARK!
            foreach (var o in tättärää.nappulat) // VAC ENABLED!
            {
                foreach (var o2 in o)
                {
                    var PaatinPaikka = Board.GetValue(board, o2);

                    if (PaatinPaikka != 1 && PaatinPaikka == 4)
                        Board.SetValue(board, o2, 9); // OSU JA UPPOS!
                }
            }

            board.DrawBoard();
            Console.ReadKey();
        }

        public class Board
        {
            // Declaring variables
            public static void SetValue(Board lauta, string cordinate, object arvo)
            {
                // Reflection is cool, right : http://stackoverflow.com/questions/619767/set-object-property-using-reflection
                var pi = typeof(Board).GetField(cordinate, BindingFlags.NonPublic | BindingFlags.Instance);
                pi.SetValue(lauta, (int)arvo);
            }

            public static int? GetValue(Board lauta, string cordinate)
            {
                return typeof(Board).GetField(cordinate, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(lauta) as int?;
            }

            // GameBoard
            private int a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 = 0;
            private int b1, b2, b3, b4, b5, b6, b7, b8, b9, b10 = 0;
            private int c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 = 0;
            private int d1, d2, d3, d4, d5, d6, d7, d8, d9, d10 = 0;
            private int e1, e2, e3, e4, e5, e6, e7, e8, e9, e10 = 0;
            private int f1, f2, f3, f4, f5, f6, f7, f8, f9, f10 = 0;
            private int g1, g2, g3, g4, g5, g6, g7, g8, g9, g10 = 0;
            private int h1, h2, h3, h4, h5, h6, h7, h8, h9, h10 = 0;
            private int i1, i2, i3, i4, i5, i6, i7, i8, i9, i10 = 0;
            private int j1, j2, j3, j4, j5, j6, j7, j8, j9, j10 = 0;

            public void DrawBoard()
            {
                Console.WriteLine("Post Game Analysis :");
                Console.WriteLine("");
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", a1.ToBoardCharacter(), a2.ToBoardCharacter(), a3.ToBoardCharacter(), a4.ToBoardCharacter(), a5.ToBoardCharacter(), a6.ToBoardCharacter(), a7.ToBoardCharacter(), a8.ToBoardCharacter(), a9.ToBoardCharacter(), a10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", b1.ToBoardCharacter(), b2.ToBoardCharacter(), b3.ToBoardCharacter(), b4.ToBoardCharacter(), b5.ToBoardCharacter(), b6.ToBoardCharacter(), b7.ToBoardCharacter(), b8.ToBoardCharacter(), b9.ToBoardCharacter(), b10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", c1.ToBoardCharacter(), c2.ToBoardCharacter(), c3.ToBoardCharacter(), c4.ToBoardCharacter(), c5.ToBoardCharacter(), c6.ToBoardCharacter(), c7.ToBoardCharacter(), c8.ToBoardCharacter(), c9.ToBoardCharacter(), c10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", d1.ToBoardCharacter(), d2.ToBoardCharacter(), d3.ToBoardCharacter(), d4.ToBoardCharacter(), d5.ToBoardCharacter(), d6.ToBoardCharacter(), d7.ToBoardCharacter(), d8.ToBoardCharacter(), d9.ToBoardCharacter(), d10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", e1.ToBoardCharacter(), e2.ToBoardCharacter(), e3.ToBoardCharacter(), e4.ToBoardCharacter(), e5.ToBoardCharacter(), e6.ToBoardCharacter(), e7.ToBoardCharacter(), e8.ToBoardCharacter(), e9.ToBoardCharacter(), e10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", f1.ToBoardCharacter(), f2.ToBoardCharacter(), f3.ToBoardCharacter(), f4.ToBoardCharacter(), f5.ToBoardCharacter(), f6.ToBoardCharacter(), f7.ToBoardCharacter(), f8.ToBoardCharacter(), f9.ToBoardCharacter(), f10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", g1.ToBoardCharacter(), g2.ToBoardCharacter(), g3.ToBoardCharacter(), g4.ToBoardCharacter(), g5.ToBoardCharacter(), g6.ToBoardCharacter(), g7.ToBoardCharacter(), g8.ToBoardCharacter(), g9.ToBoardCharacter(), g10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", h1.ToBoardCharacter(), h2.ToBoardCharacter(), h3.ToBoardCharacter(), h4.ToBoardCharacter(), h5.ToBoardCharacter(), h6.ToBoardCharacter(), h7.ToBoardCharacter(), h8.ToBoardCharacter(), h9.ToBoardCharacter(), h10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", i1.ToBoardCharacter(), i2.ToBoardCharacter(), i3.ToBoardCharacter(), i4.ToBoardCharacter(), i5.ToBoardCharacter(), i6.ToBoardCharacter(), i7.ToBoardCharacter(), i8.ToBoardCharacter(), i9.ToBoardCharacter(), i10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", j1.ToBoardCharacter(), j2.ToBoardCharacter(), j3.ToBoardCharacter(), j4.ToBoardCharacter(), j5.ToBoardCharacter(), j6.ToBoardCharacter(), j7.ToBoardCharacter(), j8.ToBoardCharacter(), j9.ToBoardCharacter(), j10.ToBoardCharacter());
                Console.WriteLine("---------------------");
                Console.WriteLine("");
                Console.WriteLine("* = Boatpiece, o = missed shot, X = DIRECT HIT!");
            }
        }
    }

    public static class intExtensions
    {
        public static int GetLinearrayNumber(this int i)
        {
            int retval;
            try
            {
                retval = i / 10;
            }
            catch (Exception e)
            {
                Console.WriteLine("POKS :" + e);
                retval = 0;
            }
            return retval;
        }

        public static char ToBoardCharacter(this int i)
        {
            switch (i)
            {
                case 1:
                    return '*';
                case 4:
                    return 'o';
                case 9:
                    return 'X';
                default:
                    return ' ';
            }
        }

    }
}

