using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;
using GameLogic.Models;

namespace TicTacToe.UI.Workflow
{
    public class MainMenu
    {

        public void Execute()
        {

            bool gameOver = false;
            PlayerMoves playerMoves = new PlayerMoves();

            UserInfo playerOne = SetUpUser();
            UserInfo playerTwo = SetUpUser();

            DisplayBoard.DisplayGameBoard();

            GamePlay game = new GamePlay();

            while (!gameOver)
            {
                bool validChoice = false;

                var currentPlayer = playerMoves.GetPlayersTurn(playerOne, playerTwo);

                string userInput = playerMoves.RequestPlayerMove(currentPlayer);

                validChoice = DisplayBoard.UpdateGameBoard(userInput, currentPlayer);

                gameOver = game.KeepPlaying(currentPlayer);

                if (gameOver)
                {
                    string notify = NotifyWinOrTie.Notify(game.WonOrTie(currentPlayer),
                        currentPlayer.UserName);
                    Console.WriteLine(notify);
                }
            }


            Console.ReadLine();
        }

        public UserInfo SetUpUser()
        {
            GetUserInfo setUpUser = new GetUserInfo();
            UserInfo playerInfo = setUpUser.SetUpPlayer();

            return playerInfo;
        }
    }
}
