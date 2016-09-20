using System;
using System.Dynamic;

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

    }
}

