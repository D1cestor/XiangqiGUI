using System;
using System.Collections.Generic;

namespace Xiangqi
{
    public class Game
    {
        //static String[] steam = { "red", "black" };
        String team = "red";
        static int turn = 0;
        Boolean gameover = false;
        string[,] board = new string[10, 9];
        Chess[] rc = new Chess[16];
        Chess[] bc = new Chess[16];
        Chess choosedChess = new Chess(0,0,"","");
        public Game()
        {
            rc[0] = new Horse(0, 1, "傌", "red");
            rc[1] = new Elephant(0, 2, "相", "red");
            rc[2] = new Advisor(0, 3, "仕", "red");
            rc[3] = new General(0, 4, "帅", "red");
            rc[4] = new Advisor(0, 5, "仕", "red");
            rc[5] = new Elephant(0, 6, "相", "red");
            rc[6] = new Horse(0, 7, "傌", "red");
            rc[7] = new Rook(0, 8  , "俥", "red");
            rc[8] = new Cannon(2, 1, "炮", "red");
            rc[9] = new Cannon(2, 7, "炮", "red");
            rc[10] = new Soilder(3, 0, "兵", "red");
            rc[11] = new Soilder(3, 2, "兵", "red");
            rc[12] = new Soilder(3, 4, "兵", "red");
            rc[13] = new Soilder(3, 6, "兵", "red");
            rc[14] = new Soilder(3, 8, "兵", "red");
            rc[15] = new Rook(0, 0, "俥", "red");
            bc[0] = new Horse(9, 1, "馬", "black");
            bc[1] = new Elephant(9, 2, "象","black");
            bc[2] = new Advisor(9, 3, "士", "black");
            bc[3] = new General(9, 4, "将", "black");
            bc[4] = new Advisor(9, 5, "士", "black");
            bc[5] = new Elephant(9, 6, "象", "black");
            bc[6] = new Horse(9, 7, "馬", "black");
            bc[7] = new Rook(9, 8, "車", "black");
            bc[8] = new Cannon(7, 1, "砲", "black");
            bc[9] = new Cannon(7, 7, "砲", "black");
            bc[10] = new Soilder(6, 0, "卒", "black");
            bc[11] = new Soilder(6, 2, "卒", "black");
            bc[12] = new Soilder(6, 4, "卒", "black");
            bc[13] = new Soilder(6, 6, "卒", "black");
            bc[14] = new Soilder(6, 8, "卒", "black");
            bc[15] = new Rook(9, 0, "車", "black");
            refresh(board, rc, bc);
        }

        public void refresh(string[,] board, Chess[] rc, Chess [] bc)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.board[i, j] = "* ";
                }
            }
            for (int i = 0; i < rc.Length; i++)
            {
                if (rc[i].getDead()) continue;
                int x = this.rc[i].getPositionx();
                int y = this.rc[i].getPositiony();
                this.board[x, y] = this.rc[i].getName();
            }

            for (int i = 0; i < bc.Length; i++)
            {
                if (bc[i].getDead()) continue;
                int x = this.bc[i].getPositionx();
                int y = this.bc[i].getPositiony();
                this.board[x, y] = this.bc[i].getName();

            }
        }


        public void ChoosePiece(int x, int y)
        {
            Boolean choose = false;
            Chess[] chessTeam;
            if (this.getTeam() == "red")
            {
                chessTeam = rc;
            }
            else 
            {
                chessTeam = bc;
            }
            for (int i = 0; i < chessTeam.Length; i++)
            {
                if (chessTeam[i].getPositionx() == x && chessTeam[i].getPositiony() == y)
                {
                    choosedChess = chessTeam[i];
                    choose = true;
                }
            }
            if (!choose)
            {
                throw new ArgumentException("You can't choose it");
            }
        }

        public void MovePiece(int x, int y)
        {
            
            this.choosedChess.move(x, y, rc, bc, board);
            refresh(board, rc, bc);
            ifGameover(rc, bc);
            this.choosedChess = new Chess(0, 0, "", "");
            turn++;
        }

        public void ifGameover(Chess[] rc, Chess[] bc) 
        {
            if (rc[3].getDead() || bc[3].getDead())
            {
                this.gameover = true;
            }
        }
        
       
        public void printBoard()
        {
            Console.Clear();
            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                {
                    Console.Write("  ");
                }
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        Console.Write($"{i} ");
                    }
                    Console.Write(this.board[i, j]);
                }
                Console.WriteLine("\n");
            }


        }
        public int getTurn() { return turn; }
        public string getTeam() { return this.team; }
        public Boolean getGameover() { return this.gameover; }
        public Chess[] getAllChess() { return Merge(rc,bc); }
        public static Chess[] Merge(Chess[] arr, Chess[] other)
        {
            Chess[] buffer = new Chess[arr.Length + other.Length];
            arr.CopyTo(buffer, 0);
            other.CopyTo(buffer, arr.Length);
            return buffer;
        }
        public string[,] getBoard()
        {
            return this.board;
        }
        public Chess getChoosedChess()
        {
            return this.choosedChess;
        }
        public Chess[] getrc()
        {
            return this.rc;
        }
        public Chess[] getbc()
        {
            return this.bc;
        }
        public void switchTeam()
        {
            if (this.team == "black")
            {
                this.team = "red";
                return;
            }
            if (this.team == "red")
            {
                this.team = "black";
                return;
            }
        }
        public void setChoosedChess(Chess c)
        {
            this.choosedChess = c;
        }
    }
}
