using System;


namespace Life
{
    class Game
    {
        ///<summary>Set size of the playing field and create first live cells on the field</summary>
        ///<param name = "Cells" type = "array of chars">[RetVal] Array of cells </param>
        ///<param name = "rows" type = "integer">[RetVal] Number of rows on the playing field. </param>
        ///<param name = "columns" type = "integer">[RetVal] Number of columns on the playing field. </param>
        ///<param name = "result" type = "boolean">[RetVal] Result of setting parametrs for game </param>
        public static bool StartGame(ref char[,] Cells, ref int rows, ref int columns, ref bool result)
        {
            result = true;
            int numberOfLiveCells;
            int firstCoordinate = 0;
            int secondCoordinate = 0;

            try
            {
                Console.WriteLine("Please, enter number of rows for the playing field: ");
                string text = Console.ReadLine();
                bool res = Int32.TryParse(text, out rows);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please, enter correct number of rows");
                result = false;
            }
            try
            {
                Console.WriteLine("Please, enter number of columns for the playing field: ");
                string text1 = Console.ReadLine();
                bool res1 = Int32.TryParse(text1, out columns);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please, enter correct number of columns");
                result = false;
            }

            Cells = new char[rows, columns];
            FillArray(ref Cells, rows, columns);

            //set start values
            //Cells[0, 1] = '■';
            //Cells[1, 1] = '■';
            //Cells[2, 0] = '■';
            //Cells[2, 1] = '■';
            //Cells[2, 2] = '■';

            //Cells[5, 2] = '■';
            //Cells[5, 3] = '■';
            //Cells[5, 4] = '■';

            Console.WriteLine("Please, enter number of live cells you want to create for first generation: ");
            string text2 = Console.ReadLine();
            bool res2 = Int32.TryParse(text2, out numberOfLiveCells);

            for (int i = 0; i < numberOfLiveCells; i++)
            {
                Console.WriteLine("Please, enter first coordinate for new cell, max number = " + rows);
                string text3 = Console.ReadLine();
                bool res3 = Int32.TryParse(text3, out firstCoordinate);

                if (firstCoordinate > rows)
                {
                    Console.WriteLine("Error: First coordinate cannot be more than " + rows);
                    result = false;
                    break;
                }

                Console.WriteLine("Please, enter second coordinate for new cell, max number = " + columns);
                string text4 = Console.ReadLine();
                bool res4 = Int32.TryParse(text4, out secondCoordinate);

                if (secondCoordinate > rows)
                {
                    Console.WriteLine("Error: Second coordinate cannot be more than " + columns);
                    result = false;
                    break;
                }

                Cells[firstCoordinate, secondCoordinate] = '■';
            }
            
            return result;
        }

        ///<summary>Fill an array with '█' symbols </summary>
        ///<param name = "Cells" type = "array of chars"> [RetVal] Array of cells </param>
        ///<param name = "rows" type = "integer"> Number of rows on the playing field. </param>
        ///<param name = "columns" type = "integer"> Number of columns on the playing field. </param>
        public static void FillArray(ref char[,] Cells, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cells[i, j] = '█';
                }
            }
        }

        ///<summary>Change cells state (mark empty cells to create if they have 3 neighbour live cells). </summary>
        ///<param name = "Cells" type = "array of chars">[RetVal] Array of cells </param>
        ///<param name = "rows" type = "integer"> Number of rows on the playing field. </param>
        ///<param name = "columns" type = "integer"> Number of columns on the playing field. </param>
        public static void ChangeCellsState(ref char [,] Cells, int rows, int columns)
        {
            char[,] NewArrayOfCells = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int neighboursCounter = 0;

                    try
                    {
                        if (Cells[i - 1, j] == '■')
                            neighboursCounter += 1;
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (Cells[i + 1, j] == '■')
                            neighboursCounter += 1;
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (Cells[i, j - 1] == '■')
                            neighboursCounter += 1;
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (Cells[i, j + 1] == '■')
                            neighboursCounter += 1;
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (Cells[i - 1, j - 1] == '■')
                            neighboursCounter += 1;
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (Cells[i + 1, j + 1] == '■')
                            neighboursCounter += 1;
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (Cells[i + 1, j - 1] == '■')
                            neighboursCounter += 1;
                    }
                    catch (IndexOutOfRangeException) { }

                    try
                    {
                        if (Cells[i - 1, j + 1] == '■')
                            neighboursCounter += 1;
                    }
                    catch (IndexOutOfRangeException) { }

                    if (neighboursCounter == 2)
                    {
                        NewArrayOfCells[i, j] = Cells[i, j];
                    }
                    else if (neighboursCounter <= 1)
                    {
                        NewArrayOfCells[i, j] = '█';
                    }
                    else if (neighboursCounter == 3)
                    {
                        NewArrayOfCells[i, j] = '■';
                    }
                    else
                    {
                        NewArrayOfCells[i, j] = '█';
                    }
                }
            }

            Array.Copy(NewArrayOfCells, Cells, NewArrayOfCells.Length);
        }

        ///<summary> Display an array of cells. </summary>
        ///<param name = "Cells" type = "array of chars"> [RetVal] Array of cells. </param>
        ///<param name = "rows" type = "integer"> Number of rows on the playing field. </param>
        ///<param name = "columns" type = "integer"> Number of columns on the playing field. </param>
        public static void ShowCellsState(ref char[,] Cells, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Cells[i, j] == '■')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Cells[i, j] = '■';
                        Console.Write(Cells[i, j]);
                    }
                    else
                    {
                        Utils.ResetColors();
                        Console.Write(Cells[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        ///<summary> Check that array has live cells. </summary>
        ///<param name = "Cells" type = "array of chars"> Array of cells </param>
        ///<param name = "rows" type = "integer"> Number of rows on the playing field. </param>
        ///<param name = "columns" type = "integer"> Number of columns on the playing field. </param>
        public static bool CheckArrayHasLiveCells(char[,] Cells, int rows, int columns)
        {
            bool result = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Cells[i, j] == '■')
                        result = true;
                }
            }
            return result;
        }

    }
}
