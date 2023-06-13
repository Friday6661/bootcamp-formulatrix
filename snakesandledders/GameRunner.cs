namespace GameRunnerLib;
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

    public event Action<string> DisplayMessage;

    public GameRunner(Board board)
    {
        _players = new List<Player>();
        _dice = new Dice(6); // Misalnya, dadu 6 sisi
        _board = board; // Misalnya, papan permainan dengan ukuran 100
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

    public void AddPlayer(string name)
    {
        _players.Add(new Player(name));
    }

    public void RemovePlayer(string name)
    {
        _players.Remove(new Player(name));
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
                        DisplayMessage?.Invoke($"Player {player.GetName()} roll a 6! Roll Again.");
                    }
                    else
                    {
                        rollAgain = false;
                    }

                    AllPlayerPositions();
                }
            }
        }
        EndGame();
    }
    private void PlayerInfo(Player player)
    {
        DisplayMessage?.Invoke($"\nPlayer: {player.GetName()} Position: {player.GetPosition()}");
        DisplayMessage?.Invoke($"Press Enter to roll the dice for Player {player.GetName()} ...");
    }
    private bool ShouldRollAgain(Player player)
    {
        return player.GetPosition() < _board.GetSize() && player.GetLastRoll() == 6;
    }
    private void AllPlayerPositions()
    {
        foreach (Player player in _players)
        {
            DisplayMessage?.Invoke($"Player {player.GetName()} Position: {player.GetPosition()}");
        }
    }

    public void RollDice(Player player)
    {
        int roll = _dice.GetRoll();
        DisplayMessage?.Invoke($"\nPlayer {player.GetName()} rolled a dice {roll}");
        player.SetPosition(player.GetPosition() + roll);
        player.SetLastRoll(roll);
    }
    public void MoveForward(Player player)
    {
        int currentPosition = player.GetPosition();
        int newPosition = currentPosition;

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
            //DisplayMessage?.Invoke($"Player {player.GetName()} position {currentPosition}");
            newPosition = _board.GetSize() - (newPosition - _board.GetSize());
            DisplayMessage?.Invoke($"Player {player.GetName()} exceeded the target position. Moving back to position {newPosition}");
        }
        player.SetPosition(newPosition);
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

    private bool IsGameFinished()
    {
        foreach (Player player in _players)
        {
            int playerPosition = player.GetPosition();
            if (playerPosition == _board.GetSize())
            {
                DisplayMessage?.Invoke($"Player {player.GetName()} has a Winner! Game Finished.");
                //RemovePlayer(player.GetName());
                return true;
            }/*
            else if (playerPosition > _board.GetSize())
            {
                int excessSteps = playerPosition - _board.GetSize();
                int newPosition = _board.GetSize() - excessSteps;
                MoveBackward(player, newPosition);
                DisplayMessage?.Invoke($"Player {player.GetName()} exceeded the target position. Moving back {excessSteps} steps.");
            }*/
        }

        return false;
    }
/*
    private void MoveBackward(Player player, int newPosition)
    {
        player.SetPosition(newPosition);
    }
*/
    private void EndGame()
    {
        //Console.WriteLine("Game Finished! Press Enter to Exit");
        DisplayMessage?.Invoke("Press Enter to Exit Game!");
        Console.ReadLine();
        Environment.Exit(0);
    }
}
