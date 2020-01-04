using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class Horse : Chess
    {
        public Horse(int positionx, int positiony, string name, string team) : base(positionx, positiony, name, team)
        {
        }
        public override List<string> moveableArea(Chess[] rc, Chess[] bc, string[,] board)
        {
            List<string> area = new List<string>();
            int x = this.getPositionx();
            int y = this.getPositiony();
            Chess[] enermy;
            switch (this.getTeam())
            {
                case "red":
                    enermy = bc;
                    break;
                default:
                    enermy = rc;
                    break;
            }
            for (int i = x - 2; i <= x + 2; i++)
            {
                for (int j = y - 2; j <= j + 2; j++)
                {
                    if (j < 0)
                    {
                        continue;
                    }
                    if (i > 9 || j > 8 || i < 0)
                    {
                        break;
                    }
                    int pw = (int)(Math.Pow(x - i, 2) + Math.Pow(y - j, 2));
                    if (pw == 5) // Whether the distance between (i,j) and (x,y) are √5.
                    {
                        Boolean canMoveRight = Math.Abs(x - i) < Math.Abs(y - j) && j - y > 0 && board[x, y + 1] == "* ";
                        Boolean canMoveUp = Math.Abs(x - i) > Math.Abs(y - j) && i - x < 0 && board[x - 1, y] == "* "; 
                        Boolean canMoveLeft = Math.Abs(x - i) < Math.Abs(y - j) && j - y < 0 && board[x, y - 1] == "* "; 
                        Boolean canMoveDown = Math.Abs(x - i) > Math.Abs(y - j) && i - x > 0 && board[x + 1, y] == "* "; 
                        if (canMoveRight || canMoveLeft || canMoveDown || canMoveUp)
                        {
                            Boolean eatable = false;
                            for (int k = 0; k < enermy.Length; k++)
                            {
                                if (enermy[k].getPositionx() == i && enermy[k].getPositiony() == j)
                                {
                                    eatable = true;
                                    break;
                                }
                            }
                            if (eatable || board[i, j] == "* ")
                            {
                                area.Add($"{i},{j}");
                                Console.Write(area[area.Count - 1] + " ");
                            }
                        }

                    }
                }
            }
            return area;
        }
    }
}
