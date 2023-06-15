namespace NewGameRunnerLib;
using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;
using System;
using System.Collections.Generic;


class NewGameRunner
    {
        private List<Player> _players;
        private Dice _dice;
        private Board _board;
        private Dictionary<Player, int> _playerPositions;
        private Dictionary<Player, int> _lastRollValue;

        public event Action<string> DisplayMessage;

        public NewGameRunner(Board board)
        {
            _players = new List<Player>();
            _dice = new Dice(6); // Misalnya, dadu 6 sisi
            _board = board; // Misalnya, papan permainan dengan ukuran 100
            _playerPositions = new Dictionary<Player, int>();
            _lastRollValue = new Dictionary<Player, int>();
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
        public Board GetBoard()
        {
            return _board;
        }
        public void AddPlayer(string name)
        {
            _players.Add(new Player(name));
        }

        public void RemovePlayer(string name)
        {
            _players.RemoveAll(player => player.GetName() == name);
        }

        public void StartGame()
        {
            DisplayMessage?.Invoke("Game Started");
            while (!IsGameFinished())
            {
                foreach (Player player in _players)
                {
                    PlayerInfo(player);
                    Console.ReadLine();

                    bool rollAgain = true;
                    int totalRolls = 0;

                    while (rollAgain && totalRolls < 3)
                    {
                        RollDice(player);
                        MoveForward(player);
                        totalRolls++;

                        if (ShouldRollAgain(player))
                        {
                            DisplayMessage?.Invoke($"Player {player.GetName()} rolled a 6! Roll Again.");
                        }
                        else
                        {
                            rollAgain = false;
                        }

                        DisplayAllPlayerPositions();
                    }
                }
            }
            EndGame();
        }

        private void PlayerInfo(Player player)
        {
            DisplayMessage?.Invoke($"\nPlayer: {player.GetName()} Position: {GetPlayerPosition(player)}");
            DisplayMessage?.Invoke($"Press Enter to roll the dice for Player {player.GetName()} ...");
        }

        private bool ShouldRollAgain(Player player)
        {
            return _lastRollValue[player] == 6;
        }

        private void DisplayAllPlayerPositions()
        {
            foreach (var entry in _playerPositions)
            {
                DisplayMessage?.Invoke($"Player {entry.Key.GetName()} Position: {entry.Value}");
            }
        }

        public void RollDice(Player player)
        {
            int roll = _dice.GetRoll();
            DisplayMessage?.Invoke($"\nPlayer {player.GetName()} rolled a dice {roll}");
            _lastRollValue[player] = roll;
        }

        public void MoveForward(Player player)
        {
            int currentPosition = GetPlayerPosition(player);
            int newPosition = currentPosition + _lastRollValue[player];

            if (newPosition <= _board.GetSize())
            {
                DisplayMessage?.Invoke($"Player {player.GetName()} moves to position {newPosition}");

                if (_board.GetSnakes().ContainsKey(newPosition))
                {
                    newPosition = HandleSnakeEncounter(player, newPosition);
                }
                else if (_board.GetLadders().ContainsKey(newPosition))
                {
                    newPosition = HandleLaddersEncounter(player, newPosition);
                }
            }
            else
            {
                newPosition = _board.GetSize() - (newPosition - _board.GetSize());
                DisplayMessage?.Invoke($"Player {player.GetName()} exceeded the target position. Moving back to position {newPosition}");
            }

            SetPlayerPosition(player, newPosition);
        }

        private int HandleSnakeEncounter(Player player, int currentPosition)
        {
            int snakeEndPosition = _board.GetSnakes()[currentPosition];
            DisplayMessage?.Invoke($"Player {player.GetName()} encountered a snake! Moving to position {snakeEndPosition}");
            return snakeEndPosition;
        }

        private int HandleLaddersEncounter(Player player, int currentPosition)
        {
            int ladderEndPosition = _board.GetLadders()[currentPosition];
            DisplayMessage?.Invoke($"Player {player.GetName()} encountered a ladder! Moving to position {ladderEndPosition}");
            return ladderEndPosition;
        }

        private int GetPlayerPosition(Player player)
        {
            if (_playerPositions.ContainsKey(player))
            {
                return _playerPositions[player];
            }

            return 0;
        }

        private void SetPlayerPosition(Player player, int position)
        {
            if (_playerPositions.ContainsKey(player))
            {
                _playerPositions[player] = position;
            }
            else
            {
                _playerPositions.Add(player, position);
            }
        }

        private bool IsGameFinished()
        {
            foreach (Player player in _players)
            {
                if (GetPlayerPosition(player) == _board.GetSize())
                {
                    DisplayMessage?.Invoke($"Player {player.GetName()} has won the game!");
                    return true;
                }
            }

            return false;
        }

        private void EndGame()
        {
            DisplayMessage?.Invoke("Game Finished");
        }
}
