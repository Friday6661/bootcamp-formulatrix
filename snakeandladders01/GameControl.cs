using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;
using CellTypeLib;
using MessageLib;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace GameControlLib;

public class GameControl
{
    public List<Player> _players;
    private Dice _dice;
    private Board _board;
    private CellType _cellType;
    private Dictionary<Player, int> _playerPosition;
    private Dictionary<Player, int> _lastRollValue;
    private Dictionary<Player, int> _playerFinished;
    public delegate int snakeLaddderActionDelegate(Player player, int currentPosition);
    public delegate List<Player> PlayersAtFinished();
    public event snakeLaddderActionDelegate onSnakeEncounter;
    public event snakeLaddderActionDelegate onLadderEncounter;
    public event PlayersAtFinished onPlayersAtFinished;
    public GameControl()
    {
        _players = new List<Player>();
        _dice = new Dice();
        _board = new Board();
        _playerPosition = new Dictionary<Player, int>();
        _lastRollValue = new Dictionary<Player, int>();
        _playerFinished = new Dictionary<Player, int>();
        _cellType = new CellType();
    }
    // Setup Players
    public void AddPlayer(string name)
    {
        _players.Add(new Player(name));
    }
    public bool SetNumberOfPlayers(int numberOfPlayers)
    {
        if (numberOfPlayers >= 2 && numberOfPlayers <= 4)
        {
            _players.Clear();
            return true;
        }
        return false;
    }
    public List<Player> GetPlayers()
    {
        return _players;
    }
    public int GetPlayersCount()
    {
        return _players.Count();
    }
    public bool SetPlayerName(string name)
    {
        Player player = _players.FirstOrDefault(p => p.GetName() == name);
        if (name.Length > 2 && !_players.Any(p => p != player && p.GetName() == name))
        {
            player.SetName(name);
            return true;
        }
        return false;
    }
    public List<string> GetAllPlayerNames()
    {
        return _players.Select(player => player.GetName()).ToList();
    }
    public string GetPlayerName(Player player)
    {
            return player.GetName();
    }
    public List<string> GetAllPlayerIDs()
    {
        return _players.Select(player => player.GetId()).ToList();
    }
    public string GetPlayerID(Player player)
    {
        if (player != null)
        {
            return player.GetId();
        }
        return string.Empty;
    }
    public Dictionary<Player, int> GetPlayerPositions()
    {
        return _playerPosition;
    }
    public Player GetPlayerAtPosition(int position)
    {
        foreach (KeyValuePair<Player, int> entry in _playerPosition)
        {
            if (entry.Value == position)
            {
                return entry.Key;
            }
        }
        return null;
    } 
    public List<Player> GetPlayersInPosition(int position)
    {
        List<Player> playersInPosition = new List<Player>();
        foreach (KeyValuePair<Player, int> entry in _playerPosition)
        {
            if (entry.Value == position)
            {
                playersInPosition.Add(entry.Key);
            }
        }
        return playersInPosition;
    }
    public int GetPlayerPosition(Player player)
    {
        if (_playerPosition.ContainsKey(player))
        {
            return _playerPosition[player];
        }
        return 0;
    }
    public void SetPlayerPosition(Player player, int position)
    {
        if (_playerPosition.ContainsKey(player))
        {
            _playerPosition[player] = position;
        }
        else
        {
            _playerPosition.Add(player, position);
        }
    }
    public List<Player> GetPlayersAtFinished()
    {
        if (onPlayersAtFinished != null)
        {
            return onPlayersAtFinished.Invoke();
        }
        List<Player> playersAtFinished = new List<Player>();
        foreach (var player in _players)
        {
            if (GetPlayerPosition(player) == GetBoardSize())
            {
                playersAtFinished.Add(player);
            }
        }
        return playersAtFinished;
    }
    public void MovePlayer(Player player)
    {
        int currentPosition = GetPlayerPosition(player);
        if (currentPosition == GetBoardSize())
        {
            return;
        }
        int newPosition = currentPosition + _lastRollValue[player];
        if (newPosition < _board.GetSize())
        {
            // Console.WriteLine($"Player {GetPlayerName(player)} moves to position {newPosition}");
            // Snake and Ladder encountered
            if (GetBoard().GetSnake().ContainsKey(newPosition) && !GetRollAgain(player))
            {
                newPosition = onSnakeEncounter?.Invoke(player, newPosition) ?? GetSnakeTail(newPosition);
                Message.SnakeEncounter.ToString();
            }
            else if (GetBoard().GetLadder().ContainsKey(newPosition) && !GetRollAgain(player))
            {
                newPosition = onLadderEncounter?.Invoke(player, newPosition) ?? GetLadderTop(newPosition);
                Message.LadderEncounter.ToString();
            }
            Message.NewPosition.ToString();
            // Console.WriteLine($"Player {GetPlayerName(player)} moves to position {newPosition}");
        }
        else if (newPosition > GetBoardSize())
        {
            newPosition = GetBoardSize() - (newPosition - GetBoardSize());
            Message.ExceededMove.ToString();
            if (GetBoard().GetSnake().ContainsKey(newPosition))
            {
                newPosition = onSnakeEncounter?.Invoke(player, newPosition) ?? GetSnakeTail(newPosition);
                Message.SnakeEncounter.ToString();
            }
            else if (GetBoard().GetLadder().ContainsKey(newPosition))
            {
                newPosition = onLadderEncounter?.Invoke(player, newPosition) ?? GetLadderTop(newPosition);
                Message.LadderEncounter.ToString();
            }
            Message.NewPosition.ToString();
            // Console.WriteLine($"Player {GetPlayerName(player)} moves to position {newPosition}");
            // Console.WriteLine($"Player {GetPlayerName(player)} exceeded the target position. Moving back to position {newPosition}");
        }
        else if (newPosition == GetBoardSize())
        {
            foreach (var p in GetPlayersAtFinished())
            {
                Message.Finished.ToString();
                // Console.WriteLine($"Player Name {GetPlayerName(p)} Player ID {GetPlayerID(p)}"); 
            }
        }
        SetPlayerPosition(player, newPosition);
    }

