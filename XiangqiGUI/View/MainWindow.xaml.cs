using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xiangqi;

namespace XiangqiGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum GameState
        {
            SelectPiece,
            SelectMove,
            Gameover
        }

        public GameState gameState = GameState.SelectPiece;
        public Game g = new Game();

        public MainWindow()
        {
            InitializeComponent();
            CreateGrid();
            RedrawGrid();
        }

        public void CreateGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                GameboardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int j = 0; j < 10; j++)
            {
                GameboardGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int col = 0; col < 9; col++)
            {
                for (int row = 0; row < 10; row++)
                {
                    Button button = new Button();
                    button.Name = "Button" + col.ToString() + row.ToString();
                    button.Click += new RoutedEventHandler(this.Button_Click);
                    button.SetValue(XQRowProperty, row);
                    button.SetValue(XQColumnProperty, col);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    GameboardGrid.Children.Add(button);
                }
            }
            Message.Text = "Select Piece";
            ShowTeam.Text = $"This is Team {g.getTeam()}'s turn";
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int btnRow = (int)((Button)sender).GetValue(XQRowProperty);
            int btnCol = (int)((Button)sender).GetValue(XQColumnProperty);
            HandleClick(btnCol, btnRow);
        }

        public static readonly DependencyProperty XQRowProperty =
            DependencyProperty.Register("XQRow",
                typeof(int),
                typeof(Button),
                new PropertyMetadata(default(int)));

        public static readonly DependencyProperty XQColumnProperty =
            DependencyProperty.Register("XQCol",
                typeof(int),
                typeof(Button),
                new PropertyMetadata(default(int)));
        public void RedrawGrid()
        {
            int i = 0;
            string[,] board = new string[9,10];
            for(int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[k, j] = g.getBoard()[j, k];
                }
            }
            foreach (string piece in board)
            {
                Button btnSelected = (Button)GameboardGrid.Children[i];
                if (piece == "* ")
                {
                    btnSelected.SetValue(ContentProperty, "");
                }
                else
                {
                    btnSelected.SetValue(ContentProperty, piece);
                    if (piece == "俥" || piece == "兵" || piece == "炮" || piece == "傌" || piece == "相" || piece == "仕" || piece == "帅")
                    {
                        btnSelected.SetValue(ForegroundProperty, Brushes.Red);
                    }
                    else
                    {
                        btnSelected.SetValue(ForegroundProperty, Brushes.Black);
                    }
                }
                if (g.getChoosedChess().getName() != "")
                {
                    Chess[] rc = g.getrc();
                    Chess[] bc = g.getbc();
                    string[,] board1 = g.getBoard();
                    Boolean valid = g.getChoosedChess().isValidMove(i % 10 , i / 10, rc, bc, board1);
                    if (valid)
                    {
                        btnSelected.SetValue(BackgroundProperty, Brushes.Aqua);
                    }
                    else
                    {
                        btnSelected.SetValue(BackgroundProperty, Brushes.White);
                    }
                }
                i++;
            }
            if (g.isChecked() && gameState == GameState.SelectPiece)
            {
                MessageBox.Show($"Team {g.getTeam()} is Checked!");
            }
            if (g.getGameover())
            {
                ChangeState(GameState.Gameover);
                string winner = "";
                if(g.getTeam() == "red")
                {
                    winner = "black";
                }
                if(g.getTeam() == "black")
                {
                    winner = "red";
                }
                MessageBox.Show($"The winner is Team {winner}");
            }
        }

        public void HandleClick(int btnCol,int btnRow)
        {
            try
            {
                switch (gameState)
                {
                    case GameState.SelectPiece:
                        g.ChoosePiece(btnRow, btnCol);
                        if (g.getChoosedChess().moveableArea(g.getrc(), g.getbc(), g.getBoard()).Count == 0)
                        {
                            MessageBox.Show("You can't move this piece!");
                            ChangeState(GameState.SelectPiece);
                            break;
                        }
                        ChangeState(GameState.SelectMove);
                        break;
                    case GameState.SelectMove:
                        if (btnRow == g.getChoosedChess().getPositionx() && btnCol == g.getChoosedChess().getPositiony())
                        {
                            g.setChoosedChess(new Chess(0, 0, "", ""));
                            ChangeState(GameState.SelectPiece);
                            foreach (Button b in GameboardGrid.Children)
                            {
                                b.SetValue(BackgroundProperty, Brushes.White);
                            }
                            break;
                        }
                        g.MovePiece(btnRow, btnCol);
                        
                        foreach (Button b in GameboardGrid.Children)
                        {
                            b.SetValue(BackgroundProperty, Brushes.White);
                        }
                        g.switchTeam();
                        ChangeState(GameState.SelectPiece);
                        break;
                }
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
                ChangeState(GameState.SelectPiece);
            }
            catch (ArithmeticException e)
            {
                MessageBox.Show(e.Message);
                ChangeState(GameState.SelectMove);
            }
            ShowTeam.Text = $"This is Team {g.getTeam()}'s turn";
            RedrawGrid();
        }

        public void ChangeState(GameState newState)
        {
            gameState = newState;
            switch (newState)
            {
                case GameState.SelectMove:
                    Message.Text = "Select Move";
                    break;

                case GameState.SelectPiece:
                    Message.Text = "Select Piece";
                    break;
            }
        }
    }
}
