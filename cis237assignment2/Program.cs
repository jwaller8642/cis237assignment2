//Jason Waller
//A2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '.' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();
            PrintMaze(maze1);


            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);
            PrintMaze(maze2);


            /// <summary>
            /// Tell the instance to solve the first maze with the passed maze, and start coordinates.
            /// </summary>
           char[,] solvedMaze1 = mazeSolver.SolveMaze(maze1, X_START, Y_START);
           PrintMaze(solvedMaze1);
            
            //Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);

        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            //Write code here to create a transposed maze.
            
            
            
            int countRows = mazeToTranspose.GetLength(0);
            int countColums = mazeToTranspose.GetLength(1);
            char[,] transposeMaze = new char[countColums, countRows];

            if (countRows == countColums)
            {
                transposeMaze = (char[,]) mazeToTranspose.Clone();
                for(int i = 1; i < countRows; i++)
                {
                    for(int j = 0; j < i; j++)
                    {
                        char tempTranpose = transposeMaze[i, j];
                        transposeMaze[i, j] = transposeMaze[j, i];
                        transposeMaze[j, i] = tempTranpose;

                    }
                }
            }
            else
            {
                for( int colums = 0; colums < countColums; colums++)
                {
                    for (int rows = 0; rows < countRows; rows++)
                    {
                        transposeMaze[colums, rows] = mazeToTranspose[rows, colums];

                    }
                }
            }

            return transposeMaze;
            
        }

         static void PrintMaze(char[,] printedMaze)
        {
             for (int i = 0 ; i < printedMaze.GetLength(0); i++)
             {
                 for (int j = 0; j < printedMaze.GetLength(1); j++)
                 {
                     Console.Write(printedMaze[i, j] + " ");
                 }
                 Console.WriteLine();
             }
             Console.WriteLine();
             Console.WriteLine();
             Console.ReadKey();
        }
    }
}
