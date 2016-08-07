using System;
using System.Text;

namespace GameOfLife
{
    public class GameOfLife 

    {
        public GameOfLife(int height, int width)
        {
           /* if (height<1 || width<1 )
            {
                throw new NotImplementedException();
            }
            Height = height;
            Width = width;
            Cell[][] TempCells = new Cell[Height][];
            for (int h = 0; h <= Height-1; h++)
            {
                TempCells[h] = new Cell[Width];
                for (int w = 0; w <= Width-1; w++)
                {
                    TempCells[h][w] = Cell.Dead;
                }
            }
            Cells = TempCells;*/

            //
        }

        public int Height { get; set; }
        public int Width { get; set; }
       // public Cell[][] Cells { get; set; }
        const char aliveCellChar = '\u2588';

       
       
        public void TakeTurn()
        {
            /* var tempCells = Cells.Select(x => x.ToArray()).ToArray();
           
            for (int h = 0; h <= Height - 1; h++)
            {
               for (int w = 0; w <= Width - 1; w++)
                {
                    int aliveCount = CountLivingNeighbours(h, w);

                    if (aliveCount < 2 || aliveCount > 3)
                    {
                        tempCells[h][w] = Cell.Dead;
                    }
                    else if(aliveCount == 3)
                    {
                        tempCells[h][w] = Cell.Alive;
                    }

                }
                
            }
            Cells = tempCells;*/
        }

        public int CountLivingNeighbours(int xC, int yC)
        {
            int live = 0;
            /*if (xC-1 > -1)
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
            }*/
            return live;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int h = 0; h <= Height - 1; h++)
            {

                for (int w = 0; w <= Width - 1; w++)
                {
                    /*if (this.Cells[h][w] == Cell.Alive)
                    {
                        output.Append(aliveCellChar); 
                    }
                    else
                    {
                        output.Append(" ");
                    }*/

                }
                output.AppendLine();
            }
            
          
            return output.ToString();
        }
    }
}
