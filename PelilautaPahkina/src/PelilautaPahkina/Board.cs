using System;

namespace PelilautaPahkina
{
    public class Board
    {
        public enum BoardStates { None = 0, Boatpiece = 1, Shot = 4, Hit = 9 };

        private int[,] boardpositions = new int[10, 10];

        public void SetBoardValue(string coordinate, object arvo)
        {
            boardpositions[GetLetterCoord(coordinate), GetNumberCoord(coordinate)] = (int)arvo;
        }

        public int GetBoardValue(string coordinate)
        {
            return boardpositions[GetLetterCoord(coordinate), GetNumberCoord(coordinate)];
        }

        private int GetLetterCoord(string coordinateLetter)
        {
            if (String.IsNullOrEmpty(coordinateLetter)) return 0;
            string letters = "abcdefghij";
            var letter = coordinateLetter.Substring(0, 1);
            return letters.IndexOf(letter);
        }
        //A1 returns 0 -> index starts from 0 but human sees a1 as first
        private int GetNumberCoord(string coordinateNumber)
        {
            if (String.IsNullOrEmpty(coordinateNumber)) return 0;
            return Int32.Parse(coordinateNumber.Substring(1)) - 1;
        }

        //mark 4 to board where shoot goes
        public void Shoot(int i)
        {
            var linearray = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
            var coord = linearray[GetLinearrayNumber(i)] + "" + i % 10;
            if (this.GetBoardValue(coord) == (int)BoardStates.Boatpiece)
            {
                SetBoardValue(coord, BoardStates.Hit);
            }
            else
            {
                SetBoardValue(coord, BoardStates.Shot);
            }
        }

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
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("|" + ToBoardCharacter(boardpositions[i, j]));
                }
                Console.WriteLine("|");
                Drawline();
            }
            Console.WriteLine("");
            Console.WriteLine("* = Boatpiece, o = missed shot, X = DIRECT HIT!");

        }

        private static int GetLinearrayNumber(int i)
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

        private static char ToBoardCharacter(int i)
        {
            switch (i)
            {
                case (int)Board.BoardStates.Boatpiece:
                    return '*';
                case (int)Board.BoardStates.Shot:
                    return 'o';
                case (int)Board.BoardStates.Hit:
                    return 'X';
                case (int)Board.BoardStates.None:
                    return ' ';
                default:
                    return ' ';
            }
        }
    }
}

