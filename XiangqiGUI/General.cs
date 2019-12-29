using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class General : Chess
    {
        public General(int positionx, int positiony, string name, string team) : base(positionx, positiony, name, team)
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
            int tempx = x;
            int tempy = y;
            Boolean checkmate = false;
            if (this.getTeam() == "red")
            {
                for (int i = 0; i < 3; i++)
                {
                    for(int j = 3; j < 6; j++)
                    {
                        int pw = (int)(Math.Pow(x - i, 2) + Math.Pow(y - j, 2));
                        if(pw == 1)  // Whether the distance between (i,j) and (x,y) are 1.
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
                            for (int l = x+1; l<=9; l++) // Two generals are facing.
                            {
                                if (board[l,y] == "* ")
                                {
                                    continue;
                                }
                                if (board[l,y] == "将")
                                {
                                    area.Add($"{l},{y}");
                                    Console.Write(area[area.Count - 1] + " ");
                                    checkmate = true;
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (checkmate) { break; }
                        }
                        
                    }
                    if (checkmate) { break; }
                }
            }
            if (this.getTeam() == "black")
            {
                for (int i = 7; i < 10; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        int pw = (int)(Math.Pow(x - i, 2) + Math.Pow(y - j, 2));
                        if (pw == 1) // Whether the distance between (i,j) and (x,y) are 1.
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
                            for (int l = x - 1; l >= 0; l--) // Two generals are facing.
                            {
                                if (board[l, y] == "* ")
                                {
                                    continue;
                                }
                                if (board[l, y] == "帅")
                                {
                                    area.Add($"{l},{y}");
                                    Console.Write(area[area.Count - 1] + " ");
                                    checkmate = true;
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }


                        if (checkmate) { break; }
                    }
                if (checkmate) { break; }
                }
            }
            return area;
        }
    }
}
