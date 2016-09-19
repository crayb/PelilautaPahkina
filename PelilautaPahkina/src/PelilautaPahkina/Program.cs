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
            
            dynamic pelidata = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(System.IO.File.ReadAllText("sotatanner.json"));

            // DEPLOY ZE ARMAAADA!
            foreach (var alus in pelidata.nappulat)
            {
                foreach (var aluksenOsa in alus)
                {
                    board.SetBoardValue(aluksenOsa, Board.BoardStates.Boatpiece);                    
                }
            }

            // FIRE ZE CANNONS!
            for (int i = 0; i < 100; i++) 
            {
                if (!string.IsNullOrEmpty(pelidata.shotsFired[i].ToString()))
                {
                    board.Shoot(i);
                }
            }

            board.DrawBoard();
            Console.ReadKey();
        }

        public class Board
        {
            public enum BoardStates { None = 0, Boatpiece = 1, Shot = 4, Hit = 9 };

            public void SetBoardValue(string coordinate, object arvo)
            {
                boardpositions[GetLetterCoord(coordinate),GetNumberCoord(coordinate)] = (int)arvo;

            }

            public int GetBoardValue(string coordinate)
            {
                return boardpositions[GetLetterCoord(coordinate),GetNumberCoord(coordinate)];
            }
        
            private int GetLetterCoord(string coordinateLetter)
            {
                if(string.IsNullOrEmpty(coordinateLetter)) return 0;
                string letters = "abcdefghij";
                var letter = coordinateLetter.Substring(0,1);
                return letters.IndexOf(letter);
            }
            //A1 returns 0 -> index starts from 0 but human sees a1 as first
            private int GetNumberCoord(string coordinateNumber)
            {
                if(string.IsNullOrEmpty(coordinateNumber)) return 0;
                return Int32.Parse(coordinateNumber.Substring(1))-1;
            }

            //mark 4 to board where shoot goes
            public void Shoot(int i)
            {
                var linearray = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
                var coord = linearray[i.GetLinearrayNumber()] + "" + i%10;
                if (this.GetBoardValue(coord) == (int) BoardStates.Boatpiece)
                {
                    SetBoardValue(coord, BoardStates.Hit);
                }
                else
                {
                    SetBoardValue(coord, BoardStates.Shot);
                }
            }
 
            private int[,] boardpositions = new int[10,10];

            private void Drawline()
            {
                Console.WriteLine("---------------------");
            }

            public void DrawBoard()
            {
                Console.WriteLine("Post Game Analysis :");
                Console.WriteLine("");
                Drawline();
                //loop rows / positions
                for(int i = 0; i<10; i++)
                {
                    for(int j = 0; j< 10; j++)
                    {
                        Console.Write("|"+boardpositions[i,j].ToBoardCharacter());
                    }
                    Console.WriteLine("|");
                    Drawline();
                }
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
                case (int)Program.Board.BoardStates.Boatpiece:
                    return '*';
                case (int)Program.Board.BoardStates.Shot:
                    return 'o';
                case (int)Program.Board.BoardStates.Hit:
                    return 'X';
                case (int)Program.Board.BoardStates.None:
                    return ' ';
                default:
                    return ' ';
            }
        }

    }
}

