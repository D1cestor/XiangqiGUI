using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class Elephant : Chess
    {
        public Elephant(int positionx, int positiony, string name, string team) : base(positionx, positiony, name, team)
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
            for (int i = x - 2; i < x + 3; i += 4)          //find out whether (x-2,y-2),(x-2,y+2),(x+2,y-2),(x+2,y+2) can satisify the condition.
            {
                for (int j = y - 2; j < y + 3; j += 4)
                {
                    if (i <= 9 && i >= 0 && j <= 8 && j >= 0)
                    {
                        if (board[(i + x) / 2, (y + j) / 2] == "* ")
                        {
                            Boolean eatAble = false;
                            for (int k = 0; k < enermy.Length; k++)
                            {
                                if (enermy[k].getPositionx() == i && enermy[k].getPositiony() == j)
                                {
                                    eatAble = true;
                                }
                            }
                            if (eatAble || board[i,j] == "* ")
                            {
                                if (this.getTeam() == "red")
                                {
                                    if (i < 5)
                                    {
                                        area.Add($"{i},{j}");
                                        Console.Write(area[area.Count - 1] + " ");
                                    }
                                }
                            }
                            if (eatAble || board[i, j] == "* ")
                            {
                                if (this.getTeam() == "black")
                                {
                                    if (i > 4)
                                    {
                                        area.Add($"{i},{j}");
                                        Console.Write(area[area.Count - 1] + " ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //int leftUpx = x - 2, leftUpy = y - 2, rightUpx = x - 2, rightUpy = x + 2;
            //int rightDownx = x + 2, rightDowny = y + 2, leftDownx = x + 2, leftDowny = y - 2;
            //if (leftUpx > 0 && leftUpy > 0)
            //{
            //    Boolean eatable = false;
            //    for (int i = 0; i < enermy.Length; i++)
            //    {
            //        if (enermy[i].getPositionx() == leftUpx && enermy[i].getPositiony() == leftUpy)
            //        {
            //            eatable = true;
            //        }
            //    }
            //        if (board[x - 1, y - 1] == "* ")
            //        {
            //            if (board[leftUpx, leftUpy] == "* " || eatable)
            //            {
            //                area.Add($"{leftUpx},{leftUpy}");
            //                Console.Write(area[area.Count - 1] + " ");
            //            } 
            //        }
                
            //}

            //if (rightUpx > 0 && rightUpy < 9)
            //{
            //    Boolean eatable = false;
            //    for (int i = 0; i < enermy.Length; i++)
            //    {
            //        if (enermy[i].getPositionx() == rightUpx && enermy[i].getPositiony() == rightUpy)
            //        {
            //            eatable = true;
            //        }
            //    }
            //        if (board[x - 1, y + 1] == "* ")
            //        {
            //            if (board[rightUpx, rightUpy] == "* " || eatable)
            //            {
            //                area.Add($"{rightUpx},{rightUpy}");
            //                Console.Write(area[area.Count - 1] + " ");
            //            }
            //        }
                
            //}

            //if (rightDownx < 10 && rightDowny < 9)
            //{
            //    Boolean eatable = false;
            //    for (int i = 0; i < enermy.Length; i++)
            //    {
            //        if (enermy[i].getPositionx() == rightDownx && enermy[i].getPositiony() == rightDowny)
            //        {
            //            eatable = true;
            //        }
            //    }
            //        if (board[x + 1, y + 1] == "* ")
            //        {
            //            if (board[rightDownx, rightDowny] == "* " || eatable)
            //            {
            //                area.Add($"{rightDownx},{rightDowny}");
            //                Console.Write(area[area.Count - 1] + " ");
            //            }
            //        }
                
            //}

            //if (leftDownx < 10 && leftDowny > 0)
            //{
            //    Boolean eatable = false;
            //    for (int i = 0; i < enermy.Length; i++)
            //    {
            //        if (enermy[i].getPositionx() == leftDownx && enermy[i].getPositiony() == leftDowny)
            //        {
            //            eatable = true;
            //        }
            //    }
            //        if (board[x + 1, y - 1] == "* ")
            //        {
            //            if (board[leftDownx, leftDowny] == "* " || eatable)
            //            {
            //                area.Add($"{leftDownx},{leftDowny}");
            //                Console.Write(area[area.Count - 1] + " ");
            //            }
            //        }
                
            //}
            return area;
        }
    }
}
