using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class Rook :Chess
    {

        public Rook(int positionx, int positiony, string name, string team) : base(positionx, positiony, name, team)
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
            while (tempx >= 0 && tempx <=9)
            {
                if (tempx == 9)
                {
                    break;
                }
                tempx++;
                if (board[tempx, y] == "* ")
                {
                    area.Add($"{tempx},{y}");
                    Console.Write(area[area.Count-1]+" ");
                }
                else
                {
                    for (int i = 0; i < enermy.Length; i++)
                    {
                        if (enermy[i].getPositionx() == tempx && enermy[i].getPositiony() == y)
                        {

                            area.Add($"{tempx},{y}");
                            Console.Write(area[area.Count-1]+" ");
                        }
                    }
                    tempx = x;
                    break;
                }
                
            }
            while (tempx >= 0 && tempx <=9)
            {
                if (tempx == 0)
                {
                    break;
                }
                tempx--;
                if (board[tempx, y] == "* ")
                {
                    area.Add($"{tempx},{y}");
                    Console.Write(area[area.Count - 1] + " ");
                }
                else
                {
                    for (int i = 0; i < enermy.Length; i++)
                    {
                        if (enermy[i].getPositionx() == tempx && enermy[i].getPositiony() == y)
                        {

                            area.Add($"{tempx},{y}");
                            Console.Write(area.Count-1+" ");
                        }
                    }
                    tempx = x;
                    break;
                }

            }
            while (tempy >= 0 && tempy <=8)
            {
                if (tempy == 8)
                {
                    break;
                }
                tempy++;
                if (board[x, tempy] == "* ")
                {
                    area.Add($"{x},{tempy}");
                    Console.Write(area[area.Count - 1] + " ");
                }
                else
                {
                    for (int i = 0; i < enermy.Length; i++)
                    {
                        if (enermy[i].getPositiony() == tempy && enermy[i].getPositionx() == x)
                        {

                            area.Add($"{x},{tempy}");
                            Console.Write(area[area.Count - 1] + " ");
                        }
                    }
                    tempy = y;
                    break;
                }

            }
            while (tempy >= 0 && tempy <=8) { 

                if (tempy == 0)
                {
                    break;
                }
                tempy--;
                if (board[x, tempy] == "* ")
                {
                    area.Add($"{x},{tempy}");
                    Console.Write(area[area.Count - 1] + " ");
                }
                else
                {
                    for (int i = 0; i < enermy.Length; i++)
                    {
                        if (enermy[i].getPositiony() == tempy && enermy[i].getPositionx() == x)
                        {

                            area.Add($"{x},{tempy}");
                            Console.Write(area[area.Count - 1] + " ");
                            break;
                        }
                    }
                
                }
            }
            return area;
        }
    }
}
