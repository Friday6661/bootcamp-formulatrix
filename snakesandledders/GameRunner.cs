using System;
using System.Collections.Generic;
using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;
using TileTypeLib;

class GameRunner
{
    private List<Player> _players;
    private Dice _dice;
    private Board _board;

    public GameRunner()
    {
        _players = new List<Player>();
        _dice = new Dice(6); // Misalnya, dadu 6 sisi
        _board = new Board(100); // Misalnya, papan permainan dengan ukuran 100
    }

    public void SetPlayers(List<Player> players)
    {
        _players = players;
    }

    public List<Player> GetPlayers()
    {
        return _players;
    }

    public void SetBoardSize(int size)
    {
        _board = new Board(size);
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
    }

    // Metode lain yang mungkin ada dalam GameRunner

    public void StartGame()
    {
        Console.WriteLine("Game Started!");

        while (!IsGameFinished())
        {
            foreach (Player player in _players)
            {
                Console.WriteLine("\nPlayer: " + player.GetName() + " - Position: " + player.GetPosition());
                Console.WriteLine("Press any key to roll the dice for Player " + player.GetName() + "...");
                Console.ReadLine();

                bool rollAgain = true;
                int totalRolls = 0;

                while (rollAgain && totalRolls < 3) // Batasi jumlah roll tambahan maksimal menjadi 3
                {
                    RollDice(player);
                    MoveForward(player);
                    totalRolls++;

                    if (player.GetPosition() < _board.GetSize() && player.GetLastRoll() == 6)
                    {
                        Console.WriteLine("Player " + player.GetName() + " rolled a 6! Roll again.");
                    }
                    else
                    {
                        rollAgain = false;
                    }

                    foreach (Player otherPlayer in _players)
                    {
                        Console.WriteLine("Player " + otherPlayer.GetName() + " - Position: " + otherPlayer.GetPosition());
                    }
                }
            }
        }

        EndGame();
    }


    public void RollDice(Player player)
    {
        int roll = _dice.GetRoll();
        Console.WriteLine("\nPlayer " + player.GetName() + " rolled a " + roll);
        player.SetPosition(player.GetPosition() + roll);

        player.SetLastRoll(roll);
    }

    public void MoveForward(Player player)
    {
        int currentPosition = player.GetPosition();
        TileType tileType = _board.GetTileType(currentPosition);
        Console.WriteLine("Player " + player.GetName() + " is on a " + tileType + " tile at position " + currentPosition);

        if (tileType == TileType.Snake)
        {
            int snakeEndPosition = _board.GetSnakeEndPosition(currentPosition);
            Console.WriteLine("Player " + player.GetName() + " encountered a snake! Moving to position " + snakeEndPosition);
            player.SetPosition(snakeEndPosition);
        }
        else if (tileType == TileType.Ladder)
        {
            int ladderEndPosition = _board.GetLadderEndPosition(currentPosition);
            Console.WriteLine("Player " + player.GetName() + " found a ladder! Moving to position " + ladderEndPosition);
            player.SetPosition(ladderEndPosition);
        }
    }

    private bool IsGameFinished()
    {
        foreach (Player player in _players)
        {
            int playerPosition = player.GetPosition();
            if (playerPosition == _board.GetSize())
            {
                Console.WriteLine("Player " + player.GetName() + " has reached the end! Game Finished.");
                return true;
            }
            else if (playerPosition > _board.GetSize())
            {
                int excessSteps = playerPosition - _board.GetSize();
                int newPosition = _board.GetSize() - excessSteps;
                MoveBackward(player, newPosition);
                Console.WriteLine("Player " + player.GetName() + " exceeded the target position. Moving back " + excessSteps + " steps.");
            }
        }

        return false;
    }

    private void MoveBackward(Player player, int newPosition)
    {
        player.SetPosition(newPosition);
    }

    private void EndGame()
    {
        Console.WriteLine("Game Finished! Press Enter to Exit");
        Console.ReadLine();
        Environment.Exit(0);
    }

}
