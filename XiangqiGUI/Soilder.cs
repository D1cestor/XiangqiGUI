using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class Soilder : Chess
    {
        public Soilder(int positionx, int positiony, string name, string team) : base(positionx, positiony,name, team)
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
            bool right = false;   //Whether there is a enermy on the right side.
            for (int i = 0; i < enermy.Length; i++)
            {
                if (x == enermy[i].getPositionx() && y + 1 == enermy[i].getPositiony())
                {
                    right = true;
                    break;
                }
            }

            bool left = false;
            for (int i = 0; i < enermy.Length; i++)    //whether there is a enermy on the left side.
            {
                if (x == enermy[i].getPositionx() && y - 1 == enermy[i].getPositiony())
                {
                    left = true;
                    break;
                }
            }

            if (y > 0)
            {
                if (left || board[x, y - 1] == "* ")   // Put the coordinate into the set if the left side is enermy or empty.
                {
                    if (this.getTeam() == "red" && x > 4)   // Whether red soilder cross the river.
                    {
                        area.Add($"{x},{y - 1}");
                        Console.Write(area[area.Count - 1] + " ");
                    }
                    if (this.getTeam() == "black" && x < 5) // Whether black soilder cross the river.
                    {
                        area.Add($"{x},{y - 1}");
                        Console.Write(area[area.Count - 1] + " ");
                    }
                }
            }

            if (y < 8)
            {
                if (right || board[x, y + 1] == "* ")   //Put the coordinate into the set if the right side is enermy or empty.
                {
                    if (this.getTeam() == "red" && x > 4)   // Whether red soilder cross the river.
                    {
                        area.Add($"{x},{y + 1}");
                        Console.Write(area.Count - 1 + " ");
                    }
                    if (this.getTeam() == "black" && x < 5) // Whether black soilder cross the river.
                    {
                        area.Add($"{x},{y + 1}");
                        Console.Write(area[area.Count - 1] + " ");
                    }
                }
            }
            if (this.getTeam() == "red")
            {
                bool front = false;
                if (x < 9)
                {
                    for (int i = 0; i < enermy.Length; i++)
                    {
                        if (x + 1 == enermy[i].getPositionx() && y == enermy[i].getPositiony()) //Whether there is an enermy 
                        {                                                                       //in front of the red soilder.
                            front = true;
                        }
                    }
                    if (front || board[x + 1, y] == "* ")  //Whether there is an enermy or enermy in front of the red soilder.
                    {
                        area.Add($"{x + 1},{y}");
                        Console.Write(area[area.Count-1] + " ");
                    }
                }
            }
            if (this.getTeam() == "black")
            {
                bool front = false;
                if (x > 0)
                {
                    for (int i = 0; i < enermy.Length; i++)
                    {
                        if (x - 1 == enermy[i].getPositionx() && y == enermy[i].getPositiony()) //Whether there is an enermy 
                        {                                                                       //in front of the black soilder.
                            front = true;
                        }
                    }
                    if (front || board[x - 1, y] == "* ")  //Whether there is an enermy or enermy in front of the red soilder.
                    {
                        area.Add($"{x - 1},{y}");
                        Console.Write(area[area.Count - 1] + " ");
                    }
                }
            }

            return area;
        }
    }
}
