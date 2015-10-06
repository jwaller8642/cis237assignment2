using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        Boolean mazeSovled = false;
        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        { }


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
       public char[,] SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            //Do work needed to use mazeTraversal recursive call and solve the maze.
             mazeSovled = false;

            do
            {
                mazeTraversal(xStart, yStart);
            }
            while (mazeSovled != true);

            return maze;

        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(int x, int y)
        {
            //Implement maze traversal recursive call

            int moveUp = x - 1;
            int moveDown = x + 1;
            int moveLeft = y - 1;
            int moveRight = y + 1;
            try
            {
                // checks up Move UP
                // If we run in to a wall(#) current spot will be marked with an X, 
                //and then we move in the oposite direction.
                //or if it is equal to a clearPath(.) it keeps going in that direction. 
                if (maze[moveUp, y] == '#')
                {
                    maze[x, y] = 'X'; 
                    mazeTraversal(moveDown, y);
                }
                else
                {
                    maze[x, y] = 'O';
                    mazeTraversal(moveUp, y);
                }
                //checks up Move Down
                if (maze[moveDown, y] == '#')
                {
                    maze[x, y] = 'X';
                    mazeTraversal(moveUp, y);
                }
                else
                {

                    maze[x, y] = 'O';
                    mazeTraversal(moveDown, y);
                }
                //checks up Move Left
                if (maze[moveLeft, y] == '#')
                {
                    maze[x, y] = 'X';
                    mazeTraversal(x, moveRight);
                }
                else
                {
                    maze[x, y] = 'O';
                    mazeTraversal(x, moveLeft);
                }
                //checks up Move Right
                if (maze[x, moveRight] == '#')
                {
                    maze[x, y] = 'X';
                    mazeTraversal(x, moveLeft);
                }
                else
                {

                    maze[x, y] = 'O';
                    mazeTraversal(x, moveRight);
                }
                
            }
            catch (StackOverflowException)
            {
                mazeSovled = true;
            }

        }
    }
}