    // Setup Dice
    public bool SetDice(int numberOfSides)
    {
        if (numberOfSides > 0)
        {
            _dice = new Dice(numberOfSides);
            return true;
        }
        return false;
    }
    public Dice GetDice(){
        return _dice;
    }
    public int GetNumberOfSides()
    {
        return _dice.GetNumberOfSides();
    }
    public void RollDice(Player player)
    {
        int rollValue = _dice.GetRoll();
        _lastRollValue[player] = rollValue;
    }
    public int GetLastRollValue(Player player)
    {
        if (_lastRollValue.ContainsKey(player))
        {
            return _lastRollValue[player];
        }
        return 0;
    }
    // public void SetLastRollValue(Player player, int rollValue)
    // {
    //     _lastRollValue[player] = rollValue;
    // }
    public bool SetRollAgain(Player player, bool rollAgain)
    {
        if (_lastRollValue.ContainsKey(player))
        {
            _lastRollValue[player] = rollAgain ? _dice.GetNumberOfSides() : 0;
            return true;
        }
        return false;
    }
    public bool GetRollAgain(Player player)
    {
        if (_lastRollValue.ContainsKey(player))
        {
            int lastRollValue = _lastRollValue[player];
            return lastRollValue == _dice.GetNumberOfSides();
        }
        return false;
    }
    public int GetTotalRolls(Player player)
    {
        if (_lastRollValue.ContainsKey(player))
        {
            int totalRolls = _lastRollValue.Count(kv => kv.Key == player);
            return totalRolls;
        }
        return 0;
    }

    // Setup Board
    public bool SetBoard(int size, Dictionary<int, int> snake, Dictionary<int, int> ladder)
    {
        if (size > 20 && size % 10 == 0)
        {
            _board = new Board(size, snake, ladder);
            return true;
        }
        return false;
    }
    // public void SetSnakes(int snakeHead, int snakeTail)
    // {
    //     if (snakeHead > snakeTail && snakeHead < GetBoardSize() && snakeTail > 0)
    //     {
    //         _board.SetSnake(snakeHead, snakeTail);
    //         Console.WriteLine("Snake sets");
    //     }
    // }
    public Board GetBoard()
    {
        return _board;
    }
    public int GetBoardSize()
    {
        return _board.GetSize();
    }
    public void SetSnake(Dictionary<int, int> snakes)
    {
        foreach (var snake in snakes)
        {
            if (snake.Key > snake.Value && snake.Key < _board.GetSize() && snake.Value > 0)
            {
                _board.AddSnake(snake.Key, snake.Value);
            }
        }
    }
    public void SetLadder(Dictionary<int, int> ladders)
    {
        foreach (var ladder in ladders)
        {
            if (ladder.Key > ladder.Value && ladder.Key < _board.GetSize() && ladder.Value > 0)
            {
                _board.AddSnake(ladder.Key, ladder.Value);
            }
        }
    }
    public int GetSnakeHead(int tailPosition)
    {
        foreach (var snake in _board.GetSnake())
        {
            if (snake.Value == tailPosition)
            {
                return snake.Key;
            }
        }
        return 0;
    }
    public int GetSnakeTail(int headPosition)
    {
        foreach (var snake in _board.GetSnake())
        {
            if (snake.Key == headPosition)
            {
                return snake.Value;
            }
        }
        return 0;
    }
    public int GetLadderBottom(int topPosition)
    {
        foreach (var ladder in _board.GetLadder())
        {
            if (ladder.Value == topPosition)
            {
                return ladder.Key;
            }
        }
        return 0;
    }
    public int GetLadderTop(int bottomPosition)
    {
        foreach (var ladder in _board.GetLadder())
        {
            if (ladder.Key == bottomPosition)
            {
                return ladder.Value;
            }
        }
        return 0;
    }
    public int HandleSnakeEncounter(Player player, int currentPosition)
    {
        return GetSnakeTail(currentPosition);
    }
    public int HandleLadderEncounter(Player player, int currentPosition)
    {
        return GetLadderTop(currentPosition);
    }
    public List<Player> HandlePlayersAtFinished(GameControl gameControl)
    {
        List<Player> players = new List<Player>();
        List<Player> finishedPlayers = gameControl.GetPlayersAtFinished();
        foreach (var player in finishedPlayers)
        {
            players.Add(player);
        }
        return players;
    }
    public bool SetGameFinished()
    {
        int playerFinishedCount = 0;
        foreach (Player player in _players)
        {
            if (GetPlayerPosition(player) == _board.GetSize())
            {
                playerFinishedCount++;
            }
        }
        return playerFinishedCount == _players.Count() - 1;
    }
    public CellType GetCellType(int position)
    {
        if (_board.GetSnake().ContainsKey(position))
        {
            int tailPosition = _board.GetSnake()[position];
            return GetSnakeHead(tailPosition) != 0 ? CellType.SnakeHead : CellType.SnakeTail;
        }
        else if (_board.GetLadder().ContainsKey(position))
        {
            int topPosition = _board.GetLadder()[position];
            return GetLadderBottom(topPosition) != 0 ? CellType.LadderBottom : CellType.LadderTop;
        }
        else if (_playerPosition.ContainsValue(position))
        {
            return CellType.Player;
        }
        else
        {
            return CellType.Normal;
        }
    }
    
}
