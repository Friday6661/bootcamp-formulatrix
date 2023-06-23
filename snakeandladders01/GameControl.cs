using BoardLib;
using IBoardLib;
using PlayerLib;
using IPlayerLib;
using DiceLib;
using IDiceLib;
using CellTypeLib;
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
    public GameControl()
    {
        _players = new List<Player>();
        _dice = new Dice(0);
        _board = new Board(0);
        _playerPosition = new Dictionary<Player, int>();
        _lastRollValue = new Dictionary<Player, int>();
        _playerFinished = new Dictionary<Player, int>();
        _cellType = new CellType();
    }
    // Setup Players
    public Player GetPlayer(string name)
    {
        return _players.FirstOrDefault(player => player.GetName() == name);
    }
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
        List<Player> playersAtFinished = new List<Player>();
        foreach (var player in _players)
        {
            if (GetPlayerPosition(player) == _board.GetSize())
            {
                playersAtFinished.Add(player);
            }
        }
        return playersAtFinished;
    }
    public void MovePlayer(Player player)
    {
        int currentPosition = GetPlayerPosition(player);
        int newPosition = currentPosition + _lastRollValue[player];
        if (newPosition < _board.GetSize())
        {
            Console.WriteLine($"Player {player.GetName} moves to position {newPosition}");
            switch (GetCellType(newPosition))
            {
                case CellType.SnakeHead:
                    Console.WriteLine($"Player {player.GetName()} encountered a snake! moves to position {newPosition}");
                    newPosition = HandleSnakeEncounter(player, newPosition);
                    break;
                case CellType.LadderBottom:
                    Console.WriteLine($"Player {player.GetName()} encountered a ladder! moves to position {newPosition}");
                    newPosition = HandleLadderEncounter(player, newPosition);
                    break;
                default:
                    break;
            }
        }
        else if (newPosition > _board.GetSize())
        {
            Console.WriteLine($"Player {player.GetName()} exceeded the target position.Moving back to position {newPosition}");
            newPosition = _board.GetSize() - (newPosition - _board.GetSize());
        }
        else if (newPosition == _board.GetSize())
        {
            IList<Player> playersAtFinished = GetPlayersAtFinished();
        }
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
    public bool SetBoard(int size)
    {
        if (size > 20 && size % 10 == 0)
        {
            _board = new Board(size);
            return true;
        }
        return false;
    }
    public Board GetBoard()
    {
        return _board;
    }
    public int GetBoardSize()
    {
        return _board.GetSize();
    }
    public bool SetSnake(Dictionary<int, int> snakes)
    {
        foreach (var snake in snakes)
        {
            if (snake.Key > snake.Value && snake.Key < _board.GetSize() && snake.Value > 0)
            {
                _board.AddSnake(snake.Key, snake.Value);
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    public bool SetLadder(Dictionary<int, int> ladders)
    {
        foreach (var ladder in ladders)
        {
            if (ladder.Key > ladder.Value && ladder.Key < _board.GetSize() && ladder.Value > 0)
            {
                _board.AddSnake(ladder.Key, ladder.Value);
            }
            else
            {
                return false;
            }
        }
        return true;
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
    public bool SetGameFinished()
    {
        foreach (Player player in _players)
        {
            if (GetPlayerPosition(player) == _board.GetSize())
            {
                return true;
            }
        }
        return false;
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
