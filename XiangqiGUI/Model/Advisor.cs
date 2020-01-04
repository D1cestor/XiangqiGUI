using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class Advisor : Chess
    {
        public Advisor(int positionx, int positiony, string name, string team) : base(positionx, positiony, name, team)
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
            if (this.getTeam() == "red")
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        int pw = (int)(Math.Pow(x - i, 2) + Math.Pow(y - j, 2));
                        if (pw == 2) // Whether the distance between (i,j) and (x,y) are √2.
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
                            if (eatable || board[i,j] == "* ")
                            {
                                area.Add($"{i},{j}");
                                Console.Write(area[area.Count - 1] + " ");
                            }
                        }
                    }
                }
            }
            if (this.getTeam() == "black")
            {
                for (int i = 7; i < 10; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        int pw = (int)(Math.Pow(x - i, 2) + Math.Pow(y - j, 2));
                        if (pw == 2) // Whether the distance between (i,j) and (x,y) are √2.
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
