using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class Chess
    {
        int positionx = 0;
        int positiony = 0;
        string name = "棋";
        string team = "";
        bool dead = false;
        List<string> moveableAreaList = new List<string>();

        public Chess(int positionx,int positiony, string name, string team)
        {
            this.positionx = positionx;
            this.positiony = positiony;
            this.name = name;
            this.team = team;
        }
        
        public int getPositionx()
        {
            return this.positionx;
        }
        public void setPositionx(int positionx)
        {
            this.positionx = positionx;
        }
        public int getPositiony()
        {
            return this.positiony;
        }
        public void setPositiony(int positiony)
        {
            this.positiony = positiony;
        }
        public string getName()
        {
            return this.name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getTeam()
        {
            return this.team;
        }
        public bool getDead()
        {
            return dead;
        }
        public void setDead(bool dead)
        {
            this.dead = dead;
        }
        public void move(int x, int y, Chess[] rc, Chess[] bc, string[,] board)
        {
            List<string> area = moveableArea(rc, bc, board);
            string input = $"{x},{y}";
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
            if (area.Contains(input))
            {
                this.setPositionx(x);
                this.setPositiony(y);
                for (int i = 0; i < enermy.Length; i++)
                {
                    if (x == enermy[i].getPositionx() && y == enermy[i].getPositiony())
                    {
                        enermy[i].setDead(true);
                        break;
                    }
                }
            }
            else
            {
                throw new ArithmeticException("You can't move the chess here!");
            }
        }
        public virtual List<string> moveableArea(Chess[] rc, Chess[] bc, string[,] board)
        {
            List<string> area = new List<string>();
            return area;
        }
        public Boolean isValidMove(int i, int j, Chess[] rc, Chess[] bc, string[,] board)
        {
            Boolean canMove = false;
            List<string> moveableArea = this.moveableArea(rc, bc, board);
            string input = i.ToString() + "," + j.ToString();
            foreach (string var in moveableArea)
            {
                if (var == input)
                {
                    canMove = true;
                }
            }
            return canMove;
        }
    }
}
