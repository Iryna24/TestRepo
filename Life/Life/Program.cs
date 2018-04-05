using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = 0;
            var columns = 0;
            var result = false;

            char [,] Cells = new char[rows, columns];
            char[,] ArrayForChecking = new char[rows, columns];

            do {
                Game.StartGame(ref Cells, ref rows, ref columns, ref result);
            } while (result == false);

            Game.ShowCellsState(ref Cells, rows, columns);

            do
            {
                Game.ChangeCellsState(ref Cells, rows, columns);
                Console.Clear();
                Game.ShowCellsState(ref Cells, rows, columns);

            } while (Game.CheckArrayHasLiveCells(Cells, rows, columns));
          

            Console.WriteLine("To stop displaying the playing field, please, press Enter.");
            Console.ReadLine();
            
        }
    } 
}
