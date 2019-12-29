using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class Cannon : Chess
    {
        public Cannon(int positionx, int positiony, string name, string team) : base(positionx, positiony, name, team)
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
            while (tempx >= 0 && tempx <= 9)
            {
                Boolean eatable = false;
                if (tempx == 9)
                {
                    break;
                }
                tempx++;
                if (board[tempx, y] == "* ")
                {
                    area.Add($"{tempx},{y}");
                    Console.Write(area[area.Count - 1] + " ");   // find the coordinate that the cannon can mobve to
                }
                else
                {
                    while (tempx >= 0 && tempx <= 9)
                    {
                        tempx++;
                        if (tempx == 10)
                        {
                            break;
                        }
                        if (board[tempx, y] != "* ")
                        {
                            for (int i = 0; i < enermy.Length; i++)
                            {
                                if (enermy[i].getPositionx() == tempx && enermy[i].getPositiony() == y)  //find the chess that cannon can eat
                                {
                                    area.Add($"{tempx},{y}");
                                    Console.Write(area[area.Count - 1] + " ");
                                    eatable = true;
                                    break;
                                }
                            }
                            if (eatable)
                            {
                                break;
                            }
                        }
                        
                    }
                }
                if (eatable)
                {
                    break;
                }
            }
            tempx = x;
            while (tempx >= 0 && tempx <= 9)
            {
                Boolean eatable = false;
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
                    while (tempx >= 0 && tempx <= 9)
                    {
                        tempx--;
                        if (tempx <= -1)
                        {
                            break;
                        }
                        if (board[tempx, y] != "* ")
                        {
                            for (int i = 0; i < enermy.Length; i++)
                            {
                                if (enermy[i].getPositionx() == tempx && enermy[i].getPositiony() == y)
                                {
                                    area.Add($"{tempx},{y}");
                                    Console.Write(area[area.Count - 1] + " ");
                                    eatable = true;
                                    break;
                                }
                            }
                            if (eatable)
                            {
                                break;
                            }
                        }
                        
                    }
                }
                if (eatable)
                {
                    break;
                }
            }
            while (tempy >= 0 && tempy <= 8)
            {
                Boolean eatable = false;
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
                    while (tempy >= 0 && tempy <= 8)
                    {
                        tempy++;
                        if (tempy == 9)
                        {
                            break;
                        }
                        if (board[x, tempy] != "* ")
                        {
                            for (int i = 0; i < enermy.Length; i++)
                            {
                                if (enermy[i].getPositionx() == x && enermy[i].getPositiony() == tempy)
                                {
                                    area.Add($"{x},{tempy}");
                                    Console.Write(area[area.Count - 1] + " ");
                                    eatable = true;
                                    break;
                                }
                            }
                            if (eatable)
                            {
                                break;
                            }
                        }
                        
                    }
                }
                if (eatable)
                {
                    break;
                }
            }
            tempy = y;
            while (tempy >= 0 && tempy <= 8)
            {
                Boolean eatable = false;
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
                    while (tempy >= 0 && tempy <= 8)
                    {
                        tempy--;
                        if (tempy <= -1)
                        {
                            break;
                        }
                        if (board[x, tempy] != "* ")
                        {
                            for (int i = 0; i < enermy.Length; i++)
                            {
                                if (enermy[i].getPositionx() == x && enermy[i].getPositiony() == tempy)
                                {
                                    area.Add($"{x},{tempy}");
                                    Console.Write(area[area.Count - 1] + " ");
                                    eatable = true;
                                    break;
                                }
                            }
                            if (eatable)
                            {
                                break;
                            }
                        }
                        
                    }
                }
                if (eatable)
                {
                    break;
                }
            }
            return area;
        }
    }
}
