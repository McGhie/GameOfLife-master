using Gameoflife.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class GameofLife 

        
    {

        public GameofLife(int height, int width, string cells)
        {

            if (height < 1 || width < 1)
            {
                throw new NotImplementedException();
            }
            Height = height;
            Width = width;
            char[] cellArray = cells.ToArray();
            Cell[][] tempCells = new Cell[Height][];
          
            var Counter = 0;

            for (int h = 0; h <= Height - 1; h++)
            {
                tempCells[h] = new Cell[Width];
                for (int w = 0; w <= Width - 1; w++)
                {
                    if (cellArray[Counter].ToString().Equals("\r"))
                    {
                        Counter++;
                    }
                    if (cellArray[Counter].ToString().Equals("\n"))
                    {
                        Counter++;
                    }

                    if (cellArray[Counter].ToString().Equals("x")) { 

                        tempCells[h][w] = Cell.Dead;
                    }
                    else
                    {
                        tempCells[h][w] = Cell.Alive;

                    }
                    Counter++;
                }
            }
            Cells = tempCells;
     
        }


   

        public int Height { get; set; }
        public int Width { get; set; }
        public Cell[][] Cells { get; set; }
        const char aliveCellChar = '\u2588';

    

        public void TakeTurn()
        {
            
            var tempCells = Cells;
            //We need to create a new instance of a cell to copy into
            //we can not just copy into the current one as it will change the result for the next cell being looked at.
            //we need to do this twice once for [height] and again for [width]-this is in the inner loop.
            Cell[][] CellClone = new Cell[Height][];
            
            for (int h = 0; h <= Height - 1; h++)
            {
                CellClone[h] = new Cell[Width];
                for (int w = 0; w <= Width - 1; w++)
                {

                    //We need to check if the cell is dead or alive as there are different rules for each

                    if (tempCells[h][w] == Cell.Alive) //Alive Cell Rule can have 2 or 3 living neighbours
                    {
                        
                        int aliveCount = CountLivingNeighbours(h, w);

                        if (aliveCount < 2 || aliveCount > 3)
                        {
                            CellClone[h][w] = Cell.Dead;
                        }
                        else 
                        {
                            CellClone[h][w] = Cell.Alive;
                        }
                    }

                    if (tempCells[h][w] == Cell.Dead) //Dead Cell Rule can only have 3 living neighbours
                    {

                        int aliveCount = CountLivingNeighbours(h, w);

                         if (aliveCount == 3)
                        {
                            CellClone[h][w] = Cell.Alive;
                        }

                        else
                        {
                            CellClone[h][w] = Cell.Dead;
                        }
                       
                    }
                    
                }
                
            }
            Cells = CellClone;

           
            
        }

        public int CountLivingNeighbours(int xC, int yC)
        {
            int live = 0;
            if (xC-1 > -1)
            {
                if(yC-1 > -1 && Cells[xC-1][yC-1]==Cell.Alive){live++;}
                if (Cells[xC - 1][yC] == Cell.Alive){live++;}
                if (yC+1 < Width && Cells[xC - 1][yC+1] == Cell.Alive){live++;}
            }
            if (yC - 1 > -1 && Cells[xC][yC - 1] == Cell.Alive){live++;}
            if (yC + 1 < Width && Cells[xC][yC + 1] == Cell.Alive){live++;}
            if (xC + 1 < Height)
            {
                if (yC - 1 > -1 && Cells[xC +1][yC - 1] == Cell.Alive){live++;}
                if (Cells[xC + 1][yC] == Cell.Alive){live++;}
                if (yC + 1 < Width && Cells[xC + 1][yC + 1] == Cell.Alive){live++;}
            }
            return live;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int h = 0; h <= Height - 1; h++)
            {

                for (int w = 0; w <= Width - 1; w++)
                {
                    if (this.Cells[h][w] == Cell.Alive)
                    {
                        output.Append(aliveCellChar); 
                    }
                    else
                    {
                        output.Append(" ");
                    }

                }
                output.AppendLine();
            }
            
          
            return output.ToString();
        }
    }
}
